using QFramework;

namespace Game.Core
{   
    /// <summary>
    /// 回收卡牌、重新生成新的卡牌，执行过程动画，结束进入IdleState；
    /// </summary>
    public class ResetState : WheelStateBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            cardSystem.cardsMgr.InitCards();
            cardSystem.ChangeWheelState(CardWheelState.DragWheel);
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 