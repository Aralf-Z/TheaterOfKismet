using UnityEngine;
using QFramework;

namespace TheaterOfKismet
{
	public partial class CardView : MonoBehaviour
	{
		public SpriteRenderer Frame;

		public SpriteRenderer CardFace;
		
		/// <summary>
		/// 设置显示状态
		/// </summary>
		public void SetShow(float showRatio)
		{
			//todo show可以改成一个线性值用来做大小颜色的渐变
			
			//todo 大小、颜色
			transform.localScale = showRatio * Vector3.one;
			//显示层级
			Frame.sortingOrder = showRatio >= .9f ? 10 : 0;
			CardFace.sortingOrder = showRatio >= .9f ? 10 : 0;
		}
	}
}
