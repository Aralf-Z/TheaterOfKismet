using System.IO;
using Newtonsoft.Json;
using UnityEditor;
/*

*/

using UnityEngine;
using Object = UnityEngine.Object;

namespace ZToolKit.Editor
{
    public class ResourcesPostProcessor : AssetPostprocessor
    {
        private const string kResourcesFileHeader = "Assets/Resources/";
        
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, "AllResPathData.json");
            AllResourcesNamePathPairs allAssetDatas;
            
            if (File.Exists(filePath)) allAssetDatas = JsonConvert.DeserializeObject<AllResourcesNamePathPairs>(File.ReadAllText(filePath));
            else allAssetDatas = new AllResourcesNamePathPairs();

            if (importedAssets.Length > 0)
                ProcessNewResourcesAssetsImport(importedAssets, allAssetDatas);

            if (deletedAssets.Length > 0)
                ProcessResourcesAssetsDelete(deletedAssets, allAssetDatas);

            if (movedFromAssetPaths.Length > 0)
                ProcessResourcesAssetsDelete(movedFromAssetPaths, allAssetDatas);

            if (movedAssets.Length > 0)
                ProcessNewResourcesAssetsImport(movedAssets, allAssetDatas);
            
            //重新写入资源表
            File.WriteAllText(filePath, JsonConvert.SerializeObject(allAssetDatas));
            AssetDatabase.Refresh();
        }

        private static void ProcessNewResourcesAssetsImport(string[] importedAssets, AllResourcesNamePathPairs allAssetDatas)
        {
            foreach (var t in importedAssets)
            {
                if (!t.StartsWith(kResourcesFileHeader)) continue;
                string subPath = t.Substring(kResourcesFileHeader.Length);
                string[] subS = subPath.Split('.');
                if (subS.Length == 1) continue;
                string assetName = AssetDatabase.LoadAssetAtPath<Object>(t).name;
                
                allAssetDatas.AddPair(assetName,subS[0]);
            }
        }

        private static void ProcessResourcesAssetsDelete(string[] deletedAssets, AllResourcesNamePathPairs allAssetDatas)
        {
            foreach (var t in deletedAssets)
            {
                if (!t.StartsWith(kResourcesFileHeader)) continue;
                string subPath = t.Substring(kResourcesFileHeader.Length);
                string[] subS = subPath.Split('.');
                if (subS.Length == 1) continue;
                string[] subSpltStr = subS[0].Split('/');
                string assetName = subSpltStr[^1];

                if(allAssetDatas.ContainsRes(assetName)) allAssetDatas.RemovePair(assetName, subS[0]);
            }
        }
    }
}
