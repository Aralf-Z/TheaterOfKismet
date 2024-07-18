/*

*/

using QFramework;
using UnityEngine;
using ZToolKit;

namespace TheaterOfKismet
{
   public class MainModel : AbstractModel
   {
      public BindableProperty<Vector2> dragDelta = new();

      public BindableProperty<Rect> dragRect = new();
      
      public float ellipseA;
      public float ellipseB;
      
      protected override void OnInit()
      {
         dragRect.Register(rect =>
         {
            ellipseA = rect.width / 2 * 5 / 6;
            ellipseB = rect.height / 2 * 5 / 6;
         });
      }
   }
}