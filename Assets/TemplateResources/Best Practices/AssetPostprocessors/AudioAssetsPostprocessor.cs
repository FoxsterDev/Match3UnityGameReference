using System;
using UnityEditor;
using UnityEngine;
using System.IO;

public class AudioAssetsPostprocessor : AssetPostprocessor
{
    private const float MIN_SIZE = 200;
    private const float MAX_SIZE = 5120;
    private const float QUALITY = .66f;

    private void OnPreprocessAudio()
    {
        var audioImporter = (AudioImporter)assetImporter;
        FixAsset(assetPath, audioImporter);
    }

    [MenuItem("Tools/Postprocessors/AudioPostprocessor Apply For All")]
    public static void Apply()
    {
        var guids = AssetDatabase.FindAssets("t:AudioClip", null);
        foreach (var guid in guids)
        {
            var assetPath = AssetDatabase.GUIDToAssetPath(guid);
            var audioImporter = AssetImporter.GetAtPath(assetPath) as AudioImporter;
            FixAsset(assetPath, audioImporter);
            EditorUtility.SetDirty(audioImporter);
            Debug.Log("AudioPostprocessor " + assetPath);
        }

        AssetDatabase.SaveAssets();
    }

    private static void FixAsset(string path, AudioImporter audioImporter)
    {
        var fileInfo = new FileInfo(path);
        var fileSize = (float)fileInfo.Length / 1024;

        audioImporter.loadInBackground = true;


        var sampleSettings = audioImporter.defaultSampleSettings;
        sampleSettings.quality = QUALITY;

        if (fileSize <= MIN_SIZE)
        {
            sampleSettings.loadType = AudioClipLoadType.DecompressOnLoad;
        }
        else if (fileSize > MIN_SIZE && fileSize < MAX_SIZE)
        {
            sampleSettings.loadType = AudioClipLoadType.CompressedInMemory;
        }
        else
        {
            sampleSettings.loadType = AudioClipLoadType.Streaming;
        }

#if UNITY_2022_3_OR_NEWER
        sampleSettings.preloadAudioData = true;
#else
        audioImporter.preloadAudioData = true;
#endif
        audioImporter.defaultSampleSettings = sampleSettings;
    }
}

