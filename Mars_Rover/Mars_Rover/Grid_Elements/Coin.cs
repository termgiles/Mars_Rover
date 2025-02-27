namespace Mars_Rover
{
    public class Coin : IGridElement 
    {
        public static int Count = 0;
        public char Symbol { get; } = 'o';
        public bool IsSolid { get; } = false;
        public int ID { get; } = 0;
        public Coin()
        {
            this.ID = Count + 1;
            Count++;
        }
    }

}
