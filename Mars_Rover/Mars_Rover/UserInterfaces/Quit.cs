namespace Mars_Rover
{
    public class Quit : UserInterface
    {
        public override Transition Run()
        {
            Console.WriteLine("Game should quit now");
            throw new Exception("game quit by user");
        }
    }
}
