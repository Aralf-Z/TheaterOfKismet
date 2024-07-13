/*

*/

using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace ZToolKit
{
    public static class ResTool
    {
        private static readonly Dictionary<string, string> rNamePathDic;

        static ResTool()
        {
            var jsonString = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "AllResPathData.json"));
            rNamePathDic = JsonConvert.DeserializeObject<AllResourcesNamePathPairs>(jsonString)?.namePathDic;
        }

        public static T Load<T>(string prefabName) where T : Object
        {
            if (rNamePathDic.ContainsKey(prefabName))
            {
                return Resources.Load<T>(rNamePathDic[prefabName]);
            }
            
            LogTool.LogError($"ResLoad---Failed To Load {prefabName}");
            return null;
        }
    }
}