using System;
using System.Collections.Generic;
using QFramework;
using ZToolKit;

namespace Game.Core
{
   public class GamePlaySystem : AbstractSystem
   {
      private int mScore;

      private int mCurRound;
      
      public int curRoundScore;

      public List<CardInfo> curRoundPlayed = new List<CardInfo>();

      private List<BuffBase> mBuffs = new List<BuffBase>();
      
      /// <summary>
      /// int: 当前分数
      /// </summary>
      public event Action<int> Event_OnScoreChange;
      
      protected override void OnInit()
      {
          
      }
      
      
      public void StartNewGame()
      {
         mScore = 0;
         curRoundScore = 0;
         Event_OnScoreChange?.Invoke(mScore);
      }

      public void GameOver()
      {
         
      }
      
      public void ChangeScore(int score)
      {
         mScore += score;
         Event_OnScoreChange?.Invoke(mScore);
      }
      
      public void CardPlayed(Card card)
      {
         curRoundPlayed.Add(new CardInfo(card.CardId, card.Rarity));
         curRoundScore += CfgTool.Tables.TbGameCard[card.CardId].BasePoint * card.Rarity;
      }

      public void CurRoundEnded()
      {
         foreach (var buff in mBuffs)
         {
            buff.OnRoundOver();
         }
         mScore += curRoundScore;
         curRoundScore = 0;
         
         //todo ResetCard；
      }

      public void AddBuff(BuffBase buff)
      {
         mBuffs.Add(buff);
      }
   }

   public class CardInfo
   {
      public int CardId { get; }
      public int Rarity { get; }

      public CardInfo(int cardId, int rarity)
      {
         CardId = cardId;
         Rarity = rarity;
      }
   }
   
   public abstract class BuffBase: ICanGetSystem
   {
      public virtual void OnRoundOver(){}

      public virtual bool CanRemoveOnRoundOver() => true;
      
      public IArchitecture GetArchitecture()
      {
         return GameCore.Interface;
      }
   }

   public class Buff_201: BuffBase
   {
      private int mSameCard;
      private int mRatio;

      public Buff_201(int sameCard, int ratio)
      {
         mSameCard = sameCard;
         mRatio = ratio;
      }

      public override void OnRoundOver()
      {
         base.OnRoundOver();

         var infos = this.GetSystem<GamePlaySystem>().curRoundPlayed;
         var nums = new Dictionary<int, int>();
         foreach (var info in infos )
         {
            if (!nums.ContainsKey(info.CardId))
            {
               nums.Add(info.CardId, 0);
            }

            nums[info.CardId]++;

            if (nums[info.CardId] >= mSameCard)
            {
               this.GetSystem<GamePlaySystem>().curRoundScore *= mRatio;
               return;
            }
         }
      }
   }
}