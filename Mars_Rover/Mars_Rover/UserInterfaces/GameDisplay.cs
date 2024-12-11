namespace Mars_Rover
{
    public class GameDisplay : UserInterface
    {
        public Grid liveGrid { get; private set; }
        public override Transition Run()
        {
            Console.WriteLine("Enter a grid size in the format: ## ##");
            string userGridSize = Console.ReadLine();
            Console.WriteLine("Name your rover:");
            string userRoverName = Console.ReadLine();
            Console.WriteLine("Chose a starting position on the grid in the format ## ## D, where D is the starting direction, either : N,E,S,W:");
            string userStartingPositin = Console.ReadLine();
            Rover rover = new Rover(userRoverName, Compass.N);
            GridSize gridSize = InputParser.StringToGridSize(userGridSize);
            Position startingPosition = InputParser.ParseRoverStartingPosition(userStartingPositin);
            this.liveGrid = Grid.GenerateGrid(gridSize, rover, startingPosition);
            liveGrid.Display(true);
            Console.WriteLine("Enter a string to move or 2 for main menu, 3 to quit:");
            //set up while loop here
            return Transition.MAIN_MENU;       //add
        }
    }
}
