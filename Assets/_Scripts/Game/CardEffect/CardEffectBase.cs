using System;
using System.Collections.Generic;
using System.Linq;
using cfg;
using QFramework;
using ZToolKit;

namespace Game.Core
{
    public static class CardEffects
    {
        public static Dictionary<int, CardEffectBase> CardEffectMap;
        
        public static void Init()
        {
            var types = typeof(CardEffectBase).Assembly
                .GetTypes()
                .Where(t => typeof(CardEffectBase).IsAssignableFrom(t) && !t.IsAbstract);
            foreach (var t in types)
            {
                if(Activator.CreateInstance(t) is not CardEffectBase cardEffect)
                {continue;}
                CardEffectMap.Add(cardEffect.CardId, cardEffect);
            }
        }
    }

    public abstract class CardEffectBase:
        ICanGetSystem
    {
        public abstract int CardId { get; }
        public abstract void PlayUp(Card card);
        public abstract void PlayDown(Card card);
        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    }

    public abstract class CardEffect_DownDiscard: CardEffectBase
    {
        protected GameCard mGameCard => CfgTool.Tables.TbGameCard[CardId];
        
        public override void PlayDown(Card card) { }
    }

    public class CardEffect_201 : CardEffect_DownDiscard
    {
        public override int CardId => 201;

        public override void PlayUp(Card card)
        {
            this.GetSystem<GamePlaySystem>()
                .AddBuff(new Buff_201(mGameCard.Paras[card.Rarity][0], mGameCard.Paras[card.Rarity][1]));
        }
    }

    public class CardEffect_202 : CardEffect_DownDiscard
    {
        public override int CardId => 202;
        
        public override void PlayUp(Card card)
        {
            
        }
    }
    
    public class CardEffect_203 : CardEffect_DownDiscard
    {
        public override int CardId => 203;
        
        public override void PlayUp(Card card)
        {
            
        }
    }
} 