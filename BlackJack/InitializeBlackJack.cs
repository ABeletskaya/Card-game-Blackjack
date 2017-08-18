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
            Dictionary<string, int> players = new Dictionary<string, int>();
            int playersNumber = 0;

            Console.WriteLine(StringHelper.NumberPlayers);
            if (!int.TryParse(Console.ReadLine(), out playersNumber))
            {
                Console.WriteLine(StringHelper.ControlPlayers);
                BeginGame();
            }

            if (!(playersNumber > 0 && playersNumber <= 7))
            {
                Console.WriteLine(StringHelper.ControlPlayers);
                if (!NewGame())
                {
                    return;
                }
                BeginGame();
            }
            string name;
            int rate;
            for (int i = 0; i < playersNumber; i++)
            {
                Console.WriteLine(StringHelper.NamePlayer + $" {i + 1} :");
                InitializePlayer(out name, out rate);
                players.Add(name, rate);
            }

            var beginBlackJack = new Game(players);
            beginBlackJack.BlackJack();
        }

        private static void InitializePlayer( out string name, out int rate)
        {
            name = Console.ReadLine();
            while (String.IsNullOrEmpty(name))
            {
                Console.WriteLine(StringHelper.ControlName);
                name = Console.ReadLine();
            }

            Console.WriteLine(StringHelper.RatePlayer + $" {name} :");           
            while (!int.TryParse(Console.ReadLine(), out rate) || rate <= 0)
            {
                Console.WriteLine(StringHelper.ControlRate);
                Console.WriteLine(StringHelper.RatePlayer + $" {name} :");
            }
        }
    

    public static bool NewGame()
        {
            Console.WriteLine(StringHelper.ToContinuePlaying);
            string answer = Console.ReadLine();

            return answer.ToLower().ToString() == "y";
        }
    }
}
