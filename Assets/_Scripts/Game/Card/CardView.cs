using UnityEngine;

namespace Game
{
	public class CardView : MonoBehaviour
	{
		public SpriteRenderer frame;

		public SpriteRenderer cardFace;
		
		/// <summary>
		/// 设置显示状态
		/// </summary>
		public void SetShow(float showRatio)
		{
			transform.localScale = showRatio * Vector3.one;
			frame.color = cardFace.color = Color.white * showRatio;
			//显示层级
			frame.sortingOrder = showRatio >= .9f ? 11 : 1;
			cardFace.sortingOrder = showRatio >= .9f ? 10 : 0;
		}
	}
}
