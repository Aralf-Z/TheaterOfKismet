/*

*/

namespace TheaterOfKismet
{   
    public abstract class StateHandlerBase
    {
        protected GameStateSystem mStateSystem;

        protected StateHandlerBase(GameStateSystem stateSystem)
        {
            mStateSystem = stateSystem;
        }

        public virtual GameStateLabel Label => GameStateLabel.None;

        public abstract void OnEnter(CardWheel cardWheel, CardGenerator cardGenerator);
        
        public abstract void CheckState(CardEvent cardEvent, LevelManager levelManager);

        public abstract void DoState(CardEvent cardEvent, LevelManager levelManager);
    }
} 