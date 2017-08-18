using BlackJack.Models.Enums;
using System;

namespace BlackJack
{
    class InitializeGame
    {
        public static void OrderGame()
        {
            string name = "";
            double rate = 0.0;
            InitializePlayer(ref name, ref rate);

            var beginBlackJack = new Game(name, rate);
            var win = beginBlackJack.BlackJack();

            int action = -1;
            while (!(action == (int)ActionWithGame.ExitGame))
            {
                action = NewGame(win);                

                if (action == (int)ActionWithGame.NewPlayer)
                {
                    InitializePlayer(ref name, ref rate);
                    beginBlackJack = new Game(name, rate);
                    win = beginBlackJack.BlackJack();
                }
                if (action == (int)ActionWithGame.NewGame)
                {
                    InitializePlayer(ref name, ref rate, false);
                    beginBlackJack = new Game(name, rate);
                    win = beginBlackJack.BlackJack();
                }
                if (action == (int)ActionWithGame.Countinue)
                {
                    beginBlackJack = new Game(name, win);
                    win = beginBlackJack.BlackJack();
                }
            }
        }

        private static void InitializePlayer(ref string name, ref double rate, bool needName = true)
        {
            if (needName)
            {
                Console.WriteLine(StringHelper.NamePlayer);
                name = Console.ReadLine();
                while (String.IsNullOrEmpty(name))
                {
                    Console.WriteLine(StringHelper.ControlName);
                    name = Console.ReadLine();
                }
            }
            Console.WriteLine(StringHelper.RatePlayer + $" {name} :");
            while (!double.TryParse(Console.ReadLine(), out rate) || rate <= 0)
            {
                Console.WriteLine(StringHelper.ControlRate);
                Console.WriteLine(StringHelper.RatePlayer + $" {name} :");
            }
        }

        private static int NewGame(double winning)
        {
            int answer;
            PrintMenu(winning);

            Console.WriteLine($"NewGame method {winning}");
            int numAction = (winning > 0) ? (int)ActionWithGame.Countinue : (int)ActionWithGame.NewPlayer;
            while (!(int.TryParse(Console.ReadLine(), out answer)))
            {
                PrintMenu(winning);
            }
            if (!(answer >= (int)ActionWithGame.NewGame && answer <= numAction))
            {
                return (int)ActionWithGame.ExitGame;
            }
            return answer;
        }

        private static void PrintMenu(double winning)
        {
            Console.WriteLine(StringHelper.ContinueOrBeginNew);
            if (winning > 0)
            {
                Console.WriteLine(StringHelper.ContinueOrBeginNew2);
            }
        }
    }
}
