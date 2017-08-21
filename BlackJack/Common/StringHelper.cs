namespace BlackJack
{
    static class StringHelper
    {      
        public const string NamePlayer = "Enter the name of the player";
        public const string RatePlayer = "Enter the rate of the player";
        public const string ControlName = "Please enter the correct name (empty string is not allowed)";
        public const string ControlRate = "The rate must be a numeric and more than 0";
        public const string LetPlay = "Let's play!!!\n";

        public const string MoreCard = " , do  you need a new card? (Y/N)";
      
        public const string MoreCroupier = "More than croupier has";
        public const string LessCroupier = "Less than croupier has";
        public const string EqualCroupier = "Equals with croupier";
        
        public const string ContinueOrBeginNew = "\n*** Press 1 - to begin new game (previous player)\n"
                           + "*** Press 2 - to exit game\n"
                           + "*** Press 3 - to change player";
        public const string ContinueOrBeginNew2 = "*** Press 4 - to continue playing (Previous player and the rate is equal to the winnings) ?";

    }
}
