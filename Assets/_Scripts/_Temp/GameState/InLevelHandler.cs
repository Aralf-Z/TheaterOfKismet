/*

*/

using QFramework;

namespace TheaterOfKismet
{   
    public class InLevelHandler:StateHandlerBase
    {
        public InLevelHandler(GameStateSystem stateSystem) : base(stateSystem)
        {
        }

        public override void OnEnter(CardWheel cardWheel, CardGenerator cardGenerator)
        {
            throw new System.NotImplementedException();
        }

        public override void CheckState(CardEvent cardEvent, LevelManager levelManager)
        {
            throw new System.NotImplementedException();
        }

        public override void DoState(CardEvent cardEvent, LevelManager levelManager)
        {
            throw new System.NotImplementedException();
        }
    }
} 