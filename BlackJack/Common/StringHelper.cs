namespace BlackJack
{
    static class StringHelper
    {
        public const string NumberPlayers = "Enter the number of players:";
        public const string ControlPlayers = "The number of players must be greater than 0 and less than 8.";
        public const string NamePlayer = "Enter the name of the player";
        public const string RatePlayer = "Enter the rate of the player";
        public const string ControlName = "Please enter the correct name (empty string is not allowed)";
        public const string ControlRate = "The rate must be a numeric and more than 0";
        public const string ToContinuePlaying = "\n\t\t*** Do you want to continue playing ? (Y/N) ***";
        public const string ContinueOrBeginNew = "\n*** Press 1 - to begin new game (previous player) ***\n"
                            + "*** Press 2 - to exit game\n"
                            + "*** Press 3 - to change player\n";
        public const string ContinueOrBeginNew2 = "*** Press 4 - to continue playing (Previous player and the rate is equal to the winnings) ?";

        public const string MoreCard = " , do  you need a new card? (Y/N)";

        public const string BlackJack = "Blackjack";
        public const string TwentyOne = "Twenty one";
        public const string LessTwentyOne = "Less points than Twenty one";
        public const string ToMany = "To many...";

        public const string MoreCroupier = "More than croupier has";
        public const string LessCroupier = "Less than croupier has";
        public const string EqualCroupier = "Equals with croupier";

        public const string LetPlay = "Let's play!!!\n";
    }
}
