using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomPostprocessInspector : MonoBehaviour
{
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
	public bool ENABLE_BITCODE = true;

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
}
