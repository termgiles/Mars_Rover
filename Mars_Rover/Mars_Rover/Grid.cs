using System.Text;

namespace Mars_Rover
{
    public class Grid 
    {
        public GridSize Size { get; private set; }
        public IGridElement[,] GridArray { get; private set; }
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
            return newGrid;
        }

        public string Display(bool? Write)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Size.xAxis + 4; i++)
            {
                sb.Append('=');
            }
                sb.Append("\n");
            for (int i = 0; i < this.Size.yAxis; i++)
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
