using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class ConsiderWinning
    {    

        static object[,] variant = new object[16, 3];

        static ConsiderWinning()
        {
            variant[0, 0] = "Croupier result";
            variant[0, 1] = "Player result";
            variant[0, 2] = "Coeficient";

            variant[1, 0] = Result.blackJack;
            variant[1, 1] = Result.blackJack;
            variant[1, 2] = CoeficientDouble.AtTheir;

            variant[2, 0] = Result.blackJack;
            variant[2, 1] = Result.twentyOne;
            variant[2, 2] = CoeficientDouble.Loss;

            variant[3, 0] = Result.blackJack;
            variant[3, 1] = Result.toMany;
            variant[3, 2] = CoeficientDouble.Loss;

            variant[4, 0] = Result.blackJack;
            variant[4, 1] = Result.lessTwentyOne;
            variant[4, 2] = CoeficientDouble.Loss;


            variant[5, 0] = Result.twentyOne;
            variant[5, 1] = Result.blackJack;
            variant[5, 2] = CoeficientDouble.BlackJack;

            variant[6, 0] = Result.twentyOne;
            variant[6, 1] = Result.twentyOne;
            variant[6, 2] = CoeficientDouble.AtTheir;

            variant[7, 0] = Result.twentyOne;
            variant[7, 1] = Result.toMany;
            variant[7, 2] = CoeficientDouble.Loss;

            variant[8, 0] = Result.twentyOne;
            variant[8, 1] = Result.lessTwentyOne;
            variant[8, 2] = CoeficientDouble.Loss;


            variant[9, 0] = Result.toMany;
            variant[9, 1] = Result.blackJack;
            variant[9, 2] = CoeficientDouble.BlackJack;

            variant[10, 0] = Result.toMany;
            variant[10, 1] = Result.twentyOne;
            variant[10, 2] = CoeficientDouble.Win;

            variant[11, 0] = Result.toMany;
            variant[11, 1] = Result.toMany;
            variant[11, 2] = CoeficientDouble.Loss;

            variant[12, 0] = Result.toMany;
            variant[12, 1] = Result.lessTwentyOne;
            variant[12, 2] = CoeficientDouble.Win;


            variant[13, 0] = Result.lessTwentyOne;
            variant[13, 1] = Result.blackJack;
            variant[13, 2] = CoeficientDouble.BlackJack;

            variant[14, 0] = Result.lessTwentyOne;
            variant[14, 1] = Result.twentyOne;
            variant[14, 2] = CoeficientDouble.Win;

            variant[15, 0] = Result.lessTwentyOne;
            variant[15, 1] = Result.toMany;
            variant[15, 2] = CoeficientDouble.Loss;
        }

        public double CoeficientWin(Player croupier, Player player)
        {
            if (croupier.Result == Result.lessTwentyOne && player.Result == Result.lessTwentyOne)
            {
                return ((croupier.SumPoints < player.SumPoints) ? (int)CoeficientDouble.Win : (int)CoeficientDouble.Loss) / 2.0;
            }
            for (int i = 1; i < variant.Length; i++)
            {
                if ((string)variant[i, 0] == croupier.Result && (string)variant[i, 1] == player.Result)
                    return (int)variant[i, 2] / 2.0;
            }
            return 0.0;
        }
    }
}
