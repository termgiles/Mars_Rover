namespace Mars_Rover
{
    public class Enemy : IGridElement
    {
        public bool IsSolid { get; private set; } = true;
        public char Symbol { get; } = '@';
        public Compass Orientation { get; set; }
        public void Rotate(Instruction d)
        {
            if (d == Instruction.R) Orientation = (Compass)(((int)Orientation + 1) % 4);
            if (d == Instruction.L) Orientation = (Compass)(((int)Orientation + 3) % 4);
        }
    }
}
