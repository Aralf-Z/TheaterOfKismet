/*

*/

using QFramework;

namespace TheaterOfKismet
{
    public class LevelInitHandler : StateHandlerBase
    {
        public LevelInitHandler(GameStateSystem stateSystem) : base(stateSystem)
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