using QFramework;

namespace Game.Core
{   
    /// <summary>
    /// 停止拖拽卡牌轮或者卡牌时进入该状态，调整回到Idle状态，此时只能拖拽卡牌轮无法拖拽卡牌
    /// </summary>
    public class ToIdleState : WheelStateBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            cardSystem.ChangeWheelState(CardWheelState.Idle);
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 