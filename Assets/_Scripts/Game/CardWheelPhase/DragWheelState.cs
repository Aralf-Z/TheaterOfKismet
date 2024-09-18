using QFramework;
using UnityEngine;

namespace Game.Core
{   
    /// <summary>
    /// 拖拽卡牌，停止时转向ToIdle
    /// </summary>
    public class DragWheelState: WheelStateBase 
    {
        private Vector2 mPrePosition;

        public override void OnEnter(CardSystem cardSystem)
        {
            if (GameInput_2D.TryGetPointOnWorldPos(mMainCamera, out var pos))
            {
                mPrePosition = pos;
            }
            else
            {
                cardSystem.ChangeWheelState(CardWheelState.ToIdle);
            }
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            if (GameInput_2D.TryGetPointOnWorldPos(mMainCamera, out var pos))
            {
                if (GameInput_2D.IsOnLayer(pos, mDragLayerMask))
                {
                    var delta = mPrePosition - pos;
                    mPrePosition = pos;
                    cardSystem.OnDragCardWheel(delta);
                }
                else
                {
                    cardSystem.ChangeWheelState(CardWheelState.ToIdle);
                }
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