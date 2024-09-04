using System;
using UnityEngine;
using QFramework;

namespace TheaterOfKismet
{
	public partial class DragArea : MonoBehaviour, IController
	{
		private MainModel mMainModel;

		private UnityEngine.Camera mMainCamera;
		private LayerMask mLayerMask;
		
		private Vector2 mPrePosition;
		
		public UnityEngine.BoxCollider2D SelfBoxCollider2D;
		
		private void Start()
		{
			mMainModel = this.GetModel<MainModel>();
			mMainCamera = UnityEngine.Camera.main;
			mLayerMask = LayerMask.GetMask("DragArea");
			
			// var center = (Vector2)transform.position + SelfBoxCollider2D.offset;
			// var width = SelfBoxCollider2D.size.x;
			// var height = SelfBoxCollider2D.size.y;
			
			var center = Vector2.zero;
			var width = 12f;
			var height = 6f;
			
			mMainModel.dragRect.Value = new Rect(center.x - width / 2, center.y - height / 2, width, height);
		}

		private void Update()
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
				mMainModel.dragDelta.Value = pos - mPrePosition;
				mPrePosition = pos;
			}
		}

#if UNITY_EDITOR
		private void OnDrawGizmos()
		{
			var center = (Vector2)transform.position + SelfBoxCollider2D.offset;
			var size = SelfBoxCollider2D.size;
			var leftUp = new Vector2(center.x - size.x / 2, center.y + size.y / 2);
			var leftDown = new Vector2(center.x - size.x / 2, center.y - size.y / 2);
			var rightUp = new Vector2(center.x + size.x / 2, center.y + size.y / 2);
			var rightDown = new Vector2(center.x + size.x / 2, center.y - size.y / 2);
			
			Gizmos.color = Color.green;
			
			Gizmos.DrawLine(leftUp, rightUp);
			Gizmos.DrawLine(rightUp, rightDown);
			Gizmos.DrawLine(rightDown, leftDown);
			Gizmos.DrawLine(leftDown, leftUp);
		}
#endif
		public IArchitecture GetArchitecture()
		{
			return GameCore.Interface;
		}
	}
}
