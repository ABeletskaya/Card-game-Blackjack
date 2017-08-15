using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Game
    {
        private Player _croupier;
        private List<Player> _players = new List<Player>();
        private int _playersCount;

        private Random _random = new Random();
        private Cards[] _cardsDeck = new Cards[52];

        public Game(Dictionary<string, int> _playersDictionary)
        {
            _playersCount = _playersDictionary.Count();
            foreach (var player in _playersDictionary)
            {
                if (player.Key.Length == 0)
                {
                    return;
                }
                _players.Add(new Player(player.Key, player.Value));
            }
            _croupier = new Player("Croupier");
        }

        public void BlackJack()
        {
            FormDeck(); 
            MixDeck();
            Console.WriteLine("\n");

            while (NeedMoreCard())
            {
                for (int k = 0; k < _playersCount; k++)
                {
                    if (_players[k].MoreCard)
                    {
                        Distribution(_players[k]);
                    }
                }
                if (_croupier.NumberOfCards == 0)
                {
                    AddCard(_croupier, true);
                }
            }
            while (_croupier.SumPoints < 17)
            {
                AddCard(_croupier, true);
            }

            foreach (var player in _players)
            {
                GetResult(player);
            }
            GetResult(_croupier);
            PrintResult();
        }

        private bool NeedMoreCard()
        {
            if (_players.Any(p => p.MoreCard == true))
            {
                return true;
            }
            return false;
        }

        private void FormDeck()
        {
            int index = 0;
            int k = Enum.GetValues(typeof(CardsSuit)).Length;
            for (int i = 1 ; i <= k; i++)
            {
                foreach (var j in Enum.GetValues(typeof(CardsName)))
                {
                    _cardsDeck[index] = new Cards() { suit = (CardsSuit)i, name = (CardsName)j, isIssued = false };
                    index++;
                }
            }
        }

        private void MixDeck() // Перемешиваем колоду
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
            if (player.NumberOfCards == 0) 
            {
                Console.WriteLine($"\t{player.Name} player cards:");
                AddCard(player);
                AddCard(player);
                Console.WriteLine($"The sum of {player.Name} player cards is: {player.SumPoints}\n\n");
                return;
            }
            AddCard(player);

            if (! (player.SumPoints < 21))
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
                Console.Write(_cardsDeck[j].suit + " " + _cardsDeck[j].name);
                return;
            }

            Console.WriteLine($"{player.Name}" + ResponsesHelper.MoreCard);
            string answer = Console.ReadLine();
            if ( ! (answer == "Y" || answer == "y"))
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
            player.SumPoints += (int)_cardsDeck[j].name;
            player.NumberOfCards++;

            if (needComment)
                Console.WriteLine($"{player.Name} card: {_cardsDeck[j].suit} {_cardsDeck[j].name}; sum = {player.SumPoints}");

            return j;
        }

        private int GiveCardIndex() 
        {
            int i = 0;
            while (i < 100)
            {
               int  j = _random.Next(0, 36);

                if (! _cardsDeck[j].isIssued == true)
                {
                    _cardsDeck[j].isIssued = true;
                    return j;
                }
                i++;
            }
            return -2;
        }

        private void GetResult(Player player)
        {
            if (player.NumberOfCards == 2 && player.SumPoints == 21)
            {
                player.Result = Result.blackJack;
            }
            if (player.NumberOfCards != 2 && player.SumPoints == 21)
            {
                player.Result = Result.twentyOne;
            }
            if (player.SumPoints > 21)
            {
                player.Result = Result.toMany;
            }
            if (player.SumPoints < 21)
            {
                player.Result = Result.lessTwentyOne;
            }
        }

        public void PrintResult()
        {
            double coeficient = -1.0;
            string compare = "";
            Console.WriteLine("\n");
            Console.WriteLine($"Croupier has {_croupier.Result} and his sum point is {_croupier.SumPoints}");
            ConsiderWinning considerWinning = new ConsiderWinning();
            foreach (var player in _players)
            {             
                coeficient = considerWinning.CoeficientWin(_croupier, player);
                compare = compareCroupier(player);
                Console.WriteLine($"{ player.Name} -  winnings is {player.Rate * 2 * coeficient} \n"+
                                   $"(has {player.SumPoints}, result is {player.Result} and {compare})");
            }
        } 
        
        public string compareCroupier(Player player)
        {
            if (player.SumPoints == _croupier.SumPoints)
            {
                return Result.equalCroupier;
            }
            if (player.SumPoints > _croupier.SumPoints)
            {
                return Result.moreCroupier;
            }
            if (player.SumPoints < _croupier.SumPoints)
            {
                return Result.lessCroupier;
            }
            return "";
        }
    }
}
