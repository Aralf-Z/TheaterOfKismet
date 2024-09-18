using QFramework;

namespace Game.Core
{   
    public class OnPlayOrDiscardState: WheelStateBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            cardSystem.ChangeWheelState(CardWheelState.ToIdle);
        }

        public override void OnExit(CardSystem cardSystem)
        {
           
        }
    }
} 