using QFramework;
using UnityEngine;

namespace Game.Core
{
   public class CardSystem : AbstractSystem
   {
      protected override void OnInit()
      {
          
      }

      public void OnDrag(Vector2 dragDelta)
      {
         this.GetModel<CardModel>().dragDelta.Value = dragDelta;
      }
   }
}