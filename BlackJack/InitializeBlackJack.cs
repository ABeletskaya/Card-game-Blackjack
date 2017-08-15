using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public static class InitializeBlackJack
    {
        public static void BeginGame()
        {
            Dictionary<string, int> _players = new Dictionary<string, int>();
            int _playersNumber = 0;

            Console.WriteLine(ResponsesHelper.NumberPlayers);
            if (! int.TryParse(Console.ReadLine(), out _playersNumber))
            {
                Console.WriteLine(ResponsesHelper.ControlPlayers);
                BeginGame();
            }

            if ( ! (_playersNumber > 0 && _playersNumber <= 7))
            {
                Console.WriteLine(ResponsesHelper.ControlPlayers);
                if (!NewGame())
                {
                    return;
                }
                BeginGame();
            }

            string name;
            int rate;
            for (int i = 0; i < _playersNumber; i++)
            {
                Console.WriteLine(ResponsesHelper.NamePlayer + $" {i + 1} :");
                name = Console.ReadLine();
                Console.WriteLine(ResponsesHelper.RatePlayer + $" {name} :");
                while (!int.TryParse(Console.ReadLine(), out rate))
                {
                    Console.WriteLine(ResponsesHelper.ControlRate);
                    Console.WriteLine(ResponsesHelper.RatePlayer + $" {name} :");
                }
                _players.Add(name, rate);
            }

            var BeginBlackJack = new Game(_players);
            BeginBlackJack.BlackJack();
        }

        public static bool NewGame()
        {
            Console.WriteLine(ResponsesHelper.ToContinuePlaying);
            string answer = Console.ReadLine();

            if (!(answer == "Y" || answer == "y"))
            {
                return false;
            }
            return true;
        }
    }
}
