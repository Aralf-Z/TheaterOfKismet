using QFramework;
using UnityEngine;

namespace Game.Core
{   
    /// <summary>
    /// 闲置状态，只接收推拽指令，判断是否拖拽卡牌轮还是卡牌
    /// </summary>
    public class IdleState : WheelStateBase
    {
        private bool mOnDrag;

        public override void OnEnter(CardSystem cardSystem)
        {
            mOnDrag = false;
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetPointOnWorldPos(mMainCamera, out var pos))
            {
                if (mOnDrag)
                {
                    if (GameInput_2D.IsOnLayer<Card>(pos, mCardLayerMask, out var card) && cardSystem.CheckCurCard(card.CurIndex))
                    {
                        cardSystem.ChangeWheelState(CardWheelState.DragCard);
                        return;
                    }

                    if (GameInput_2D.IsOnLayer(pos, mDragLayerMask))
                    {
                        cardSystem.ChangeWheelState(CardWheelState.DragWheel);
                        return;
                    }
                }
                else
                {
                    mOnDrag = true;
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
} 