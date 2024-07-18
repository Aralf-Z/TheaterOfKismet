using System;
using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace TheaterOfKismet.UI
{
	// Generate Id:372c9169-6763-49d2-b3b6-df182065c4cc
	public partial class MainUI
	{
		public const string Name = "MainUI";
		
		
		private MainUIData mPrivateData = null;
		
		protected override void ClearUIComponents()
		{
			
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
