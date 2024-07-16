/*

*/

using QFramework;

namespace TheaterOfKismet
{   
    public class PrologStateHandler : StateHandlerBase
    {
        public PrologStateHandler(GameStateSystem stateSystem) : base(stateSystem)
        {
        }

        public override void OnEnter(CardWheel cardWheel, CardGenerator cardGenerator)
        {
            cardWheel.clear_cards();
            cardWheel.clear_stack();
            //UI.get_ui().hide_all();
            //todo Main.get_main().GetNode<Prolog>("UISprites/Prolog").start_prolog();
        }

        public override void CheckState(CardEvent cardEvent, LevelManager levelManager)
        {
            if (cardEvent != null)
            {
                if (cardEvent.event_type == CardEvent.Type.GameStart)
                {
                    mStateSystem.event_discard();
                    //get_in_state(GameStateLabel.Start);
                }
            }
        }

        public override void DoState(CardEvent cardEvent, LevelManager levelManager)
        {
            
        }
    }
} 