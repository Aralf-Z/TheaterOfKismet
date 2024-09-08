using System;
using Game.Core;
using UnityEngine;
using QFramework;

namespace Game
{
	public class DragArea : MonoBehaviour
		, IController
	{
		private Camera mMainCamera;
		private LayerMask mLayerMask;
		
		private Vector2 mPrePosition;

		private void Start()
		{
			mMainCamera = Camera.main;
			mLayerMask = LayerMask.GetMask("DragArea");
		}

		public void OnUpdate()
		{
			if (Input.GetMouseButtonDown(0))//鼠标按下时
			{
				mPrePosition = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
			}
			else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)//触摸屏按下时
			{
				mPrePosition = Input.GetTouch(0).position;
			}
			else if (Input.GetMouseButton(0))//鼠标按住时
			{
				var pos = mMainCamera.ScreenToWorldPoint(Input.mousePosition);
				SetDelta(pos);
			}
			else if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)//触摸屏按住时
			{
				var pos = Input.GetTouch(0).position;
				SetDelta(pos);
			}
			else if (Input.GetMouseButtonUp(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)//鼠标抬起时 || 触摸屏抬起时
			{
				mPrePosition = Vector2.zero;
			}
		}

		private void SetDelta(Vector2 pos)
		{
			var hit = Physics2D.Raycast(pos, Vector2.zero, 2f, mLayerMask);

			if (hit.collider is not null)
			{
				var cardSystem = this.GetSystem<CardSystem>();
				cardSystem.OnDragCardWheel(pos - mPrePosition);
				mPrePosition = pos;
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			
		}
#endif
		public IArchitecture GetArchitecture()
		{
			return GameCore.Interface;
		}
	}
}
