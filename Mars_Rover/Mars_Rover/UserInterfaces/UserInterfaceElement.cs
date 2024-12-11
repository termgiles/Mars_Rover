
using Mars_Rover;

namespace Mars_Rover
{
    public abstract class UserInterface 
    {
        public abstract Transition Run();
        protected StateManager _stateManager;
        public void SetStateManager(StateManager stateManager)
        {
            this._stateManager = stateManager;
        }

    }
}
