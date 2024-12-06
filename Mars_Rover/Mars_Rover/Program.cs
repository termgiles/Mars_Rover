using System.Text.RegularExpressions;

namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Rover testRover = new Rover("testRover", Compass.N);
            GridSize testSize = InputParser.StringToGridSize("80 30");
            Position testStartingPosition = InputParser.ParseRoverStartingPosition("4 6 N");
            Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            testGrid.Display(true);
            testGrid.InstructRover(InputParser.ParseInstruction("MMMMMMRMRMMMMLMMMRMMLMMLMMMMMMRMMMLLMMMLMMLMMLLMMLMMMLMMMMMMMLMMMMMMLLMMMMMMLMMMMMLMMM"),testRover);
            testGrid.Display(true);


        }
    }
}
