using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.UserInterface
{
    public class StateManager                //make static? or singleton ?
    {
        //private static StateManager instance;

        private IUserInterface _loadingScreen;
        private IUserInterface _mainMenu;
        private IUserInterface _settings;
        private IUserInterface _gameDisplay;
        public StateManager(IUserInterface loadingScreen, IUserInterface mainMenu, IUserInterface settings, IUserInterface gameDisplay)
        {
            this._loadingScreen = loadingScreen;
            this._mainMenu = mainMenu;
            this._settings = settings;
            this._gameDisplay = gameDisplay;
        }

        public void Run(IUserInterface state)
        {
            Transition next = state.Run();        //does this need to be an async await, does it need a try catch

            TransitionHandler(next);

        }

        public void TransitionHandler(Transition next)
        {
            IUserInterface nextState = next switch
            { Transition.LOADING_SCREEN => loadingScreen }
            }
    }
        
}
