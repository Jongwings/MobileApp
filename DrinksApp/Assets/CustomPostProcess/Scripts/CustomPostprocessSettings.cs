using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class CustomPostprocessSettings : ScriptableObject
{
	//OnInspector Folds
	public bool m_buildPhasesFoldOut;
	public bool m_buildSettingsFoldOut;
	public bool m_otherSettingsFoldOut;
	public bool m_infoPlistFoldOut;
	//OtherLinkerFlags Folds
	public bool m_otherLinkerFlags;
	//Frameworks Folds
	public bool m_frameworkFoldOut;
	//Library Folds
	public bool m_libraryFoldOut;
	//File To Replace Folds
	public bool m_fileToReplaceFoldOut;
	//Folder Reference Folds
	public bool m_folderReferenceFoldOut;

	[Header("Xcode Version Is < 7.0")]
	public bool isLower = false;

	[Header("Eg. Accounts.framework")]
	public List<string> frameworkName = new List<string>();

	[Header("Eg. libc++.dylib")]
	public List<string> libraryName = new List<string>();

	[Header("Eg. Other Linker Flags")]
	public List<string> otherLinkerFlags = new List<string>();

	//[Header("Eg. [OTHER_LDFLAGS] [-ObjC]")]
	//public List<XcodeBuildSetting> buildSetting = new List<XcodeBuildSetting> ();
	public bool ENABLE_BITCODE = false;

	[Header("Replace any files. Give file name with extension")]
	public List<ReplaceAnyFile> fileToReplace = new List<ReplaceAnyFile> ();

	[Header("Enter folder path")]
	public List<string> folderToAdd = new List<string>();

	[System.Serializable]
	public class XcodeBuildSetting
	{
		public string keyName;
		public string valueName;
	}

	[System.Serializable]
	public class ReplaceAnyFile
	{
		public string fileName;
		public string sourcePath;
		public string destinationPath;
	}

	private const string CustomSettingsAssetName = "CustomPostprocessSettings";
	private const string CustomSettingsPath = "CustomPostprocessSettings/Resources";
	private const string customSettingsAssetExtension = ".asset";

	private static CustomPostprocessSettings instance;

	private static CustomPostprocessSettings Instance
	{
		get
		{
			if (instance == null)
			{
				instance = Resources.Load(CustomSettingsAssetName) as CustomPostprocessSettings;
				if (instance == null)
				{
					// If not found, autocreate the asset object.
					instance = ScriptableObject.CreateInstance<CustomPostprocessSettings>();
					#if UNITY_EDITOR
					string properPath = Path.Combine(Application.dataPath, CustomSettingsPath);
					if (!Directory.Exists(properPath))
					{
						Directory.CreateDirectory(properPath);
					}

					string fullPath = Path.Combine(
						Path.Combine("Assets", CustomSettingsPath),
						CustomSettingsAssetName + customSettingsAssetExtension);
					UnityEditor.AssetDatabase.CreateAsset(instance, fullPath);
					#endif
				}
			}

			return instance;
		}
	}
}
