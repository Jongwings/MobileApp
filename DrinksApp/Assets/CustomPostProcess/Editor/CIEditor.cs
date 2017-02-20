using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CIEditor
{
	static string[] SCENES = FindEnabledEditorScenes();

	static string APP_NAME = PlayerSettings.productName;
	static string TARGET_DIR_IOS = "JServerIOSBuild";
	static string TARGET_DIR_ANDROID = "JServerAndroidBuild";
	private const string CustomSettingsAssetName = "CustomPostprocessSettings";
	private const string CustomSettingsPath = "CustomPostprocess/Resources";
	private const string customSettingsAssetExtension = ".asset";

	[UnityEditor.MenuItem("CustomPostProcess/Creata Custom Settings")]
	static void Create()
	{
		
		var asset = ScriptableObject.CreateInstance<CustomPostprocessSettings>();
		string properPath = Path.Combine(Application.dataPath, CustomSettingsPath);
		//var path = "Assets/Resources/CustomPostProcessPrefab.prefab";
		//string sourcePath = Application.dataPath + "/Resources";
		string fullPath = Path.Combine(
			Path.Combine("Assets", CustomSettingsPath),
			CustomSettingsAssetName + customSettingsAssetExtension);

		if (Directory.Exists(properPath) == false)
		{
			Directory.CreateDirectory (properPath);
		}

		if (File.Exists(fullPath))
		{
			UnityEngine.Debug.Log (fullPath);
			return;
		}

		UnityEditor.AssetDatabase.CreateAsset(asset, fullPath);
	}

	[MenuItem ("CustomPostProcess/Build/iOS")]
	static void PerformiOSBuild ()
	{
		CreateFolder ();
		string target_dir = APP_NAME;
		GenericBuild (SCENES, TARGET_DIR_IOS + "/" + target_dir, BuildTarget.iOS, BuildOptions.None);
	}


	[MenuItem ("CustomPostProcess/Build/Android")]
	static void PerformAndroidBuild ()
	{		
		PlayerSettings.Android.keystoreName = Application.dataPath.Replace ("Assets", "") + "/Keystore/SportsQwizzKeystore.keystore";
		PlayerSettings.Android.keystorePass = "sports@qwizz";
		PlayerSettings.Android.keyaliasName = "sportsqwizz";
		PlayerSettings.Android.keyaliasPass = "sports@qwizz";

		CreateFolder ();
		string target_dir = APP_NAME;
		GenericBuild (SCENES, TARGET_DIR_ANDROID + "/" + target_dir, BuildTarget.Android, BuildOptions.None);
	}


	static void CreateFolder ()
	{
		string _datapath = Application.dataPath.Replace ("Assets", "");
		#if UNITY_ANDROID
		if (!Directory.Exists(_datapath + TARGET_DIR_ANDROID))
			Directory.CreateDirectory (_datapath + TARGET_DIR_ANDROID);
		#else 
		if (!Directory.Exists(_datapath + TARGET_DIR_IOS))
		Directory.CreateDirectory (_datapath + TARGET_DIR_IOS);
		#endif

	}

	private static string[] FindEnabledEditorScenes ()
	{
		List<string> EditorScenes = new List<string> ();

		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
		{
			if (!scene.enabled)
				continue;
			EditorScenes.Add (scene.path);
		}
		return EditorScenes.ToArray ();
	}

	static void GenericBuild(string[] scenes, string target_dir, BuildTarget build_target, BuildOptions build_options)
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget (build_target);
		string res = BuildPipeline.BuildPlayer (scenes, target_dir, build_target, build_options);
		if(res.Length > 0)
		{
			throw new UnityException ("BuildPlayer Failure: " + res);
		}
	}
}
