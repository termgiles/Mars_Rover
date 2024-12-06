namespace Mars_Rover
{
    public class Rover : IGridElement
    {
        public string Name { get; private set; }
        public bool IsSolid { get; private set; } = true;
        public char Symbol { get; private set; }
        public Compass Orientation { get; set; }
        public List<Compass> History { get; private set; }

        public Rover(string name, Compass orientation)
        {
            this.Name = name;
            this.Orientation = orientation;
            this.Symbol = char.ToUpper(name[0]);
        }

    }
}
