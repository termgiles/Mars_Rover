namespace Mars_Rover
{
    public class GameDisplay : UserInterface
    {
        public Grid liveGrid { get; private set; }
        public override Transition Run()
        {
            Transition nextState = Transition.DISPLAY;

            GridSize gridSize = new GridSize(0, 0);
            bool stillPartsingSize = true;
            while (stillPartsingSize)
            {
                try
                {
                    Console.WriteLine("Enter a grid size in the format: ## ##");
                    string userGridSize = Console.ReadLine();
                    gridSize = InputParser.StringToGridSize(userGridSize);
                    stillPartsingSize = false;
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"{ex.Message} \n try entering a gridsize again");
                }
            }

            Console.WriteLine("Name your rover:");
            string userRoverName = Console.ReadLine();


            bool stillParsingPosition = true;
            Position startingPosition = new Position();
            while (stillParsingPosition)
            {
                try
                {
                    Console.WriteLine("Chose a starting position on the grid in the format ## ## D; 'D' is an optional starting direction, either : N,E,S,W: the default is N");
                    string userStartingPosition = Console.ReadLine();
                    startingPosition = InputParser.ParseRoverStartingPosition(userStartingPosition);
                    stillParsingPosition = false;
                }
                catch (Exception ex)
                {
                    {
                        Console.WriteLine($"{ex.Message} \n try entering coordinates again");
                    }
                }
            }

            Rover rover = new Rover(userRoverName, startingPosition.orientation);
            

            this.liveGrid = Grid.GenerateGrid(gridSize, rover, startingPosition);
            this.liveGrid.Seeder.SeedBorder(60);
            this.liveGrid.Seeder.SeedInterior(startingPosition);
            this.liveGrid.Seeder.SeedCoins();

            bool isExited = false;
            while (!isExited)
            {
                liveGrid.DisplayUpperMessage(true, rover);
                liveGrid.Display(true);
                liveGrid.DisplayLowerMessage(true);
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
            
            return nextState;      
        }
    }
}
