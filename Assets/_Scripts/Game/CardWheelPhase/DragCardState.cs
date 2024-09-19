using System;
using QFramework;
using UnityEngine;

namespace Game.Core
{   
    /// <summary>
    /// 拖拽卡牌，放弃拖拽会直接进入Idle状态
    /// </summary>
    public class DragCardState : WheelStateBase
    {
        private Card mCardOnDrag;
        private LayerMask mPlayUpLayerMask = LayerMask.GetMask("PlayUpArea");
        private LayerMask mPlayDownLayerMask = LayerMask.GetMask("PlayDownArea");

        public override void OnEnter(CardSystem cardSystem)
        {
            if (GameInput_2D.TryGetPointOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer<Card>(pos, mCardLayerMask, out var card))
                {
                    mCardOnDrag = card;
                }
                else
                {
                    cardSystem.ChangeWheelState(CardWheelState.StopDragCard);
                }
            }
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetPointOnWorldPos(mMainCamera, out var pos))
            {
                mCardOnDrag.transform.position = pos;

                if (GameInput_2D.IsOnLayer(pos, mPlayUpLayerMask))
                {
                    cardSystem.PlayCurCardUp();
                    cardSystem.ChangeWheelState(CardWheelState.OnPlayOrDiscard);
                }
                else if(GameInput_2D.IsOnLayer(pos, mPlayDownLayerMask))
                {
                    cardSystem.PlayCurCardDown();
                    cardSystem.ChangeWheelState(CardWheelState.OnPlayOrDiscard);
                }
            }
            else
            {
                cardSystem.ChangeWheelState(CardWheelState.StopDragCard);
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 