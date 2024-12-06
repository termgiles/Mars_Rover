using System.Text.RegularExpressions;

namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = InputParser.StringToGridSize("60 20");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("15 6 W");
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            testGrid.Display(true);

        }
    }
}
