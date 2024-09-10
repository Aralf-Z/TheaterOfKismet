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
        private Camera mMainCamera;
        private LayerMask mWheelLayerMask;
        private Vector2 mPrePosition;

        public override void OnEnter(CardSystem cardSystem)
        {
            mMainCamera = Camera.main;
            mWheelLayerMask = LayerMask.GetMask("DragArea");

            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                mPrePosition = pos;
            }
            else
            {
                //todo
                Debug.Log("Error Enter DragWheel");
            }
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer(pos, mWheelLayerMask))
                {
                    var delta = mPrePosition - pos;
                    mPrePosition = pos;
                    cardSystem.OnDragCardWheel(delta);
                }
                else
                {
                    cardSystem.ChangeWheelPhase(CardWheelPhase.Idle);
                }
            }
            else
            {
                cardSystem.ChangeWheelPhase(CardWheelPhase.Idle);
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }

    public class DragCardPhase : WheelPhaseBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            Debug.Log("DragCard");
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
    
    public class IdlePhase : WheelPhaseBase
    {
        private Camera mMainCamera;
        private LayerMask mDragLayerMask;
        private LayerMask mCardLayerMask;
        
        public override void OnEnter(CardSystem cardSystem)
        {
            mMainCamera = Camera.main;
            mDragLayerMask = LayerMask.GetMask("DragArea");
            mCardLayerMask = LayerMask.GetMask("Card");
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer(pos, mCardLayerMask))
                {
                    //todo 拖拽到卡牌时,判定成功就return
                }
                
                if(GameInput_2D.IsOnLayer(pos, mDragLayerMask))
                {
                    cardSystem.ChangeWheelPhase(CardWheelPhase.DragWheel);
                }
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }

    public class ResetPhase : WheelPhaseBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            cardSystem.cardsMgr.ResetCards();
            cardSystem.ChangeWheelPhase(CardWheelPhase.DragWheel);
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
    
    public class CardNumChangePhase : WheelPhaseBase
    {
        
        public override void OnEnter(CardSystem cardSystem)
        {
            
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
    
    public abstract class WheelPhaseBase
    {
        public abstract void OnEnter(CardSystem cardSystem);

        public abstract void OnUpdate(CardSystem cardSystem, float dt);

        public abstract void OnExit(CardSystem cardSystem);
    }
} 