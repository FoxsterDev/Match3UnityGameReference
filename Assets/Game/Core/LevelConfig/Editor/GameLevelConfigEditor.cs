//using System;

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Match3.GameCore
{
    /// <summary>
    /// Note: It’s strongly recommended to use the UI Toolkit to extend the Unity Editor,
    /// as it provides a more modern, flexible, and scalable solution than IMGUI.
    /// </summary>
    [CustomEditor(typeof(GameLevelConfig))]
    public sealed class GameLevelConfigEditor : Editor
    {
        List<Object> _blockPrefabs = new(10);
        SerializedProperty _blocks;
        List<Texture2D> _blocksPreviewImages = new();
        List<Object> _blocksPreviewObjects = new(10);
        SerializedProperty _rowCount;
        SerializedProperty _columnCount;

        int _columnCountPreview, _rowCountPreview;

        void OnEnable()
        {
            _rowCount = serializedObject.FindProperty(nameof(_rowCount));
            _columnCount = serializedObject.FindProperty(nameof(_columnCount));
            _blocks = serializedObject.FindProperty(nameof(_blocks));

            _columnCountPreview = _columnCount.intValue;
            _rowCountPreview = _rowCount.intValue;
            _blockPrefabs = AssetDatabaseExtension.FindAllPrefabsOfType<Object>("Assets/Game/Prefabs");
        }

        Object GetRandomBlock()
        {
            var index = Random.Range(0, _blockPrefabs.Count);
            return _blockPrefabs[index];
        }

        List<Object> GetRandomBlocksArray(uint size)
        {
            var objects = new List<Object>((int) size);
            while (size-- > 0)
            {
                objects.Add(GetRandomBlock());
            }

            return objects;
        }

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            serializedObject.Update();

            EditorGUILayout.HelpBox("PREVIEW", MessageType.Warning);

            _columnCountPreview = EditorGUILayout.IntSlider("Width preview: ", _columnCountPreview, 3, 10);
            _rowCountPreview = EditorGUILayout.IntSlider("Height preview: ", _rowCountPreview, 3, 10);
            var sizePreview = _columnCountPreview * _rowCountPreview;

            if (GUILayout.Button("Generate random preview"))
            {
                _blocksPreviewObjects = GetRandomBlocksArray((uint) sizePreview);
                _blocksPreviewImages = _blocksPreviewObjects.Select(AssetPreview.GetAssetPreview).ToList();
            }

            if (_blocksPreviewObjects.Count == sizePreview)
            {
                for (var row = 0; row < _rowCountPreview; row++)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (var col = 0; col < _columnCountPreview; col++)
                    {
                        var index = row * _columnCountPreview + col;
                        GUILayout.Label(_blocksPreviewImages[index], GUILayout.MaxHeight(25), GUILayout.MaxWidth(25));
                    }

                    EditorGUILayout.EndHorizontal();
                }

                if (GUILayout.Button("Save"))
                {
                    _columnCount.intValue = _columnCountPreview;
                    _rowCount.intValue = _rowCountPreview;

                    _blocks.ClearArray();
                    _blocks.arraySize = _columnCountPreview * _rowCountPreview;
                    for (var i = 0; i < _blocks.arraySize; i++)
                    {
                        var prefab = _blocks.GetArrayElementAtIndex(i).FindPropertyRelative("_prefab");
                        prefab.objectReferenceValue = _blocksPreviewObjects[i];
                    }

                    serializedObject.ApplyModifiedProperties();
                    EditorUtility.SetDirty(serializedObject.targetObject);
                }
            }

            EditorGUILayout.HelpBox("CURRENT STATE!", MessageType.Info);

            var columnCount = _columnCount.intValue;
            var rowCount = _rowCount.intValue;
            if (_blocks.arraySize == columnCount * rowCount)
            {
                for (var row = 0; row < rowCount; row++)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (var col = 0; col < columnCount; col++)
                    {
                        var index = row * columnCount + col;
                        var prefab = _blocks.GetArrayElementAtIndex(index).FindPropertyRelative("_prefab");
                        var preview = AssetPreview.GetAssetPreview(prefab.objectReferenceValue);
                        GUILayout.Label(preview, GUILayout.MaxHeight(25), GUILayout.MaxWidth(25));
                    }

                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}
