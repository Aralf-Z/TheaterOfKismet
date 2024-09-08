using QFramework;
using UnityEngine;

namespace Game.Core
{
    public enum CardWheelPhase
    {
        /// <summary>
        /// 拖拽卡牌轮旋转
        /// </summary>
        DragWheel = 1,
        
        /// <summary>
        /// 拖拽卡牌
        /// </summary>
        DragCard = 2,
        
        /// <summary>
        /// 重置当前阶段
        /// </summary>
        Reset = 3,
        
        /// <summary>
        /// 玩家没有任何操作的状态
        /// </summary>
        Idle = 4,
        
        /// <summary>
        /// 卡牌轮中，数量增加或者减少时的过渡状态
        /// </summary>
        CardNumChange = 5,
    }

    public class DragWheelPhase: WheelPhaseBase
    {
        public DragWheelPhase(CardSystem cardSystem) : base(cardSystem)
        {
        }
        
        public override void OnEnter()
        {
            
        }

        public override void OnUpdate(float dt)
        {
            cardSystem.dragArea.OnUpdate();
        }

        public override void OnExit()
        {
            
        }
    }

    public class DragCardPhase : WheelPhaseBase
    {
        public DragCardPhase(CardSystem cardSystem) : base(cardSystem)
        {
        }

        public override void OnEnter()
        {
            
        }

        public override void OnUpdate(float dt)
        {
            
        }

        public override void OnExit()
        {
            
        }
    }
    
    public class IdlePhase : WheelPhaseBase
    {
        public IdlePhase(CardSystem cardSystem) : base(cardSystem)
        {
        }

        public override void OnEnter()
        {
            
        }

        public override void OnUpdate(float dt)
        {
            
        }

        public override void OnExit()
        {
            
        }
    }

    public class ResetPhase : WheelPhaseBase
    {
        public ResetPhase(CardSystem cardSystem) : base(cardSystem)
        {
            
        }

        public override void OnEnter()
        {
            cardSystem.cardsMgr.ResetCards();
            cardSystem.ChangeWheelPhase(CardWheelPhase.DragWheel);
        }

        public override void OnUpdate(float dt)
        {
            
        }

        public override void OnExit()
        {
            
        }
    }
    
    public class CardNumChangePhase : WheelPhaseBase
    {
        public CardNumChangePhase(CardSystem cardSystem) : base(cardSystem)
        {
        }

        public override void OnEnter()
        {
            
        }

        public override void OnUpdate(float dt)
        {
            
        }

        public override void OnExit()
        {
            
        }
    }
    
    public abstract class WheelPhaseBase
    {
        protected CardSystem cardSystem;

        protected WheelPhaseBase(CardSystem cardSystem)
        {
            this.cardSystem = cardSystem;
        }

        public abstract void OnEnter();

        public abstract void OnUpdate(float dt);

        public abstract void OnExit();
    }
} 