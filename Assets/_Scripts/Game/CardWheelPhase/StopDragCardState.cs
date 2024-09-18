using QFramework;
using UnityEngine;

namespace Game.Core
{   
    public class StopDragCardState:WheelStateBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            
        }

        public override void OnUpdate(CardSystem cardSystem, float dt)
        {
            //BindableProperty的特性，值如果不变就不会触发，所以调用两次
            cardSystem.OnDragCardWheel(new Vector2(-.02f,0));
            cardSystem.OnDragCardWheel(new Vector2(.02f,0));
            cardSystem.ChangeWheelState(CardWheelState.Idle);
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }
    }
} 