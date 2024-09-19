using System.Collections.Generic;
using System.Linq;
using Game.Core;
using QFramework;
using UnityEngine;
using ZToolKit;

namespace Game
{
    public class CardsMgr : MonoBehaviour
    {
        /// <summary>
        /// key:初始化卡牌时确定的，卡牌的位序；
        /// </summary>
        private Dictionary<int, Card> mCards = new ();
        
        private MonoBehaviourPool<Card> mCardPool;
        
        private void Awake()
        {
            mCardPool = new MonoBehaviourPool<Card>(transform, ResTool.Load<GameObject>("Card"), x => x.Init());
        }
        
        public void ResetCards((GameState gameState, (int cardId, int cardRarity)[] cardsPack) cardsPack)
        {
            mCardPool.Recycle(mCards.Values);
            mCards.Clear();
            
            if (cardsPack.gameState == GameState.Playing)
            {
                var singleAngle = 360f / cardsPack.cardsPack.Length;
                
                for (int i = 0; i < cardsPack.cardsPack.Length; ++i)
                {
                    var uiCard = mCardPool.Get();
                    uiCard.Show(CfgTool.Tables.TbGameCard.Get(cardsPack.cardsPack[i].cardId),cardsPack.cardsPack[i].cardRarity, singleAngle * i, i);
                    mCards.Add(i,uiCard);
                }
            }
            else if(cardsPack.gameState == GameState.UI)
            {
                var singleAngle = 360f / cardsPack.cardsPack.Length;
                
                for (int i = 0; i < cardsPack.cardsPack.Length; ++i)
                {
                    var uiCard = mCardPool.Get();
                    uiCard.Show(CfgTool.Tables.TbUICard.Get(cardsPack.cardsPack[i].cardId), singleAngle * i, i);
                    mCards.Add(i,uiCard);
                }
            }
        }

        public Card GetCard(int cardIndex)
        {
            return mCards[cardIndex];
        }

        public Card RemoveCard(int cardIndex)
        {
            var card = mCards[cardIndex];
            mCards.Remove(cardIndex);
            mCardPool.Recycle(card);
            ResortCard(cardIndex);
            return card;
        }

        private void ResortCard(int cardIndex)
        {
            var cards = mCards.Keys.OrderByDescending(x => x).ToArray();
            var singleAngle = 360f / mCards.Count;
                
            for (int i = 0; i <  cards.Length; ++i)
            {
               mCards[cards[i]].SetAngle(singleAngle * i);
            }
        }
    } 
} 

