/*

*/

using QFramework;
using UnityEngine;

namespace TheaterOfKismet
{
    /// <summary>
    /// 游戏入口，初始化用
    /// </summary>
    /// <remarks>
    /// 请不要在场景内的其他mono脚本使用awake，可能会导致初始化冲突
    /// </remarks>
    public class GameEntry: MonoBehaviour
    , IController
    {
         private void Awake()
         {
             var saveUtility = this.GetUtility<SaveUtility>();
             
             saveUtility.LoadGame();

             var game = new GameObject("Game");
             game.AddComponent<Game>();
         }
          
         public IArchitecture GetArchitecture()
         {
             return GameCore.Interface;
         }
    } 
} 

