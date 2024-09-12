using QFramework;
using UnityEngine;

namespace Game.Core
{   
    /// <summary>
    /// 拖拽卡牌，停止时转向ToIdle
    /// </summary>
    public class DragWheelState: WheelStateBase
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
                cardSystem.ChangeWheelState(CardWheelState.Idle);
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
                    cardSystem.ChangeWheelState(CardWheelState.Idle);
                }
            }
            else
            {
                cardSystem.ChangeWheelState(CardWheelState.Idle);
            }
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 