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
        SerializedProperty _height;
        SerializedProperty _width;

        int _widthPreview, _heightPreview;

        void OnEnable()
        {
            _height = serializedObject.FindProperty(nameof(_height));
            _width = serializedObject.FindProperty(nameof(_width));
            _blocks = serializedObject.FindProperty(nameof(_blocks));

            _widthPreview = _width.intValue;
            _heightPreview = _height.intValue;
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

            _widthPreview = EditorGUILayout.IntSlider("Width preview: ", _widthPreview, 3, 10);
            _heightPreview = EditorGUILayout.IntSlider("Height preview: ", _heightPreview, 3, 10);
            var sizePreview = _widthPreview * _heightPreview;

            if (GUILayout.Button("Generate random preview"))
            {
                _blocksPreviewObjects = GetRandomBlocksArray((uint)sizePreview);
                _blocksPreviewImages = _blocksPreviewObjects.Select(AssetPreview.GetAssetPreview).ToList();
            }

            if (_blocksPreviewObjects.Count == sizePreview)
            {
                for (var row = 0; row < _heightPreview; row++)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (var col = 0; col < _widthPreview; col++)
                    {
                        var index = row * _widthPreview + col;
                        GUILayout.Label(_blocksPreviewImages[index], GUILayout.MaxHeight(25), GUILayout.MaxWidth(25));
                    }

                    EditorGUILayout.EndHorizontal();
                }

                if (GUILayout.Button("Save"))
                {
                    _width.intValue = _widthPreview;
                    _height.intValue = _heightPreview;

                    _blocks.ClearArray();
                    _blocks.arraySize = _widthPreview * _heightPreview;
                    for (var i = 0; i < _blocks.arraySize; i++)
                    {
                        var prefab = _blocks.GetArrayElementAtIndex(i).FindPropertyRelative("_prefab");
                        prefab.objectReferenceValue = _blocksPreviewObjects[i];
                    }
                }
            }

            EditorGUILayout.HelpBox("CURRENT STATE!", MessageType.Info);

            serializedObject.ApplyModifiedProperties();
            var width = _width.intValue;
            var height = _height.intValue;
            if (_blocks.arraySize == width * height)
            {
                for (var row = 0; row < height; row++)
                {
                    EditorGUILayout.BeginHorizontal();
                    for (var col = 0; col < width; col++)
                    {
                        var index = row * width + col;
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
