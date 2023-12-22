using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Match3.GameCore
{
    public static class AssetDatabaseExtension
    {
        public static List<T> FindAllPrefabsOfType<T>(params string[] folders) where T : Object
        {
            return FindAllAssetsOfType<T>("t:Prefab", folders);
        }

        public static List<T> FindAllAssetsOfType<T>(string filter, string[] folders) where T : Object
        {
            var list = new List<T>();
            var guids = AssetDatabase.FindAssets(filter, folders);
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var obj = AssetDatabase.LoadAssetAtPath<T>(assetPath);

                if (obj != null)
                {
                    list.Add(obj);
                }
            }

            return list;
        }
    }
}
