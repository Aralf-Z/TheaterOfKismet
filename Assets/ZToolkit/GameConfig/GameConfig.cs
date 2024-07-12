/*
*/

using UnityEngine;

namespace ZToolKit
{   
    public enum SaveFolder
    {
        /// <summary> 设备默认位置 </summary>
        Device = 1,

        /// <summary> 游戏文件位置 </summary>
        Game = 2
    }
    
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Config/GameConfig", order = 0)]
    public class GameConfig: ScriptableObject
    {
        [Tooltip("存档存储位置")]
        public SaveFolder saveFolder = SaveFolder.Game;
    }
} 