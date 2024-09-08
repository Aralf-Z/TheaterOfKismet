using cfg;
using Game.Core;
using UnityEngine;
using QFramework;
using ZToolKit;

namespace Game
{
	public class Card : MonoBehaviour
		, IController
		,IObject<Card>
	{
		private const float kAngleOffset = +90;
		
		public CardView view;
		public int moveSpeed = 10;
		private float mAngle = 0;

		public void Init()
		{
			
		}
		
		/// <summary>
		/// 显示菜单功能牌
		/// </summary>
		/// <param name="uiCard"></param>
		/// <param name="angle"></param>
		public void Show(UICard uiCard, float angle)
		{
			var cardModel = this.GetModel<CardModel>();

			//angle是以y负半轴为0
			mAngle = angle + kAngleOffset;
			cardModel.dragDelta.RegisterWithInitValue(OnWheelMove);
		}

		/// <summary>
		/// 显示游戏卡牌
		/// </summary>
		/// <param name="gameCard"></param>
		/// <param name="rarity"></param>
		/// <param name="angle"></param>
		public void Show(GameCard gameCard, int rarity, float angle)
		{
			var cardModel = this.GetModel<CardModel>();

			//angle是以y负半轴为0
			mAngle = angle + kAngleOffset;
			cardModel.dragDelta.RegisterWithInitValue(OnWheelMove);
		}
		
		/// <summary>
		/// 设置表现
		/// </summary>
		/// <param name="showRatio">0-1的参数</param>
		private void SetShow(float showRatio)
		{
			showRatio = Mathf.Clamp01((showRatio + 4f) /5f);
			view.SetShow(showRatio);
		}
		
		private void OnWheelMove(Vector2 delta)
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
		}

		public IArchitecture GetArchitecture()
		{
			return GameCore.Interface;
		}

		public bool IsCollected { get; set; }
		
		public void OnRecycle()
		{
			var cardModel = this.GetModel<CardModel>();

			cardModel.dragDelta.UnRegister(OnWheelMove);
		}
	}
}
