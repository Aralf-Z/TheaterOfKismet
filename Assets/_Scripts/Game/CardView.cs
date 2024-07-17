using UnityEngine;
using QFramework;

namespace TheaterOfKismet
{
	public partial class CardView : ViewController
	{
		void Start()
		{
			// Code Here
		}
		
		/// <summary>
		/// 设置显示状态
		/// </summary>
		/// <param name="show"></param>
		public void SetShow(bool show)
		{
			//todo show可以改成一个线性值用来做大小颜色的渐变
			
			//todo 大小、颜色
			
			//显示层级
			Frame.sortingOrder = show ? 10 : 0;
			CardFace.sortingOrder = show ? 10 : 0;
		}
	}
}
