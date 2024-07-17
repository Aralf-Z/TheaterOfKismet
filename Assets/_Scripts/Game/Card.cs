using UnityEngine;
using QFramework;

namespace TheaterOfKismet
{
	public partial class Card : ViewController
	{
		void Start()
		{
			var model = this.GetModel<MainModel>();

			model.dragDelta.Register(delta =>
			{
				var screenPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);
				var wheelPosX = 
					Mathf.Clamp(screenPos.x + delta.x, -model.wheelXMin, model.wheelXMax);
				var wheelPosY = model.cardWheel.GetYFromX(wheelPosX);

				transform.position =
					UnityEngine.Camera.main.ScreenToWorldPoint(new Vector3(wheelPosX, wheelPosY.yMax));
			});
		}
	}
}
