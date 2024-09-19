using QFramework;

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
    
    public abstract class GameStateHandlerBase
    {
        public abstract void OnEnter(CardSystem cardSystem);
        public abstract void OnExit(CardSystem cardSystem);
        public abstract void OnPlayACard(CardSystem cardSystem);
    }

    public class UIStateHandler: GameStateHandlerBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
            
        }

        public override void OnPlayACard(CardSystem cardSystem)
        {
            
        }
    }
    
    
    public class PlayingStateHandler: GameStateHandlerBase
    {
        public override void OnEnter(CardSystem cardSystem)
        {
            
        }

        public override void OnExit(CardSystem cardSystem)
        {
           
        }

        public override void OnPlayACard(CardSystem cardSystem)
        {
            
        }
    }
} 