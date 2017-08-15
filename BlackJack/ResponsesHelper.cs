using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    static class ResponsesHelper
    {
        public const string NumberPlayers = "Enter the number of players:";
        public const string ControlPlayers = "The number of players must be greater than 0 and less than 8.";
        public const string NamePlayer = "Enter the name of the player";
        public const string RatePlayer = "Enter the rate of the player";
        public const string ControlRate = "The rate must be a numeric";
        public const string ToContinuePlaying = "\n\t\t*** Do you want to continue playing ? (Y/N) ***";

        public const string MoreCard = " , do  you need a new card? (Y/N)";
    }
}
