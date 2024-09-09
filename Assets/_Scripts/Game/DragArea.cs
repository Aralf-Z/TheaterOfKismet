using System;
using Game.Core;
using UnityEngine;
using QFramework;

namespace Game
{
	public class DragArea : MonoBehaviour
		, IController
	{
		

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
