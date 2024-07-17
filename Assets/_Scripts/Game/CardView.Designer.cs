// Generate Id:130d6d21-77a8-4962-ad23-79e8b8786b1a
using UnityEngine;

namespace TheaterOfKismet
{
	public partial class CardView : QFramework.IController
	{

		public SpriteRenderer Frame;

		public SpriteRenderer CardFace;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>TheaterOfKismet.GameCore.Interface;
	}
}
