using QFramework;
using ZToolKit;

namespace Game.Core
{   
    public class GameCardMgr: CardsMgr
    {
        public void ResetCards((int cardId, int cardRarity)[]  cardsPack)
        {
            mCardPool.Recycle(mCards.Values);
            mCards.Clear();
            
            var singleAngle = 360f / cardsPack.Length;

            for (int i = 0; i < cardsPack.Length; ++i)
            {
                var uiCard = mCardPool.Get();
                uiCard.Show(CfgTool.Tables.TbGameCard.Get(cardsPack[i].cardId), cardsPack[i].cardRarity, singleAngle * i, i);
                mCards.Add(i, uiCard);
            }
        }
    }
} 