using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace TheaterOfKismet.UI
{
	public class MainUIData : UIPanelData
	{
	}
	public partial class MainUI : UIPanel
	{
		protected override void OnInit(IUIData uiData = null)
		{
			mData = uiData as MainUIData ?? new MainUIData();
			// please add init code here
		}
		
		protected override void OnOpen(IUIData uiData = null)
		{
		}
		
		protected override void OnShow()
		{
		}
		
		protected override void OnHide()
		{
		}
		
		protected override void OnClose()
		{
		}
	}
}
