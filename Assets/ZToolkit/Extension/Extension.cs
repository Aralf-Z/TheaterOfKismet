/*

*/

using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ZToolKit
{
    public enum Date
    {
        Year, Month, Day, Hour, Minute, Second
    }
    
    public static class Extension
    {
        public static bool IsMouseLeft(this PointerEventData eventData)
        {
            return eventData.button == PointerEventData.InputButton.Left;
        }
        
        public static bool IsMouseRight(this PointerEventData eventData)
        {
            return eventData.button == PointerEventData.InputButton.Right;
        }

        public static bool IsMouseMiddle(this PointerEventData eventData)
        {
            return eventData.button == PointerEventData.InputButton.Middle;
        }

        public static DateTime String2DatDateTime(this string time)
        {
            if (DateTime.TryParseExact(time, "yyyy-MM-dd-HH-mm-ss", null, System.Globalization.DateTimeStyles.None, out var parsedTime1))
                return parsedTime1;
            if (DateTime.TryParseExact(time, "yyyy-MM-dd-HH-mm", null, System.Globalization.DateTimeStyles.None, out var parsedTime2))
                return parsedTime2;
            if (DateTime.TryParseExact(time, "yyyy-MM-dd-HH", null, System.Globalization.DateTimeStyles.None, out var parsedTime3))
                return parsedTime3;
            if (DateTime.TryParseExact(time, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out var parsedTime4))
                return parsedTime4;
            if (DateTime.TryParseExact(time, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out var parsedTime5))
                return parsedTime5;
            if (DateTime.TryParseExact(time, "yyyy", null, System.Globalization.DateTimeStyles.None, out var parsedTime6))
                return parsedTime6;
            
            Debug.LogError("Wrong TimeString, Failed to parse DateTime from string");
            return default;
        }
    }
}