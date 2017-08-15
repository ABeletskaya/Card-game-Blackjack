using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class ConsiderWinning
    {    

       private static object[,] _variant = new object[16, 3];

        static ConsiderWinning()
        {
            _variant[0, 0] = "Croupier result";
            _variant[0, 1] = "Player result";
            _variant[0, 2] = "Coeficient";

            _variant[1, 0] = Result.BlackJack;
            _variant[1, 1] = Result.BlackJack;
            _variant[1, 2] = CoeficientDouble.AtTheir;

            _variant[2, 0] = Result.BlackJack;
            _variant[2, 1] = Result.TwentyOne;
            _variant[2, 2] = CoeficientDouble.Loss;

            _variant[3, 0] = Result.BlackJack;
            _variant[3, 1] = Result.ToMany;
            _variant[3, 2] = CoeficientDouble.Loss;

            _variant[4, 0] = Result.BlackJack;
            _variant[4, 1] = Result.LessTwentyOne;
            _variant[4, 2] = CoeficientDouble.Loss;


            _variant[5, 0] = Result.TwentyOne;
            _variant[5, 1] = Result.BlackJack;
            _variant[5, 2] = CoeficientDouble.BlackJack;

            _variant[6, 0] = Result.TwentyOne;
            _variant[6, 1] = Result.TwentyOne;
            _variant[6, 2] = CoeficientDouble.AtTheir;

            _variant[7, 0] = Result.TwentyOne;
            _variant[7, 1] = Result.ToMany;
            _variant[7, 2] = CoeficientDouble.Loss;

            _variant[8, 0] = Result.TwentyOne;
            _variant[8, 1] = Result.LessTwentyOne;
            _variant[8, 2] = CoeficientDouble.Loss;


            _variant[9, 0] = Result.ToMany;
            _variant[9, 1] = Result.BlackJack;
            _variant[9, 2] = CoeficientDouble.BlackJack;

            _variant[10, 0] = Result.ToMany;
            _variant[10, 1] = Result.TwentyOne;
            _variant[10, 2] = CoeficientDouble.Win;

            _variant[11, 0] = Result.ToMany;
            _variant[11, 1] = Result.ToMany;
            _variant[11, 2] = CoeficientDouble.Loss;

            _variant[12, 0] = Result.ToMany;
            _variant[12, 1] = Result.LessTwentyOne;
            _variant[12, 2] = CoeficientDouble.Win;


            _variant[13, 0] = Result.LessTwentyOne;
            _variant[13, 1] = Result.BlackJack;
            _variant[13, 2] = CoeficientDouble.BlackJack;

            _variant[14, 0] = Result.LessTwentyOne;
            _variant[14, 1] = Result.TwentyOne;
            _variant[14, 2] = CoeficientDouble.Win;

            _variant[15, 0] = Result.LessTwentyOne;
            _variant[15, 1] = Result.ToMany;
            _variant[15, 2] = CoeficientDouble.Loss;
        }

        public double CoeficientWin(Player croupier, Player player)
        {
            if (croupier.Result == Result.LessTwentyOne && player.Result == Result.LessTwentyOne)
            {
                return ((croupier.SumPoints < player.SumPoints) ? (int)CoeficientDouble.Win : (int)CoeficientDouble.Loss) / 2.0;
            }
            for (int i = 1; i < _variant.Length; i++)
            {
                if ((string)_variant[i, 0] == croupier.Result && (string)_variant[i, 1] == player.Result)
                    return (int)_variant[i, 2] / 2.0;
            }
            return 0.0;
        }
    }
}
