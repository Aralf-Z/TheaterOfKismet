// Generate Id:4e00555a-5d49-4018-988d-8374334ada5f
using UnityEngine;

namespace TheaterOfKismet
{
	public partial class Card : QFramework.IController
	{

		public SpriteRenderer Frame;

		public SpriteRenderer CardFace;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>TheaterOfKismet.GameCore.Interface;
	}
}
