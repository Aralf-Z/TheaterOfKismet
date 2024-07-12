/*

这是一个核心层类
*/

using UnityEngine;

namespace ZToolKit
{   
    public static class LogTool
    {
        public enum LogColor
        {
            Yellow,
            Red,
            White,
            Cyan,
            Green,
            Magenta,
        }

        public static void LogWithColor(LogColor color, string headStr, string messageStr)
        {
#if UNITY_EDITOR
            Debug.Log($"<color={color.ToString()}>[{headStr}]: {messageStr}</color>");
#endif
        }
    }
} 