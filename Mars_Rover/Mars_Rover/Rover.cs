namespace Mars_Rover
{
    public class Rover : //IGridElement?
    {
        public string Name { get; private set; }
        public Compass Orientation { get; set; }
        public List<Compass> History { get; private set; }

        public Rover(string name, Compass orientation)
        {
            this.Name = name;
            this.Orientation = orientation;
        }

    }
}
