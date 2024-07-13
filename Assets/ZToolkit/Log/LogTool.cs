/*

这是一个核心层类
*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace ZToolKit
{   
    public static class LogTool
    {
        private static readonly Dictionary<Color, string> rColorMap = new Dictionary<Color, string>
        {
            { Color.black, "black" },
            { Color.cyan, "cyan" },
            { Color.green, "green" },
            { Color.magenta, "magenta" },
            { Color.red, "red" },
            { Color.white, "white" },
        };
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="headStr"></param>
        /// <param name="messageStr"></param>
        /// <param name="color">支持的颜色：black, cyan, green, magenta, red, white</param>
        public static void Log(string headStr, string messageStr, Color color = default)
        {
#if UNITY_EDITOR
            if (rColorMap.ContainsKey(color))
            {
                Debug.Log($"<color={rColorMap[color]}>[{headStr}]: {messageStr}</color>");
            }
            else
            {
                Debug.Log($"<color=white>[{headStr}]: {messageStr}</color>");
            }
#endif
        }

        public static void LogConfig(string headStr, string messageStr)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=yellow>[{headStr}]: {messageStr}</color>");
#endif
        }
        
        public static void LogError(string messageStr)
        {
#if UNITY_EDITOR
            Debug.LogError(messageStr);
#endif
        }
        
        public static void LogError(Exception messageStr)
        {
#if UNITY_EDITOR
            Debug.LogError(messageStr);
#endif
        }
    }
} 