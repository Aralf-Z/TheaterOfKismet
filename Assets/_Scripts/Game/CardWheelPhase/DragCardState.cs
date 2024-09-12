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
        private Camera mMainCamera = Camera.main;
        private LayerMask mCardLayerMask = LayerMask.GetMask("Card");

        private Card mCardOnDrag;

        public override void OnEnter(CardSystem cardSystem)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer<Card>(pos, mCardLayerMask, out var card))
                {
                    mCardOnDrag = card;
                }
                else
                {
                    cardSystem.ChangeWheelState(CardWheelState.ToIdle);
                }
            }
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetOnWorldPos(mMainCamera, out var pos))
            {
                mCardOnDrag.transform.position = pos;
            }
            else
            {
                cardSystem.ChangeWheelState(CardWheelState.ToIdle);
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 