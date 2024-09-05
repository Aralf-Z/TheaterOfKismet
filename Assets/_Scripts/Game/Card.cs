using Game.Core;
using UnityEngine;
using QFramework;

namespace Game
{
	public class Card : MonoBehaviour, IController
	{
		public CardView view;
		public int moveSpeed = 10;
		private float mAngle = 0;

		public void Init(float initialAngle)
		{
			mAngle = initialAngle;
		}
		
		private void Start()
		
		{
			var cardModel = this.GetModel<CardModel>();

			cardModel.dragDelta.RegisterWithInitValue(delta =>
			{
				var move = this.GetModel<CardModel>();

				var center = Vector2.zero;
				var deltaAngle = delta.x * moveSpeed;
				mAngle -= deltaAngle;

				float x = center.x + move.ellipseA * Mathf.Cos(Mathf.Deg2Rad * mAngle);
				float y = center.y + move.ellipseB * Mathf.Sin(Mathf.Deg2Rad * mAngle);

				var showRatio = (move.ellipseB - y + center.y) / (2 * move.ellipseB);
				
				SetShow(showRatio);
				
				transform.position = new Vector3(x, y, 0f);
			});
		}

		/// <summary>
		/// 设置表现
		/// </summary>
		/// <param name="showRatio">0-1的参数</param>
		public void SetShow(float showRatio)
		{
			showRatio = Mathf.Clamp01((showRatio + 4f) /5f);
			view.SetShow(showRatio);
		}

		public IArchitecture GetArchitecture()
		{
			return GameCore.Interface;
		}
	}
}
