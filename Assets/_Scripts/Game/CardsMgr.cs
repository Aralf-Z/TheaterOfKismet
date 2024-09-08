using System.Collections.Generic;
using Game.Core;
using QFramework;
using UnityEngine;
using ZToolKit;

namespace Game
{
    public class CardsMgr : MonoBehaviour
        , IController
    {
        /// <summary>
        /// key:重置卡牌时确定的，卡牌的位序，重置前一直不变；
        /// </summary>
        public Dictionary<int, Card> cards = new ();
        
        private MonoBehaviourPool<Card> mCardPool;
        
        private void Awake()
        {
            mCardPool = new MonoBehaviourPool<Card>(transform, ResTool.Load<GameObject>("Card"), x => x.Init());
        }

        public void ResetCards()
        {
            var cardsPack = this.GetSystem<CardSystem>().GetCards();
            
            cards.Clear();
            
            if (cardsPack.gameState == GameState.Playing)
            {
                var singleAngle = 360f / cardsPack.cardsPack.Length;
                
                for (int i = 0; i < cardsPack.cardsPack.Length; ++i)
                {
                    var uiCard = mCardPool.Get();
                    uiCard.Show(CfgTool.Tables.TbGameCard.Get(cardsPack.cardsPack[i].cardId),cardsPack.cardsPack[i].cardRarity, singleAngle * i);
                    cards.Add(i,uiCard);
                }
            }
            else if(cardsPack.gameState == GameState.UnPlaying)
            {
                var singleAngle = 360f / cardsPack.cardsPack.Length;
                
                for (int i = 0; i < cardsPack.cardsPack.Length; ++i)
                {
                    var uiCard = mCardPool.Get();
                    uiCard.Show(CfgTool.Tables.TbUICard.Get(cardsPack.cardsPack[i].cardId), singleAngle * i);
                    cards.Add(i,uiCard);
                }
            }
        }
        
        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    } 
} 

