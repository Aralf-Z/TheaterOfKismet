/*

*/

using QFramework;
using Unity.VisualScripting;
using UnityEngine;

namespace TheaterOfKismet
{
    /// <summary>
    /// 游戏程序控制
    /// </summary>
    public class Game : MonoBehaviour
        , IController
    {
        private SaveUtility mSaveUtility;

        private void Start()
        {
            mSaveUtility = this.GetUtility<SaveUtility>();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
                mSaveUtility?.SaveGame();
        }

        private void OnApplicationQuit()
        {
            mSaveUtility?.SaveGame();
        }

        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    }
} 

