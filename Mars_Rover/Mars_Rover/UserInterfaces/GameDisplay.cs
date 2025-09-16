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
            int cycleCount = 1;
            int clearTrackOn = 4;

            if (this._stateManager.IsAnologue())
            {
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
                            nextState = Transition.LOADING_SCREEN;
                            break;
                        }
                        liveGrid.InstructRover(InputParser.ParseInstruction(userInput), rover);
                        if (this._stateManager.IsDisappearingTracks())
                        {
                            this.liveGrid.ClearTrack(rover);
                        }
                        Console.Clear();
                    }
                    catch
                    {
                        Console.WriteLine("enter another input");
                    }
                }
            }

            if (!this._stateManager.IsAnologue())
            {
                while (!isExited)
                {

                    liveGrid.DisplayUpperMessage(true, rover);
                    liveGrid.Display(true);
                    liveGrid.DisplayLowerMessage(true);
                    Console.WriteLine("Use arrow keys or wasd:");
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo inputkey = Console.ReadKey(true);
                        if (inputkey.KeyChar == '3')
                        {
                            nextState = Transition.QUIT;
                            isExited = true;
                        }
                        if (inputkey.KeyChar == '2')
                        {
                            nextState = Transition.LOADING_SCREEN;
                            isExited = true;
                        }
                        var inputs = InputParser.ParseKeyInput(inputkey.Key.ToString());
                        if (inputs.isValid)
                        {
                            this.liveGrid.InstructRover(inputs.instructions, rover);
                        }
                    }
                    if (this._stateManager.IsDisappearingTracks() && cycleCount % clearTrackOn == 0)
                    {
                        this.liveGrid.ClearTrack(rover);
                    }
                    cycleCount = (cycleCount + 1) % int.MaxValue; 
                    Thread.Sleep((int)(1000/24));
                    Console.Clear();
                }

            }
            
            return nextState;      
        }
    }
}
