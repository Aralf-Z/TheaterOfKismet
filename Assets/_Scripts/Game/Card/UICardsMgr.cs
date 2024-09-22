using QFramework;
using ZToolKit;

namespace Game.Core
{   
    public class UICardsMgr: CardsMgr
    {
        public void ResetCards(int[] cards)
        {
            mCardPool.Recycle(mCards.Values);
            mCards.Clear();

            var singleAngle = 360f / cards.Length;

            for (int i = 0; i < cards.Length; ++i)
            {
                var uiCard = mCardPool.Get();
                uiCard.Show(CfgTool.Tables.TbUICard.Get(cards[i]), singleAngle * i, i);
                mCards.Add(i, uiCard);
            }
        }
    }
} 