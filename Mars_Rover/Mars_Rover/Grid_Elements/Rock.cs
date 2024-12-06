namespace Mars_Rover
{
    public class Rock : IGridElement
    {
        public static int Count = 0;
        public char Symbol { get; } = '*';
        public bool IsSolid { get; } = true;
        public int ID { get; } = 0;
        public Rock() 
        {
            this.ID = Count + 1;
            Count++;
        }

    }

}
