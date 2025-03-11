namespace Mars_Rover
{
    public class MainMenu : UserInterface
    {
        public override Transition Run()
        {
            UIElements.GenerateMainMenuImage().ForEach(l => Console.WriteLine(l));
            Transition nextState;
            bool validResponse = false;
            string response = null;
            while (!validResponse)
            {
                try
                {
                    response = Console.ReadLine();
                    if(Int32.Parse(response) == 1)
                    {
                        validResponse = true;
                        Console.Clear();
                        return Transition.DISPLAY;
                    }
                    if (Int32.Parse(response) == 2)
                    {
                        validResponse = true;
                        Console.Clear();
                        return Transition.SETTINGS;
                    }
                    if (Int32.Parse(response) == 3)
                    {
                        validResponse = true;
                        Console.Clear();
                        return Transition.QUIT;
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message + "\nEnter another response");
                }
            }
   
            return Transition.MAIN_MENU;
        }
    }
}
