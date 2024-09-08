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
      private GameState mCurState;// { get; private set; }
      private WheelPhaseBase mCurWheelPhase;// { get; private set; }
      
      public DragArea dragArea;
      public CardsMgr cardsMgr;
      public Card curCard;
      
      private Dictionary<CardWheelPhase, WheelPhaseBase> cardPlayPhaseMap =
         new Dictionary<CardWheelPhase, WheelPhaseBase>();

      protected override void OnInit()
      {
          cardPlayPhaseMap.Add(CardWheelPhase.DragWheel, new DragWheelPhase(this));
          cardPlayPhaseMap.Add(CardWheelPhase.DragCard, new DragCardPhase(this));
          cardPlayPhaseMap.Add(CardWheelPhase.Reset, new ResetPhase(this));
          cardPlayPhaseMap.Add(CardWheelPhase.Idle, new IdlePhase(this));
          cardPlayPhaseMap.Add(CardWheelPhase.CardNumChange, new CardNumChangePhase(this));
      }

      public void GameEntry()
      {
         var cardPlay = Object.Instantiate(ResTool.Load<GameObject>("Game")).GetComponent<CardPlayMgr>();

         dragArea = cardPlay.dragArea;
         cardsMgr = cardPlay.cardsMgr;
         
         ChangeGameState(GameState.UnPlaying);
      }
      
      public void ChangeGameState(GameState gameState)
      {
         mCurState = gameState;
         ChangeWheelPhase(CardWheelPhase.Reset);
      }
      
      public void ChangeWheelPhase(CardWheelPhase cardWheelPhase)
      {
         mCurWheelPhase?.OnExit();
         mCurWheelPhase = cardPlayPhaseMap[cardWheelPhase];
         mCurWheelPhase.OnEnter();
      }
      
      public void OnUpdate(float dt)
      {
         mCurWheelPhase.OnUpdate(dt);
      }
      
      public void OnDragCardWheel(Vector2 dragDelta)
      {
         this.GetModel<CardModel>().dragDelta.Value = dragDelta;
      }

      /// <summary>
      /// 返回卡牌组，从0开始，y负半轴开始以逆时针顺序排列
      /// </summary>
      /// <returns>
      ///  游戏卡牌的稀有度不是读表格所以返回的数组
      /// </returns>
      public (GameState gameState, (int cardId, int cardRarity)[] cardsPack) GetCards()
      {
         var cardsPack = new (int,int)[] {(1,3),(2,2),(6,0),(9,5)};

         return (GameState.Playing, cardsPack);
      }
   }
}