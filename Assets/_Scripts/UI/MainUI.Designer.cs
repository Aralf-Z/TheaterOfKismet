using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace TheaterOfKismet.UI
{
	// Generate Id:ea8089b5-4e31-46f7-ba92-dc2a248c54e0
	public partial class MainUI
	{
		public const string Name = "MainUI";
		
		[SerializeField]
		public MainUI_DragArea DragArea;
		
		private MainUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			DragArea = null;
			
			mData = null;
		}
		
		public MainUIData Data
		{
			get
			{
				return mData;
			}
		}
		
		MainUIData mData
		{
			get
			{
				return mPrivateData ?? (mPrivateData = new MainUIData());
			}
			set
			{
				mUIData = value;
				mPrivateData = value;
			}
		}
	}
}
