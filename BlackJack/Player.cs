using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        public string Name { get; set; }
        public int Rate { get; set; }        
        public int SumPoints { get; set; }
        public int NumberOfCards { get; set; }        
        public bool MoreCard { get; set; }

        public string Result { get; set; }

        public Player(string name)
        {
            Name = name;
            Rate = 0;
            SumPoints = 0;
            NumberOfCards = 0;
            MoreCard = true;
            Result = null;              
        }

        public Player(string name, int rate)
        {
            Name = name;
            Rate = rate;
            SumPoints = 0;
            NumberOfCards = 0;
            MoreCard = true;
            Result = null;
        }         
    }
}
