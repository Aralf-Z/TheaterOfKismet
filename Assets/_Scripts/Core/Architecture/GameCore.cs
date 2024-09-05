/*

*/

using QFramework;

namespace Game.Core
{   
    public class GameCore:
        Architecture<GameCore>
    {
        protected override void Init()
        {
            RegisterSystem(new CardSystem());
            RegisterModel(new CardModel());
        }
    }
} 