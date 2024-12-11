namespace Mars_Rover
{
    public class Settings : UserInterface 
    {
        public override Transition Run() 
        {
            Console.WriteLine("settings:");
            return Transition.LOADING_SCREEN;       //add
        }
    }
}
