using UnityEngine;
using UnityEditor;
using System.Collections;

public class BuildAssetBundle : MonoBehaviour 
{
    [MenuItem("BuildAB/Build To IOS StreamingAsset")]
    static void BuildIOSAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets/ios_Assetbundles", BuildAssetBundleOptions.None, BuildTarget.iOS);
    }

    [MenuItem("BuildAB/Build To Android StreamingAsset")]
    static void BuildAndroidStreamingAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/StreamingAssets/android_Assetbundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }

    [MenuItem("BuildAB/Build To Windows")]
    static void BuildWindowsAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/OriginalRes/windows_Assetbundles", BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
    }
}
