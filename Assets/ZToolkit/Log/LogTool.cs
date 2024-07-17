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
        public static void Log(string headStr, string messageStr, Color color = default)
        {
#if UNITY_EDITOR
            Debug.Log($"<color={color.ToHex()}>[{headStr}]: {messageStr}</color>");
#endif
        }

        public static void LogConfig(string headStr, string messageStr)
        {
#if UNITY_EDITOR
            Debug.Log($"<color=#bd868dff>[{headStr}]: {messageStr}</color>");
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