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
        
        private Camera mMainCamera;
        private LayerMask mDragLayerMask;
        private LayerMask mCardLayerMask;
		
        private Vector2 mPrePosition;

        public override void OnEnter()
        {
            mMainCamera = Camera.main;
            mDragLayerMask = LayerMask.GetMask("DragArea");
            mCardLayerMask = LayerMask.GetMask("Card");
            mPrePosition = Vector2.zero;
        }

        public override void OnUpdate(float dt)
        {
            if (Input.GetMouseButtonDown(0))//鼠标按下时
            {
                mPrePosition = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//触摸屏按下时
            {
                mPrePosition = Input.GetTouch(0).position;
            }
            else if (Input.GetMouseButton(0))//鼠标按住时
            {
                var pos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
                SetDelta(pos);
            }
            else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)//触摸屏按住时
            {
                var pos = Input.GetTouch(0).position;
                SetDelta(pos);
            }
            else if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)//鼠标抬起时 || 触摸屏抬起时
            {
                mPrePosition = Vector2.zero;
            }
        }

        public override void OnExit()
        {
            
        }
        
        private void SetDelta(Vector2 pos)
        {
            var hit = Physics2D.Raycast(pos, Vector2.zero, 2f, mDragLayerMask);

            if (hit.collider is not null)
            {
                var delta = pos - mPrePosition;
                cardSystem.OnDragCardWheel(delta);
                mPrePosition = pos;

                if (Mathf.Abs(delta.y) > Mathf.Abs(delta.x))
                {
                    var cardHit = Physics2D.Raycast(pos, Vector2.zero, 2f, mCardLayerMask);

                    if (cardHit.collider is not null)
                    {
                        cardSystem.ChangeWheelPhase(CardWheelPhase.DragCard);
                    }
                }
            }
        }
    }

    public class DragCardPhase : WheelPhaseBase
    {
        public DragCardPhase(CardSystem cardSystem) : base(cardSystem)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("DragCard");
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