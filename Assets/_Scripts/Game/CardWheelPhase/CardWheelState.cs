using QFramework;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Game.Core
{
    public enum CardWheelState
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
        /// 回到闲置的过渡状态
        /// </summary>
        ToIdle = 3,

        /// <summary>
        /// 玩家没有任何操作的状态
        /// </summary>
        Idle = 4,
        
        /// <summary>
        /// 重新生成卡牌
        /// </summary>
        Reset = 5,
        
        /// <summary>
        /// 停止拖拽卡牌后
        /// </summary>
        StopDragCard = 6,
        
        /// <summary>
        /// 卡牌打出或者丢弃后
        /// </summary>
        OnPlayOrDiscard = 7,
    }

    public abstract class WheelStateBase
    {
        protected Camera mMainCamera = Camera.main;
        protected LayerMask mDragLayerMask = LayerMask.GetMask("DragArea");
        protected LayerMask mCardLayerMask = LayerMask.GetMask("Card");

        protected WheelStateBase()
        {
        }

        public abstract void OnEnter(CardSystem cardSystem);

        public abstract void OnUpdate(CardSystem cardSystem, float dt);

        public abstract void OnExit(CardSystem cardSystem);
    }
} 