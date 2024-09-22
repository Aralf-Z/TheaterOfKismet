using System.Collections.Generic;
using System.Linq;
using Game.Core;
using QFramework;
using UnityEngine;
using ZToolKit;

namespace Game
{
    public abstract class CardsMgr : MonoBehaviour
    {
        public Dictionary<int, Card> Cards => mCards;
        
        protected Dictionary<int, Card> mCards = new ();
        
        protected MonoBehaviourPool<Card> mCardPool;
        
        protected void Awake()
        {
            mCardPool = new MonoBehaviourPool<Card>(transform, ResTool.Load<GameObject>("Card"), x => x.Init());
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

        protected void ResortCard(int cardIndex)
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

