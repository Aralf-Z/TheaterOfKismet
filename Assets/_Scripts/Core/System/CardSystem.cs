using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using QFramework;
using ZToolKit;

namespace Game.Core
{
   //todo 实质上这个系统有点像游戏管理器了，他即管理游玩状态，又管理游戏流程，需要拆解一下
   public class CardSystem : AbstractSystem
   {
      private Dictionary<CardWheelState, WheelStateBase> mCardPlayStateMap = new Dictionary<CardWheelState, WheelStateBase>();
      private Dictionary<GameState, GameStateHandlerBase> mGameStateMap = new Dictionary<GameState, GameStateHandlerBase>();
      private WheelStateBase mCurWheelState;
      private GameStateHandlerBase mCurGameHandler;

      protected override void OnInit()
      {
          mCardPlayStateMap.Add(CardWheelState.DragWheel, new DragWheelState());
          mCardPlayStateMap.Add(CardWheelState.DragCard, new DragCardState());
          mCardPlayStateMap.Add(CardWheelState.ToIdle, new ToIdleState());
          mCardPlayStateMap.Add(CardWheelState.Idle, new IdleState());
          mCardPlayStateMap.Add(CardWheelState.Reset, new ResetState());
          mCardPlayStateMap.Add(CardWheelState.StopDragCard, new StopDragCardState());
          mCardPlayStateMap.Add(CardWheelState.OnPlayOrDiscard, new OnPlayOrDiscardState());
      }

      /// <summary>
      /// 游戏进入时调取该接口, 开始该游戏的初始化
      /// </summary>
      public void GameEntry()
      {
         var cardPlay = Object.Instantiate(ResTool.Load<GameObject>("Game")).GetComponent<CardPlayMgr>();
         
         CardEffects.Init();
         
         mGameStateMap.Add(GameState.Playing, new PlayingStateHandler(cardPlay.gameCardsMgr));
         mGameStateMap.Add(GameState.UI, new UIStateHandler(cardPlay.uiCardsMgr));
         
         ChangeGameState(GameState.UI);
         ChangeWheelState(CardWheelState.Idle);
      }
      
      #region CardState

      /// <summary>
      /// 切换游戏状态，即选单状态和游玩状态，本质是策略句柄
      /// </summary>
      /// <param name="gameState"></param>
      public void ChangeGameState(GameState gameState)
      {
         LogTool.EditorLog("游戏状态", $"--> {gameState}");
         mCurGameHandler?.OnExit();
         mCurGameHandler = mGameStateMap[gameState];
         mCurGameHandler?.OnEnter();
      }

      public void CardWheelInit()
      {
         
      }

      /// <summary>
      /// 卡牌向上打出
      /// </summary>
      public void PlayCurCardUp()
      {
         mCurGameHandler.PlayCurCardUp();
      }
      
      /// <summary>
      /// 卡牌向下打出
      /// </summary>
      public void PlayCurCardDown()
      {
         mCurGameHandler.PlayCurCardDown();
      }

      #endregion

      #region CardWheel

      /// <summary>
      /// 切换卡牌轮的状态，本质是状态机
      /// </summary>
      /// <param name="cardWheelState"></param>
      public void ChangeWheelState(CardWheelState cardWheelState)
      {
         LogTool.EditorLog("卡牌轮状态", $"--> {cardWheelState}");
         mCurWheelState?.OnExit(this);
         mCurWheelState = mCardPlayStateMap[cardWheelState];
         mCurWheelState.OnEnter(this);
      }

      /// <summary>
      /// 卡牌轮更新
      /// </summary>
      /// <param name="dt"></param>
      public void OnUpdate(float dt)
      {
         mCurWheelState.OnUpdate(this, dt);
      }
      
      /// <summary>
      /// 拖拽卡牌轮时，传入和上一帧的差值
      /// </summary>
      /// <param name="dragDelta"></param>
      public void OnDragCardWheel(Vector2 dragDelta)
      {
         //todo 差值的本质是基于qf的BindableProperty，但该特性只接受变化值，即如果每一帧的传入的delta相同会导致无法触发的bug
         this.GetModel<CardModel>().dragDelta.Value = dragDelta;
         mCurGameHandler.UpdateCurCard();
      }
      
      /// <summary>
      /// 检查卡牌是否是可拖拽卡牌
      /// </summary>
      /// <param name="curCardIndex">卡牌轮中的位序</param>
      /// <returns></returns>
      public bool CheckCurCard(int curCardIndex)
      {
         return mCurGameHandler.CurCard == curCardIndex;
      }
      
      /// <summary>
      /// 检查卡牌轮返回闲置状态
      /// </summary>
      /// <returns>可处于闲置</returns>
      public bool CheckToIdle()
      {
         var angle = mCurGameHandler.GetCurCardAngle();
         
         if (angle > -1.5f && angle < 1.5f)
         {
            return true;
         }
         
         var ratio = angle > 0 ? 1: -1;
         var num = angle / 90f;

         OnDragCardWheel(new Vector2(ratio * num * num * 8, 0));
         
         return false;
      }
      
      #endregion
   }
}