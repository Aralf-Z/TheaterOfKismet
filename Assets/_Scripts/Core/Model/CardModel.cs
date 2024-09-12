/*

*/

using QFramework;
using UnityEngine;
using ZToolKit;

namespace Game.Core
{
   public class CardModel : AbstractModel
   {
      public BindableProperty<Vector2> dragDelta = new();
      
      public float ellipseA;
      public float ellipseB;

      public int playRound;

      public int curCard;
      
      protected override void OnInit()
      {
         ellipseA = 5;
         ellipseB = 2;
      }
   }
}