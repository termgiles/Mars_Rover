namespace Mars_Rover
{
    public class Enemy : IGridCharacter
    {
        public bool IsSolid { get; private set; } = true;
        public char Symbol { get; } = '@';
        public Compass Orientation { get; set; }

        public Enemy(Compass orientation)
        {
            this.Orientation = orientation;
        }
        public void Rotate(Instruction d)
        {
            if (d == Instruction.R) Orientation = (Compass)(((int)Orientation + 1) % 4);
            if (d == Instruction.L) Orientation = (Compass)(((int)Orientation + 3) % 4);
        }
    }
}

//REFACTOR methods for requesting moves and landing character
//Add Dijkstra's to (enemy? grid?)
//Work backwards from rover to enemey
//decide how often it should update