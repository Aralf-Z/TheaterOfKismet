/*

*/

using QFramework;
using UnityEngine;

namespace TheaterOfKismet
{
   public class MainModel : AbstractModel
   {
      public BindableProperty<Vector2> dragDelta = new();

      public BindableProperty<Rect> dragRect = new();

      public Ellipse cardWheel;

      public float wheelXMin;
      public float wheelXMax;
      
      protected override void OnInit()
      {
          dragRect.RegisterWithInitValue(rect =>
          {
              var resolution = UIKit.Config.Root.CanvasScaler.referenceResolution;
              var xDelta = -resolution.x / 2;
              var yDelta = -resolution.y / 2;
              var ellipseA = dragRect.Value.width / 4;
              var ellipseB = dragRect.Value.height / 4;

              cardWheel = new Ellipse(ellipseA, ellipseB, xDelta, yDelta);
              wheelXMin = -xDelta - ellipseA;
              wheelXMax = -xDelta + ellipseB;
          });
      }
   }
}