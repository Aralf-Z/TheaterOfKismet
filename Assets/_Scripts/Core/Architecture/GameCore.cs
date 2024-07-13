/*

*/

using QFramework;

namespace TheaterOfKismet
{   
    public class GameCore:
        Architecture<GameCore>
    {
        protected override void Init()
        {
            RegisterUtility(new SaveUtility());
        }
    }
} 