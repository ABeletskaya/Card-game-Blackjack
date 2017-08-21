using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Models.Enums
{
    public enum ResultCombinations
    {
        [Description("Blackjack")]
        BlackJack = 1,
        [Description("Twenty one")]
        TwentyOne = 2,
        [Description("Less points than Twenty one")]
        LessTwentyOne = 3,
        [Description("To many...")]
        ToMany = 4
    }
}    
