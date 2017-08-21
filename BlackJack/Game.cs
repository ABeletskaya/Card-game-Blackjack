using BlackJack.Models.Enums;
using System;

namespace BlackJack
{
    class Game
    {
        private Player _player;
        private Player _croupier;
        private ConsiderWinning _considerWinning;

        private Random _random = new Random();
        private Cards[] _cardsDeck = new Cards[52];      

        public Game(string name, double rate)
        {            
            _considerWinning = new ConsiderWinning();
            _player = new Player(name, rate);
            _croupier = new Player("Croupier");
        }

        public double BlackJack()
        {
            FormDeck();
            MixDeck();
            Console.WriteLine(StringHelper.LetPlay);

            while (_player.MoreCard)
            {
                Distribution(_player);
                if (_croupier.NumberOfCards == 0)
                {
                    AddCard(_croupier, true);
                }
            }
            GetResult(_player);
            while (_croupier.SumPoints < 17)
            {
                AddCard(_croupier, true);
            }
            GetResult(_croupier);
            
            var coeficient = _considerWinning.CoeficientWin(_croupier, _player);
            _player.Win = _player.Rate * coeficient;

            PrintResult();
            return _player.Win;
        }

        private void FormDeck()
        {
            int index = 0;
            int k = Enum.GetValues(typeof(CardsSuit)).Length;
            for (int i = 1; i <= k; i++)
            {
                foreach (var j in Enum.GetValues(typeof(CardsName)))
                {
                    _cardsDeck[index] = new Cards() { Suit = (CardsSuit)i, Name = (CardsName)j, IsIssued = false };
                    index++;
                }
            }
        }

        private void MixDeck()
        {
            int i, j;
            Cards temp;
            for (i = 0; i < _cardsDeck.Length; i++)
            {
                j = _random.Next();
                j = j % _cardsDeck.Length;
                temp = _cardsDeck[i];
                _cardsDeck[i] = _cardsDeck[j];
                _cardsDeck[j] = temp;
            }
        }

        private void Distribution(Player player)
        {
            if (player.NumberOfCards != 0)
            {                
                AddCard(player);
                ControlMoreCard(player);
                return;
            }

            Console.WriteLine($"\t{player.Name} player cards:");
            AddCard(player);
            AddCard(player);
            ControlMoreCard(player);
            Console.WriteLine($"The sum of {player.Name} player cards is: {player.SumPoints}\n\n");
        }

        private static void ControlMoreCard(Player player)
        {
            if (!(player.SumPoints < 21))
            {
                player.MoreCard = false;
            }
        }

        private void AddCard(Player player, bool isCroupie = false)
        {
            if (!isCroupie)
            {
                AddCardPlayer(player);
                Console.Write("\n");
                return;
            }

            GetCard(player);
            Console.Write("\n");
        }

        private void AddCardPlayer(Player player)
        {
            if (player.NumberOfCards < 2)
            {
                int j = GetCard(player, false);
                Console.Write(_cardsDeck[j].Suit + " " + _cardsDeck[j].Name);
                return;
            }

            Console.WriteLine($"{player.Name}" + StringHelper.MoreCard);
            string answer = Console.ReadLine();
            if (!(answer.ToLower().ToString() == "y"))
            {
                player.MoreCard = false;
                player.NumberOfCards++;
                return;
            }
            GetCard(player);
        }

        private int GetCard(Player player, bool needComment = true)
        {
            int j = GiveCardIndex();
            player.SumPoints += (int)_cardsDeck[j].Name;
            player.NumberOfCards++;

            if (needComment)
            {
                Console.WriteLine($"{player.Name} card: {_cardsDeck[j].Suit} {_cardsDeck[j].Name}; sum = {player.SumPoints}");
            }
            return j;
        }

        private int GiveCardIndex()
        {
            int i = 0;
            while (i < 100)
            {
                int j = _random.Next(0, 52);

                if (!_cardsDeck[j].IsIssued == true)
                {
                    _cardsDeck[j].IsIssued = true;
                    return j;
                }
                i++;
            }
            return -2;
        }

        private void GetResult(Player player)
        {
            if (player.NumberOfCards < 2 && player.SumPoints == 21)
            {
                player.Result = ResultCombinations.BlackJack;
                return;
            }
            if (player.NumberOfCards >= 2 && player.SumPoints == 21)
            {
                player.Result = ResultCombinations.TwentyOne;
                return;
            }
            if (player.SumPoints > 21)
            {
                player.Result = ResultCombinations.ToMany;
                return;
            }
            player.Result = ResultCombinations.LessTwentyOne;
        }

        public void PrintResult()
        {
            Console.WriteLine("\t\t\t ***");
            Console.WriteLine($"Croupier has {_croupier.Result} and his sum point is {_croupier.SumPoints}");
            Console.WriteLine($"{ _player.Name} -  winnings is {_player.Win} \n" +
                                $"(has {_player.SumPoints}, result is {_player.Result} and {CompareCroupier(_player)})");
            Console.WriteLine("\t\t\t ***");
        }

        public string CompareCroupier(Player player)
        {
            if (player.SumPoints == _croupier.SumPoints)
            {
                return StringHelper.EqualCroupier;
            }
            if (player.SumPoints > _croupier.SumPoints)
            {
                return StringHelper.MoreCroupier;
            }
            return StringHelper.LessCroupier;
        }
    }
}
