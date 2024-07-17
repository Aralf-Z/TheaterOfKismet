using UnityEngine;
using QFramework;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ZToolKit;

namespace TheaterOfKismet.UI
{
	public partial class MainUI_DragArea : ViewController
	,IBeginDragHandler
	,IDragHandler
	,IEndDragHandler
	{
		private MainModel mMainModel;

		private RectTransform mRectTransf;

		private void Start()
		{
			mMainModel = this.GetModel<MainModel>();

			mRectTransf = transform.GetComponent<RectTransform>();

			mMainModel.dragRect.Value = mRectTransf.rect;

			//transform.GetComponent<Image>().color = new Color(0, 0, 0, 0);
		}

		/// <summary>
		/// 分辨率修改时
		/// </summary>
		public void OnResolutionChange()
		{
			mMainModel.dragRect.Value = mRectTransf.rect;
		}
		
		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.IsPointerLegal())
			{
				mMainModel.dragDelta.Value = eventData.delta;
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (eventData.IsPointerLegal())
			{
				mMainModel.dragDelta.Value = eventData.delta;
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (eventData.IsPointerLegal())
			{
				mMainModel.dragDelta.Value = eventData.delta;
			}
		}
	}
}
