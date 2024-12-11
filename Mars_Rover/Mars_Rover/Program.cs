using Mars_Rover;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Mars_Rover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LoadingScreen loadingScreen = new LoadingScreen();
            //loadingScreen.Run();
            //Console.WriteLine("Hello, World!");
            //Rover testRover = new Rover("testRover", Compass.N);
            //GridSize testSize = InputParser.StringToGridSize("30 20");
            //Position testStartingPosition = InputParser.ParseRoverStartingPosition("1 2 N");
            //Grid testGrid = Grid.GenerateGrid(testSize, testRover, testStartingPosition);
            //testGrid.Display(true);
            //testGrid.InstructRover(InputParser.ParseInstruction("LMLMLMLMM"),testRover);
            //testGrid.Display(true);
            //Rover testRover2 = new Rover("secondTestRover", Compass.E);
            //Position testSecondPosition = InputParser.ParseRoverStartingPosition("3 3 E");
            //testGrid.LandRover(testRover2, testSecondPosition);
            //testGrid.InstructRover(InputParser.ParseInstruction("MMRMMRMRRM"),testRover2);
            //testGrid.Display(true);

            //LoadingScreen testLoadingScreen = new LoadingScreen();
            //string printnext = testLoadingScreen.Run();
            //Console.WriteLine(printnext);

            LoadingScreen testLoading = new LoadingScreen();
            MainMenu testMainMenu = new MainMenu();
            Settings testSettings = new Settings();
            GameDisplay display = new GameDisplay();    


            StateManager Handler = new StateManager(testLoading, testMainMenu, testSettings,display);
            
            while(Handler.GetState().GetType().ToString() != "Quit")
            {
                Handler.Run();
            }

        }
    }
}
