namespace Mars_Rover
{
    public class LoadingScreen : UserInterface
    {

        private Transition NextState = Transition.MAIN_MENU;
        public override Transition Run()
        {
            Console.Clear();
            foreach (string line in UIElements.GenerateLoadingImage())
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.Clear();
            return Transition.MAIN_MENU;
        }
    }
}
