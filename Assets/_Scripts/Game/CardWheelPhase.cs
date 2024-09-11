using QFramework;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

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
        private Camera mMainCamera = Camera.main;
        private LayerMask mWheelLayerMask = LayerMask.GetMask("DragArea");
        private Vector2 mPrePosition;

        public override void OnEnter(CardSystem cardSystem)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                mPrePosition = pos;
            }
            else
            {
                cardSystem.ChangeWheelPhase(CardWheelPhase.Idle);
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
        private Camera mMainCamera = Camera.main;
        private LayerMask mCardLayerMask = LayerMask.GetMask("Card");
        private Vector2 mPrePos;
        
        public override void OnEnter(CardSystem cardSystem)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer(pos, mCardLayerMask))
                {
                    mPrePos = pos;
                }
            }
            else
            {
                cardSystem.ChangeWheelPhase(CardWheelPhase.Idle);
            }
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer(pos, mCardLayerMask))
                {
                    mPrePos = pos;
                }
            }
            else
            {
                
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
    
    public class IdlePhase : WheelPhaseBase
    {
        private Camera mMainCamera = Camera.main;
        private LayerMask mDragLayerMask = LayerMask.GetMask("DragArea");
        private LayerMask mCardLayerMask = LayerMask.GetMask("Card");
        private Vector2 mPrePos;
        private bool mOnDrag;
        
        public override void OnEnter(CardSystem cardSystem)
        {
            mOnDrag = false;
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (mOnDrag)
                {
                    var delta = mPrePos - pos;
                    
                    if (GameInput_2D.IsOnLayer(pos, mCardLayerMask) && delta.x * 1.73f > delta.y)
                    {
                        cardSystem.ChangeWheelPhase(CardWheelPhase.DragCard);
                        return;
                    }
                
                    if(GameInput_2D.IsOnLayer(pos, mDragLayerMask))
                    {
                        cardSystem.ChangeWheelPhase(CardWheelPhase.DragWheel);
                        return;
                    }

                    mPrePos = pos;
                }
                else
                {
                    mOnDrag = true;
                    mPrePos = pos;
                }
                
            }
            else
            {
                mOnDrag = false;
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