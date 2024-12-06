namespace Mars_Rover
{
    public class HorizontalTrack : IGridElement
    {
        public static int Count = 0;
        public char Symbol { get; } = '-';
        public bool IsSolid { get; } = false;
        public int ID { get; } = 0;
        public HorizontalTrack()
        {
            this.ID = Count + 1;
            Count++;
        }
    }

}
