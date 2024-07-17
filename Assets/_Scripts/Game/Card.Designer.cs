// Generate Id:0a42aac9-39b0-4a67-817c-27264ae0d032
using UnityEngine;

namespace TheaterOfKismet
{
	public partial class Card : QFramework.IController
	{

		public CardView View;

		QFramework.IArchitecture QFramework.IBelongToArchitecture.GetArchitecture()=>TheaterOfKismet.GameCore.Interface;
	}
}
