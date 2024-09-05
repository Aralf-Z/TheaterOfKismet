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
			//todo show可以改成一个线性值用来做大小颜色的渐变
			
			//todo 大小、颜色
			transform.localScale = showRatio * Vector3.one;
			//显示层级
			frame.sortingOrder = showRatio >= .9f ? 11 : 1;
			cardFace.sortingOrder = showRatio >= .9f ? 10 : 0;
		}
	}
}
