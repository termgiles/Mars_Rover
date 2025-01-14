namespace Mars_Rover
{
    public static class UIElements 
    {
        public static List<string> LoadingImage = new List<string>();
        public static List<string> GenerateLoadingImage()
        {
            if (LoadingImage.Count == 0)
            {
                LoadingImage.Add(@"============================================================");
                LoadingImage.Add(@"***              *                            *          ***");
                LoadingImage.Add(@"**     *                 *                          *     **");
                LoadingImage.Add(@"*         *                           *       *            *");
                LoadingImage.Add(@"           _ _  _ _       ___    _____   _____              ");
                LoadingImage.Add(@"          // \\// \\     // \\   ||  \\ ||                  ");
                LoadingImage.Add(@"         //   \/   \\   //===\\  ||===/ \\==\\              ");
                LoadingImage.Add(@"        //          \\ //     \\ ||  \\  ___|/              ");
                LoadingImage.Add(@"         _____    ___  _    _ _____ _____                   ");
                LoadingImage.Add(@"         ||  \\  // \\ \\  // ||    ||  \\                  ");
                LoadingImage.Add(@"         ||===/ ||   || \\//  ||=== ||===/                  ");
                LoadingImage.Add(@"         ||  \\  \\_//   \/   ||___ ||  \\                  ");
                LoadingImage.Add(@"                                                            ");
                LoadingImage.Add(@" ========================================================== ");
                LoadingImage.Add(@"             A Game By Tom Giles c. 2025                    ");
                LoadingImage.Add(@" ========================================================== ");
                LoadingImage.Add(@"** *       *                         *          * *         ");
                LoadingImage.Add(@"============================================================");
            }

            return LoadingImage;
        }

        public static List<string> MainMenuImage = new List<string>();
        
        public static List<string> GenerateMainMenuImage()
        {
            if (MainMenuImage.Count() == 0)
            {
                MainMenuImage.Add("============================================================");
                MainMenuImage.Add("A main menu image");
                MainMenuImage.Add("Enter 1 to play, Enter 2 for settings, Enter 3 to quit.");
            }
            return MainMenuImage;
        }
    }
}
