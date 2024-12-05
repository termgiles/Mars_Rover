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

        public Grid GenerateGrid(GridSize size, Rover rover, Position roverPosition)
        {
            Grid newGrid = new Grid(size);
            newGrid.GridArray[roverPosition.x, roverPosition.y] = rover;
            return newGrid;
        }
    }

}
