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
	,IPointerClickHandler
	{
		private MainModel mMainModel;

		private Vector3 mPreMousePos;
		
		private void Start()
		{
			mMainModel = this.GetModel<MainModel>();
		}

		private void Update()
		{
			if (Input.GetMouseButton(0))
			{
				var mousePos = Input.mousePosition;

				mMainModel.dragDirection.Value = mousePos.x - mPreMousePos.x;

				mPreMousePos = mousePos;
			}
			else
			{
				mMainModel.dragDirection.Value = 0;
			}
		}

		
		//下面3个接口我不知道为什么不能用，很奇怪
		public void OnBeginDrag(PointerEventData eventData)
		{
			Debug.Log("start");
			if (eventData.IsMouseLeft())
			{
				mMainModel.dragDirection.Value = 0;
				
				mPreMousePos = Input.mousePosition;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			Debug.Log("dragging");
			if (eventData.IsMouseLeft())
			{
				var mousePos = Input.mousePosition;

				mMainModel.dragDirection.Value = mousePos.x - mPreMousePos.x;

				mPreMousePos = mousePos;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			Debug.Log("end");
			if (eventData.IsMouseLeft())
			{
				mMainModel.dragDirection.Value = 0;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			Debug.Log("onclick");
		}
	}
}
