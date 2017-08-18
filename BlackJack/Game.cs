using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Game
    {
        private Player _player;
        private Player _croupier;
        
        private Random _random = new Random();
        private Cards[] _cardsDeck = new Cards[52];

        private ConsiderWinning considerWinning;

        public Game(string name, double rate)
        {
            considerWinning = new ConsiderWinning();

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
            var coeficient = considerWinning.CoeficientWin(_croupier, _player);
            _player.Win = _player.Rate * 2 * coeficient;
            PrintResult();
            return _player.Win;
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
            if (player.NumberOfCards == 0)
            {
                Console.WriteLine($"\t{player.Name} player cards:");
                AddCard(player);
                AddCard(player);
                ControlMoreCard(player);
                Console.WriteLine($"The sum of {player.Name} player cards is: {player.SumPoints}\n\n");
                return;
            }
            AddCard(player);
            ControlMoreCard(player);
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
                Console.Write(_cardsDeck[j].suit + " " + _cardsDeck[j].name);
                return;
            }

            Console.WriteLine($"{player.Name}" + StringHelper.MoreCard);
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
                player.Result = StringHelper.BlackJack;
            }
            if (player.NumberOfCards != 2 && player.SumPoints == 21)
            {
                player.Result = StringHelper.TwentyOne;
            }
            if (player.SumPoints > 21)
            {
                player.Result = StringHelper.ToMany;
            }
            if (player.SumPoints < 21)
            {
                player.Result = StringHelper.LessTwentyOne;
            }
        }

        public void PrintResult()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"Croupier has {_croupier.Result} and his sum point is {_croupier.SumPoints}");
            Console.WriteLine($"{ _player.Name} -  winnings is {_player.Win} \n" +
                                          $"(has {_player.SumPoints}, result is {_player.Result} and {compareCroupier(_player)})");
        }

        public string compareCroupier(Player player)
        {
            if (player.SumPoints == _croupier.SumPoints)
            {
                return StringHelper.EqualCroupier;
            }
            if (player.SumPoints > _croupier.SumPoints)
            {
                return StringHelper.MoreCroupier;
            }
            if (player.SumPoints < _croupier.SumPoints)
            {
                return StringHelper.LessCroupier;
            }
            return "";
        }
    }
}
