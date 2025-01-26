namespace Mars_Rover
{
    public class GameDisplay : UserInterface
    {
        public Grid liveGrid { get; private set; }
        public override Transition Run()
        {
            Transition nextState = Transition.DISPLAY;


            Console.WriteLine("Enter a grid size in the format: ## ##");
            string userGridSize = Console.ReadLine();

            Console.WriteLine("Name your rover:");
            string userRoverName = Console.ReadLine();


            bool stillParsing = true;
            Position startingPosition = new Position();
            while (stillParsing)
            {
                try
                {
                    Console.WriteLine("Chose a starting position on the grid in the format ## ## D; 'D' is an optional starting direction, either : N,E,S,W: the default is N");
                    string userStartingPosition = Console.ReadLine();
                    startingPosition = InputParser.ParseRoverStartingPosition(userStartingPosition);
                    stillParsing = false;
                }
                catch (Exception ex)
                {
                    {
                        Console.WriteLine($"{ex.Message} \n try entering coordinates again");
                    }
                }
            }

            Rover rover = new Rover(userRoverName, Compass.N);
            GridSize gridSize = InputParser.StringToGridSize(userGridSize);
            

            this.liveGrid = Grid.GenerateGrid(gridSize, rover, startingPosition);
            this.liveGrid.SeedRocks(75);

            bool isExited = false;
            while (!isExited)
            {
                liveGrid.Display(true);
                Console.WriteLine("Enter a string to move (LRMM = Left Right Move Move) or 2 for main menu, 3 to quit:");
                try
                {
                    string userInput = Console.ReadLine();
                    if (userInput == "3")
                    {
                        nextState = Transition.QUIT;
                        isExited = true;
                        break;
                    }
                    if (userInput == "2")
                    {
                        isExited = true;
                        nextState = Transition.SETTINGS;
                        break;
                    }
                    liveGrid.InstructRover(InputParser.ParseInstruction(userInput), rover);
                }
                catch
                {
                    Console.WriteLine("enter another input");
                }
            }
            //set up while loop here
            return nextState;       //add
        }
    }
}
