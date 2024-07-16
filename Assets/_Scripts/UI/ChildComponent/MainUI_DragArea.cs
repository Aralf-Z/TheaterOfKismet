using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;
using ZToolKit;

namespace TheaterOfKismet.UI
{
	public partial class MainUI_DragArea : ViewController
	,IBeginDragHandler
	,IDragHandler
	,IEndDragHandler
	{
		private MainModel mMainModel;

		private Vector3 mPreMousePos;
		
		private void Start()
		{
			mMainModel = this.GetModel<MainModel>();
		}
		
		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.IsMouseLeft())
			{
				mMainModel.dragDirection.Value = 0;
				
				mPreMousePos = Input.mousePosition;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.IsMouseLeft())
			{
				var mousePos = Input.mousePosition;

				mMainModel.dragDirection.Value = mousePos.x - mPreMousePos.x;

				mPreMousePos = mousePos;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.IsMouseLeft())
			{
				mMainModel.dragDirection.Value = 0;
			}
		}
	}
}
