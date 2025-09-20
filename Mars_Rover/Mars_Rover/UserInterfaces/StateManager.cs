using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover
{
    public class StateManager                //make static? or singleton ?
    {
        private UserInterface _state = null;

        private UserInterface _loadingScreen;
        private UserInterface _mainMenu;
        private UserInterface _settings;
        private UserInterface _gameDisplay;
        public StateManager(UserInterface loadingScreen, UserInterface mainMenu, UserInterface settings, UserInterface gameDisplay)
        {
            this._loadingScreen = loadingScreen;
            this._mainMenu = mainMenu;
            this._settings = settings;
            this._gameDisplay = gameDisplay;

            this._loadingScreen.SetStateManager(this);
            this._mainMenu.SetStateManager(this);
            this._settings.SetStateManager(this);
            this._gameDisplay.SetStateManager(this);

            this._state = loadingScreen;
        }

        public bool IsAnologue()
        {
            return ((Settings)this._settings).AnalougeMode;
        }

        public bool IsDisappearingTracks()
        {
            return ((Settings)this._settings).DisappearingTracks;
        }

        public bool IsEnemyOn()
        {
            return ((Settings)this._settings).EnemyOn;
        }

        public UserInterface GetState()
        {
            return this._state;
        }

        public void Run()
        {
            Transition next = this._state.Run();        //does this need to be an async await, does it need a try catch
            TransitionHandler(next);
        }

        public void TransitionHandler(Transition next)
        {
            UserInterface nextState = next switch
            { 
                Transition.LOADING_SCREEN => _loadingScreen,
                Transition.MAIN_MENU => _mainMenu,
                Transition.SETTINGS => _settings,
                Transition.DISPLAY => _gameDisplay,
                Transition.QUIT => new Quit(),
            };
            this._state = nextState;
        }
    }
        
}
