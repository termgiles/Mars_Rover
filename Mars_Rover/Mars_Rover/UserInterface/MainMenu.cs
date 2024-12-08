namespace Mars_Rover.UserInterface
{
    public class MainMenu : IUserInterface
    {
        public Transition Run()
        {
            Console.WriteLine(UIElements.GenerateMenuImage);
        }
    }
        
}
