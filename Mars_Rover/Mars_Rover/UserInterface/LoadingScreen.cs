namespace Mars_Rover
{
    public class LoadingScreen : IUserInterface
    {

        private Transition NextState = Transition.MAIN_MENU;
        public Transition Run()
        {
            foreach(string line in UIElements.GenerateLoadingImage())
            {
                Console.WriteLine(line);
                Thread.Sleep(100);
            }
            Thread.Sleep(2000);
            Console.Clear();
            return Transition.MAIN_MENU;
        }

        //public Transition Next()
        //{
        //    return NextState;
        //}
    }
}
