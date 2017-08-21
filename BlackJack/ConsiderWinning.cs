using BlackJack.Models.Enums;
using System;
using System.Collections.Generic;

namespace BlackJack
{
    class ConsiderWinning
    {
        private static Dictionary<Tuple<ResultCombinations, ResultCombinations>, int> _coefficientsAndResults;

        static ConsiderWinning()
        {
            _coefficientsAndResults = new Dictionary<Tuple<ResultCombinations, ResultCombinations>, int>();

            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.BlackJack, ResultCombinations.BlackJack), (int)CoeficientDouble.AtTheir);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.BlackJack, ResultCombinations.TwentyOne), (int)CoeficientDouble.Loss);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.BlackJack, ResultCombinations.ToMany), (int)CoeficientDouble.Loss);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.BlackJack, ResultCombinations.LessTwentyOne), (int)CoeficientDouble.Loss);

            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.TwentyOne, ResultCombinations.BlackJack), (int)CoeficientDouble.BlackJack);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.TwentyOne, ResultCombinations.TwentyOne), (int)CoeficientDouble.AtTheir);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.TwentyOne, ResultCombinations.ToMany), (int)CoeficientDouble.Loss);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.TwentyOne, ResultCombinations.LessTwentyOne), (int)CoeficientDouble.Loss);

            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.ToMany, ResultCombinations.BlackJack), (int)CoeficientDouble.BlackJack);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.ToMany, ResultCombinations.TwentyOne), (int)CoeficientDouble.Win);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.ToMany, ResultCombinations.ToMany), (int)CoeficientDouble.Loss);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.ToMany, ResultCombinations.LessTwentyOne), (int)CoeficientDouble.Win);

            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.LessTwentyOne, ResultCombinations.BlackJack), (int)CoeficientDouble.BlackJack);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.LessTwentyOne, ResultCombinations.TwentyOne), (int)CoeficientDouble.Win);
            _coefficientsAndResults.Add(new Tuple<ResultCombinations, ResultCombinations>(ResultCombinations.LessTwentyOne, ResultCombinations.ToMany), (int)CoeficientDouble.Loss);
        }

        public int CoeficientWin(Player croupier, Player player)
        {
            if (croupier.Result == ResultCombinations.LessTwentyOne && player.Result == ResultCombinations.LessTwentyOne)
            {
                return (croupier.SumPoints < player.SumPoints) ? (int)CoeficientDouble.Win : (int)CoeficientDouble.Loss;
            }

            int coeficient;
            if (_coefficientsAndResults.TryGetValue(new Tuple<ResultCombinations, ResultCombinations>(croupier.Result, player.Result), out coeficient))
            {
                return coeficient;
            }

            Console.WriteLine($"Key ={croupier.Result}, {player.Result} is not found.");
            return 0;
        }
    }
}
