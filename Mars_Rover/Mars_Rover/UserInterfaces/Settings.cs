namespace Mars_Rover
{
    public class Settings : UserInterface 
    {
        public bool DefaultSettings { get; private set; } = true;

        public bool AnalougeMode { get; private set; } = true;

        public override Transition Run() 
        {
            Transition nextState = Transition.LOADING_SCREEN;

            bool stillParsing = true;

            while (stillParsing)
            {
                Console.Clear();
                Console.WriteLine("settings: \n");
                Console.WriteLine("Type 'D' to toggle default settings, 'A' to toggle analogue mode");
                Console.WriteLine("Type 2 for main menu, 3 to quit:");

                Console.WriteLine("Default settings: " + DefaultSettings.ToString());
                Console.WriteLine("Analogue mode: " + AnalougeMode.ToString());
                Console.Write("\n");
                string response = Console.ReadLine();
                if (response == "3")
                {
                    nextState = Transition.QUIT;
                    stillParsing = false;
                }
                if (response == "2")
                {
                    stillParsing = false;
                }
                if (response.ToUpper().Trim() == "A") AnalougeMode = !AnalougeMode;
                if( response.ToUpper().Trim() == "D") DefaultSettings = !DefaultSettings;
            }

            return nextState;       
        }
    }
}
