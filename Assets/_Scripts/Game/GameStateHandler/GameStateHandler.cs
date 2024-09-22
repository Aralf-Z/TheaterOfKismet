using System.Collections.Generic;
using System.Linq;
using cfg;
using QFramework;
using UnityEngine;
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
        UI
    }
    
    public abstract class GameStateHandlerBase:
        ICanGetSystem
    {
        protected virtual CardsMgr mCardsMgr { get; set; }

        public int CurCard { get; private set; }
        
        public abstract void OnEnter();
        public abstract void OnExit();

        public virtual float GetCurCardAngle()
        {
            return mCardsMgr.GetCard(CurCard).Angle;
        }

        public virtual void UpdateCurCard()
        {
            var angle = float.MaxValue;
            
            foreach (var cardKV in mCardsMgr.Cards)
            {
                var angleDelta = Mathf.Abs(cardKV.Value.Angle - 360);
                
                if (angle > angleDelta)
                {
                    angle = angleDelta;
                    CurCard = cardKV.Key;
                }
                
                //Debug.Log(cardKV.Value.Angle + "----" + angleDelta + "----" + cardKV.Key);
            }
        }

        public abstract void PlayCurCardUp();
        public abstract void PlayCurCardDown();
        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    }

    public sealed class UIStateHandler: GameStateHandlerBase
    {
        private TbUICfg mUICfg => CfgTool.Tables.TbUICfg;
        private string mCurUI;
        
        private UICardsMgr mUICardsMgr;

        protected override CardsMgr mCardsMgr => mUICardsMgr;

        public UIStateHandler(UICardsMgr cardsMgr)
        {
            mUICardsMgr = cardsMgr;
            mCurUI = mUICfg.DataList.FirstOrDefault()?.Menus;
        }
        
        public override void OnEnter()
        {
            var cards = mUICfg[mCurUI].Cards;
            mUICardsMgr.ResetCards(cards);
        }

        public override void OnExit()
        {
            
        }

        public override void PlayCurCardUp()
        {
            var card = mCardsMgr.RemoveCard(CurCard);
            card.CardEffect.PlayUp(card);
        }

        public override void PlayCurCardDown()
        {
            var card = mCardsMgr.RemoveCard(CurCard);
            card.CardEffect.PlayDown(card);
        }
    }
    
    
    public sealed class PlayingStateHandler: GameStateHandlerBase
    {
        
        private GameCardMgr mGameCardsMgr;
        
        protected override CardsMgr mCardsMgr => mGameCardsMgr;
        
        public int playRound;

        public PlayingStateHandler(GameCardMgr cardMgr)
        {
            mGameCardsMgr = cardMgr;
        }

        public override void OnEnter()
        {
            
        }

        public override void OnExit()
        {
           
        }

        public override void PlayCurCardUp()
        {
            var card = mCardsMgr.RemoveCard(CurCard);
            card.CardEffect.PlayUp(card);
            this.GetSystem<GamePlaySystem>().CardPlayed(card);
        }

        public override void PlayCurCardDown()
        {
            
        }
    }
} 