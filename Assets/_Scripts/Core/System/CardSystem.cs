using System.Collections.Generic;
using UnityEngine;
using QFramework;
using ZToolKit;

namespace Game.Core
{
   public enum GameState
   {
      /// <summary>
      /// 游戏中
      /// </summary>
      Playing,
      /// <summary>
      /// 非游戏状态
      /// </summary>
      UnPlaying
   }
   
   //todo 实质上这个系统有点像游戏管理器了，他即管理游玩状态，又管理游戏流程，需要拆解一下
   public class CardSystem : AbstractSystem
   {
      private GameState mCurGameState;// { get; private set; }
      private WheelStateBase mCurWheelState;// { get; private set; }
      
      public CardsMgr cardsMgr;

      private Dictionary<CardWheelState, WheelStateBase> cardPlayStateMap =
         new Dictionary<CardWheelState, WheelStateBase>();

      protected override void OnInit()
      {
          cardPlayStateMap.Add(CardWheelState.DragWheel, new DragWheelState());
          cardPlayStateMap.Add(CardWheelState.DragCard, new DragCardState());
          cardPlayStateMap.Add(CardWheelState.ToIdle, new ToIdleState());
          cardPlayStateMap.Add(CardWheelState.Idle, new IdleState());
          cardPlayStateMap.Add(CardWheelState.Reset, new ResetState());
      }

      public void GameEntry()
      {
         var cardPlay = Object.Instantiate(ResTool.Load<GameObject>("Game")).GetComponent<CardPlayMgr>();
         
         cardsMgr = cardPlay.cardsMgr;
         
         ChangeGameState(GameState.UnPlaying);
      }
      
      public void ChangeGameState(GameState gameState)
      {
         mCurGameState = gameState;
         ChangeWheelState(CardWheelState.Reset);
      }
      
      public void ChangeWheelState(CardWheelState cardWheelState)
      {
         var preState = mCurWheelState?.GetType().Name;
         
         mCurWheelState?.OnExit(this);
         mCurWheelState = cardPlayStateMap[cardWheelState];
         mCurWheelState.OnEnter(this);
         
         Debug.Log( preState + "->" + mCurWheelState.GetType().Name);
      }
      
      public void OnUpdate(float dt)
      {
         mCurWheelState.OnUpdate(this, dt);
      }
      
      public void OnDragCardWheel(Vector2 dragDelta)
      {
         this.GetModel<CardModel>().dragDelta.Value = dragDelta;
      }

      public bool CheckCurCard(int curCard)
      {
         Debug.Log(curCard +"--" + this.GetModel<CardModel>().curCard);
         return this.GetModel<CardModel>().curCard == curCard;
      }
      
      /// <summary>
      /// 返回卡牌组，从0开始，y负半轴开始以逆时针顺序排列
      /// </summary>
      /// <returns>
      ///  游戏卡牌的稀有度不是读表格所以返回的数组
      /// </returns>
      public (GameState gameState, (int cardId, int cardRarity)[] cardsPack) GetCards()
      {
         var cardsPack = new (int,int)[] {(1,3),(2,2),(6,0),(9,1)};

         return (GameState.Playing, cardsPack);
      }
   }
}