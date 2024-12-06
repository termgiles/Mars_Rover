using System.Text;

namespace Mars_Rover
{
    public class Grid 
    {
        public GridSize Size { get; private set; }
        public IGridElement[,] GridArray { get; private set; }
        public Dictionary<IGridElement,List<Position>> ElementHistory { get; private set; } = new Dictionary<IGridElement,List<Position>>();

        private Grid(GridSize size)
        {
            Size = size;
            GridArray = new IGridElement[size.xAxis, size.yAxis];
        }

        public static Grid GenerateGrid(GridSize size, Rover rover, Position roverPosition)
        {
            Grid newGrid = new Grid(size);
            newGrid.GridArray[roverPosition.x, roverPosition.y] = rover;
            rover.Orientation = roverPosition.orientation;
            newGrid.ElementHistory.Add(rover,new List<Position> {roverPosition});
            return newGrid;
        }

        public void InstructRover(List<Instruction> instructions,Rover rover)
        {
            if (!ElementHistory.Keys.Contains(rover))
            {
                throw new Exception("Rover not on grid");
            }
            foreach(Instruction i in instructions)
            {
                if(i == Instruction.L || i == Instruction.R)
                {
                    rover.Rotate(i);
                }
                if(i == Instruction.M)
                {
                    if (RequestMove(rover))
                    {
                        //UI increment coin score
                        if (rover.Orientation == Compass.N || rover.Orientation == Compass.S)
                            GridArray[(ElementHistory[rover][^2].x), (ElementHistory[rover][^2].y)] = new VerticalTrack();
                        if (rover.Orientation == Compass.E || rover.Orientation == Compass.W)
                            GridArray[(ElementHistory[rover][^2].x), (ElementHistory[rover][^2].y)] = new HorizontalTrack();
                    }
                    if (!RequestMove(rover))
                    {
                        Console.WriteLine($"Rover {rover.Name} crashed at {ElementHistory[rover][^1].x} {ElementHistory[rover][^1].y}");
                    }
                }
            }
        }
        

        public bool RequestMove(Rover rover)
        {
            Position currentPosition = ElementHistory[rover][^1];
            Compass currentOrientation = rover.Orientation;
            Position newPosition = new Position();
            if (rover.Orientation == Compass.N)
            {
                newPosition.x = currentPosition.x;
                newPosition.y = currentPosition.y + 1;
            }
            if (rover.Orientation == Compass.E)
            {
                newPosition.x = currentPosition.x + 1;
                newPosition.y = currentPosition.y;
            }
            if (rover.Orientation == Compass.S)
            {
                newPosition.x = currentPosition.x;
                newPosition.y = currentPosition.y - 1;
            }
            if (rover.Orientation == Compass.W)
            {
                newPosition.x = currentPosition.x - 1;
                newPosition.y = currentPosition.y;
            }
            if (newPosition.x < 0 || newPosition.x >= this.Size.xAxis) return false;
            if (newPosition.y < 0 || newPosition.y >= this.Size.yAxis) return false;
            if (this.GridArray[newPosition.x, newPosition.y] != null && this.GridArray[newPosition.x, newPosition.y].IsSolid) return false;
            this.ElementHistory[rover].Add(newPosition);
            this.GridArray[newPosition.x, newPosition.y] = rover;
            this.GridArray[currentPosition.x, currentPosition.y] = null;
            return true;
        }

        public string Display(bool? Write)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Size.xAxis + 4; i++)
            {
                sb.Append('=');
            }
                sb.Append("\n");
            for (int i = this.Size.yAxis -1; i >= 0; i--)
            {
                sb.Append("||");
                for (int j = 0; j < this.Size.xAxis; j++)
                {
                    if ((this.GridArray[j, i]) == null)
                    {
                        sb.Append(' ');
                    }
                    else
                    {
                        sb.Append(this.GridArray[j, i].Symbol);
                    }
                }
                sb.Append("||");
                sb.Append("\n");
            }
            for (int i = 0; i < this.Size.xAxis + 4; i++)
            {
                sb.Append('=');
            }
                sb.Append("\n");

            if (Write == true) Console.Write(sb.ToString());
            return sb.ToString();
        }
    }

}
