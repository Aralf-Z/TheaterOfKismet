using UnityEngine;
using QFramework;

namespace TheaterOfKismet
{
	public partial class Card : ViewController
	{
		void Start()
		{
			
		}

		/// <summary>
		/// 设置显示
		/// </summary>
		/// <param name="showing"></param>
		public void SetShowing(bool showing)
		{
			CardFace.sortingLayerName = showing ? "ShowingCard" : "HidingCard";
			Frame.sortingLayerName = showing ? "ShowingCard" : "HidingCard";
		}
	}
}
