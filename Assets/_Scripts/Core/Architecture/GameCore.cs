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
            //系统注册
            RegisterSystem(new GameStateSystem());

            //数据注册
            RegisterModel(new MainModel());
            
            //工具注册
            RegisterUtility(new SaveUtility());
        }
    }
} 