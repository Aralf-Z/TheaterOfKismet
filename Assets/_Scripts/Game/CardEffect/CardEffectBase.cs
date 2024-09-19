using System;
using System.Collections.Generic;
using System.Linq;
using QFramework;

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

    public abstract class CardEffectBase
    {
        public abstract int CardId { get; }
        public abstract void PlayUp();
        public abstract void PlayDown();
    }

    public abstract class GameCardEffectBase: CardEffectBase
    {
        public override void PlayDown()
        { }
    }
} 