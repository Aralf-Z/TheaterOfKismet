/*

*/

using QFramework;
using ZToolKit;

namespace TheaterOfKismet
{
   public class SaveUtility : IUtility
   {
      public static Save save = new();

      /// <summary>
      /// 加载游戏
      /// </summary>
      public void LoadGame()
      {
         save = GameSave.LoadGame<Save>();
      }
      
      /// <summary>
      /// 存储游戏
      /// </summary>
      public void SaveGame()
      {
         GameSave.SaveGame(save);
      }
   }
}