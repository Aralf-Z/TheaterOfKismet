using UnityEngine;
using QFramework;
using ZToolKit;

namespace TheaterOfKismet
{
	public partial class Card : MonoBehaviour, IController
	{
		public CardView View;
		public int moveSpeed = 10;
		private float mAngle = 0;
		
		private MainModel mMainModel;
		
		private void Start()
		{
			mMainModel = this.GetModel<MainModel>();

			mMainModel.dragDelta.Register(delta =>
			{
				var center = mMainModel.dragRect.Value.center;
				var deltaAngle = delta.x * moveSpeed;
				mAngle -= deltaAngle;

				float x = center.x + mMainModel.ellipseA * Mathf.Cos(Mathf.Deg2Rad * mAngle);
				float y = center.y + mMainModel.ellipseB * Mathf.Sin(Mathf.Deg2Rad * mAngle);

				var showRatio = (mMainModel.ellipseB - y + center.y) / (2 * mMainModel.ellipseB);
				
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
			View.SetShow(showRatio);
		}

		public IArchitecture GetArchitecture()
		{
			return GameCore.Interface;
		}
	}
}
