namespace Mars_Rover
{
    public static class UIElements 
    {
        public static List<string> LoadingImage = new List<string>();
        public static List<string> GenerateLoadingImage()
        {
            if (LoadingImage.Count == 0)
            {
                LoadingImage.Add("============================================================");
                LoadingImage.Add("***              *                            *          ***");
                LoadingImage.Add("**     *                 *                          *     **");
                LoadingImage.Add("*         *                           *       *            *");
                LoadingImage.Add("              =   =   =          =      ===    ===          ");
                LoadingImage.Add("            // \\// \\                                      ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
                LoadingImage.Add("Loading Image                                               ");
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
