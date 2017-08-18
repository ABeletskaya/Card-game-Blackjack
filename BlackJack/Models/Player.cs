namespace BlackJack
{
    class Player
    {
        public string Name { get; set; }
        public double Rate { get; set; }  
        public double Win { get; set; }      
        public int SumPoints { get; set; }
        public int NumberOfCards { get; set; }        
        public bool MoreCard { get; set; }

        public string Result { get; set; }

        public Player(string name)
        {
            Name = name;
            Rate = 0;
            Win = 0;
            SumPoints = 0;
            NumberOfCards = 0;
            MoreCard = true;
            Result = null;              
        }

        public Player(string name, double rate)
        {
            Name = name;
            Rate = rate;
            Win = 0;
            SumPoints = 0;
            NumberOfCards = 0;
            MoreCard = true;
            Result = null;
        }         
    }
}
