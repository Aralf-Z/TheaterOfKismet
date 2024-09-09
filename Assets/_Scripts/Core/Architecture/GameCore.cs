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
            RegisterModel(new CardModel());
            RegisterSystem(new CardSystem());
        }
    }
} 