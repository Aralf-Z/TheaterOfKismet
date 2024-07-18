// Generate Id:bccb0844-2cf9-4a6a-acf0-b539e022f23b
using UnityEngine;

namespace TheaterOfKismet
{
	public partial class DragArea : QFramework.IController
	{

		public UnityEngine.BoxCollider2D SelfBoxCollider2D;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>TheaterOfKismet.GameCore.Interface;
	}
}
