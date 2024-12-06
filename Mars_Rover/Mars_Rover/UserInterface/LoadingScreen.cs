namespace Mars_Rover
{
    public class LoadingScreen : IUserInterface
    {

        private Transition NextState = Transition.MAIN_MENU;
        public void Run()
        {
            foreach(string line in UIElements.GenerateLoadingImage())
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.Clear();
        }

        public Transition Next()
        {
            return NextState;
        }
    }
}
