using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditor.Callbacks;
#if UNITY_IOS || UNITY_IPHONE
using UnityEditor.iOS.Xcode;
#endif
using System.Collections.Generic;
using System;
using System.Diagnostics;

public class CustomPostprocess : MonoBehaviour
{
	static string iOS_Build_Path;
	static string iOS_Project_Path;
	static string iOS_Target;
	static CustomPostprocessSettings m_userInterface;

	/// <summary>
	/// If any other PostProcessBuild is there with callback order 100
	/// then change the value of other PostProcessBuild as 99 this will reamin 100.
	/// </summary>
	[PostProcessBuild(100)]
	public static void OnPostprocessBuild(BuildTarget target, string pathToBuildProject)
	{
		iOS_Build_Path = pathToBuildProject;

		UnityEngine.Debug.Log ("DEVICE TARGET "+target.ToString());

		if (GetUserInterface () == null)
		{
			UnityEngine.Debug.Log ("CANNOT FIND CustomPostprocessInspector PREFAB!!!");
			return;
		}

		#if UNITY_IOS || UNITY_IPHONE
		if (target == BuildTarget.iOS)
		{
			UnityEngine.Debug.Log("----Custome Script---Executing post process build phase."); 		

			iOS_Project_Path = pathToBuildProject + "/Unity-iPhone.xcodeproj/project.pbxproj";

			PBXProject pbxProject = new PBXProject();
			pbxProject.ReadFromFile (iOS_Project_Path);

			iOS_Target = pbxProject.TargetGuidByName("Unity-iPhone");

			AddiOSFramework (pbxProject);

			AddiOSLibrary (pbxProject);

			ReplaceAnyFile (pbxProject);

			AddFolderReference (pbxProject);

			AddOtherLinkerFlags(pbxProject);

			ToogleBitCode (pbxProject);

			UpdateInfoPlist (pathToBuildProject);

			pbxProject.AddBuildProperty (iOS_Target, "FRAMEWORK_SEARCH_PATHS", "$(PROJECT_DIR)/Frameworks");

			pbxProject.WriteToFile (iOS_Project_Path);

			UnityEngine.Debug.Log("----Custome Script--- Finished executing post process build phase.");
		}
		#endif
	}

	#if UNITY_IOS || UNITY_IPHONE
	//Can add only iOS framework which is present in /System/Library/Frameworks/
	static void AddiOSFramework (PBXProject pbxProject)
	{
		string xcodetarget = pbxProject.TargetGuidByName("Unity-iPhone");

		for (int i = 0; i < m_userInterface.frameworkName.Count; i++)
		{
			if ( string.IsNullOrEmpty (m_userInterface.frameworkName[i]) == true )
				continue;

			string _frameworkname = m_userInterface.frameworkName [i];

			if (_frameworkname.Contains(".framework") == false)
				_frameworkname = _frameworkname + ".framework";

			pbxProject.AddFrameworkToProject (xcodetarget, _frameworkname, true);

		}
	}

	//Can add only iOS library which is present in /usr/lib/
	static void AddiOSLibrary (PBXProject pbxProject)
	{
		string xcodetarget = pbxProject.TargetGuidByName("Unity-iPhone");

		for (int i = 0; i < m_userInterface.libraryName.Count; i++)
		{
			if ( string.IsNullOrEmpty (m_userInterface.libraryName[i]) == true)
				continue;

			string libname = m_userInterface.libraryName[i];
			//CHECK Xcode if above 7
			if (m_userInterface.isLower == false)
				libname = GetXcode7LibTBDFiles(m_userInterface.libraryName[i]);
			
			pbxProject.AddFileToBuild(xcodetarget, pbxProject.AddFile("usr/lib/" + libname, "Frameworks/" + libname, PBXSourceTree.Sdk));
		}
	}

	//Replace Any Files
	static void ReplaceAnyFile (PBXProject pbxProject)
	{
		for (int i = 0; i < m_userInterface.fileToReplace.Count; i++)
		{
			if ( string.IsNullOrEmpty (m_userInterface.fileToReplace[i].fileName) ||
				string.IsNullOrEmpty (m_userInterface.fileToReplace[i].sourcePath) ||
				string.IsNullOrEmpty (m_userInterface.fileToReplace[i].destinationPath))
			{
				UnityEngine.Debug.Log ("Value is missing in Replace Any File");
				continue;
			}

			string destination_Path = iOS_Build_Path + "/" +m_userInterface.fileToReplace[i].destinationPath + "/" + m_userInterface.fileToReplace[i].fileName;
			string source_Path = Application.dataPath.Replace ("Assets", "") + m_userInterface.fileToReplace[i].sourcePath + "/" + m_userInterface.fileToReplace[i].fileName;

			if (File.Exists (destination_Path) == false) {
				throw new UnityException ("Destination File not Found!!! " + destination_Path);
				return;
			}

			if (File.Exists (source_Path) == false) {
				throw new UnityException ("Source File not Found!!! " + source_Path);
				return;
			}

			if (File.Exists (source_Path) && File.Exists (destination_Path)) {
				File.Copy (source_Path, destination_Path, true);
			}

			pbxProject.WriteToFile (iOS_Project_Path);
		}
	}

	//Can add folder reference its is usefull when we need to add external framework and library.
	static void AddFolderReference (PBXProject pbxProject)
	{
		string projectPath = iOS_Build_Path + "/Unity-iPhone.xcodeproj/project.pbxproj";

		for (int i = 0; i < m_userInterface.folderToAdd.Count; i++)
		{
			if (string.IsNullOrEmpty (m_userInterface.folderToAdd [i]) == true) {
				continue;
			}

			string sourcePath = Application.dataPath.Replace("Assets","");
			sourcePath += m_userInterface.folderToAdd [i];

			foreach (var dir in Directory.GetDirectories(sourcePath)) {
				UnityEngine.Debug.Log (dir);

				string filename = "Frameworks/" + Path.GetFileName (dir);

				CopyAndReplaceDirectory(dir, Path.Combine(iOS_Build_Path, filename));

				pbxProject.AddFileToBuild (iOS_Target, pbxProject.AddFile(filename, filename, PBXSourceTree.Source));
			}
		}
	}

	static void AddAllFilesFromFolder (string source_Dir_Path, PBXProject pbxProject)
	{
		string sourcePath = Application.dataPath.Replace("Assets","");
		sourcePath += source_Dir_Path;

		string destinationDir = Path.GetFileName (source_Dir_Path);

		CopyAndReplaceDirectory(sourcePath, Path.Combine(iOS_Build_Path, destinationDir));

		pbxProject.AddFileToBuild(iOS_Target, pbxProject.AddFile(destinationDir, destinationDir, PBXSourceTree.Source));
	}

	static void AddOtherLinkerFlags (PBXProject pbxProject)
	{
		for (int i=0; i<m_userInterface.otherLinkerFlags.Count; i++)
		{
			if (string.IsNullOrEmpty(m_userInterface.otherLinkerFlags[i]))
				continue;

			//pbxProject.AddBuildProperty(xcodetarget, "OTHER_LDFLAGS", "-ObjC");
			pbxProject.AddBuildProperty(iOS_Target, "OTHER_LDFLAGS", m_userInterface.otherLinkerFlags[i]);

		}
	}

	static void ToogleBitCode(PBXProject pbxProject)
	{
		pbxProject.SetBuildProperty(iOS_Target, "ENABLE_BITCODE", m_userInterface.ENABLE_BITCODE ? "YES" : "NO");
	}

	static void UpdateInfoPlist (string pathToBuildProject)
	{
		// Get plist
		string plistPath = pathToBuildProject + "/Info.plist";
		PlistDocument plist = new PlistDocument();
		plist.ReadFromString(File.ReadAllText(plistPath));

		//Get root
		PlistElementDict rootDict = plist.root;

		var buildKey = "";

		//Toogle Gloss icon
		/*buildKey = "Icon already includes gloss effects";
		rootDict.SetBoolean(buildKey,true);

		buildKey = "UIRequiresFullScreen";
		rootDict.SetBoolean(buildKey,false);*/

		// background location useage key (new in iOS 8)
		/*rootDict.SetString("NSLocationAlwaysUsageDescription", "Uses background location");*/

		// Change value of CFBundleVersion in Xcode plist
		PlistElementArray bgModes = rootDict.CreateArray("UIBackgroundModes");
		bgModes.AddString("remote-notification");
		/*bgModes.AddString("location");
		bgModes.AddString("fetch");*/

		File.WriteAllText(plistPath, plist.WriteToString());
	}

	//Add the new library filename according to requirement
	//Latest xcode use new library so through the old library reference to new library files.
	//Check in /usr/lib/ right click in the file you want and click show original
	//Note: for XCODE 7 and higher the extension is tbd instead of dylib. Eg libc++.1.dylib = libc++.1.tbd
	static string GetXcode7LibTBDFiles(string libFileName)
	{
		if (libFileName == "libalias.dylib") return "";
		else if (libFileName == "libapr-1.dylib") return "";
		else if (libFileName == "libaprutil-1.dylib") return "";
		else if (libFileName == "libarchive.dylib") return "";
		else if (libFileName == "libarchive.dylib") return "";
		else if (libFileName == "libauditd.dylib") return "";
		else if (libFileName == "libAVFAudio.dylib") return "";
		else if (libFileName == "libblas.dylib") return "";
		else if (libFileName == "libBSDPClient.dylib") return "";
		else if (libFileName == "libbsm.dylib") return "";
		else if (libFileName == "libbz2.1.0.5.dylib") return "";
		else if (libFileName == "libbz2.dylib") return "";
		else if (libFileName == "libc.dylib") return "";
		else if (libFileName == "libc++.dylib") return "libc++.1.tbd";
		else if (libFileName == "libcblas.dylib") return "";
		else if (libFileName == "libcharset.1.0.0.dylib") return "";
		else if (libFileName == "libcharset.dylib") return "";
		else if (libFileName == "libclapack.dylib") return "";
		else if (libFileName == "libcom_err.dylib") return "";
		else if (libFileName == "libCRFSuite0.12.dylib") return "";
		else if (libFileName == "libcrypto.dylib") return "";
		else if (libFileName == "libcups.dylib") return "";
		else if (libFileName == "libcupscgi.dylib") return "";
		else if (libFileName == "libcupsimage.dylib") return "";
		else if (libFileName == "libcupsmime.dylib") return "";
		else if (libFileName == "libcupsppdc.dylib") return "";
		else if (libFileName == "libcurl.3.dylib") return "";
		else if (libFileName == "libcurl.dylib") return "";
		else if (libFileName == "libcurses.dylib") return "";
		else if (libFileName == "libdbm.dylib") return "";
		else if (libFileName == "libdes425.dylib") return "";
		else if (libFileName == "libDHCPServer.dylib") return "";
		else if (libFileName == "libdl.dylib") return "";
		else if (libFileName == "libecpg_compat.3.dylib") return "";
		else if (libFileName == "libecpg_compat.dylib") return "";
		else if (libFileName == "libecpg.6.dylib") return "";
		else if (libFileName == "libecpg.dylib") return "";
		else if (libFileName == "libedit.2.dylib") return "";
		else if (libFileName == "libedit.3.0.dylib") return "";
		else if (libFileName == "libedit.dylib") return "";
		else if (libFileName == "libexpat.1.5.2.dylib") return "";
		else if (libFileName == "libexpat.dylib") return "";
		else if (libFileName == "libexslt.dylib") return "";
		else if (libFileName == "libf77lapack.dylib") return "";
		else if (libFileName == "libform.dylib") return "";
		else if (libFileName == "libgcc_s.1.dylib") return "";
		else if (libFileName == "libgssapi_krb5.dylib") return "";
		else if (libFileName == "libhunspell-1.2.0.dylib") return "";
		else if (libFileName == "libhunspell-1.2.dylib") return "";
		else if (libFileName == "libiconv.2.4.0.dylib") return "";
		else if (libFileName == "libiconv.dylib") return "libiconv.2.tbd";
		else if (libFileName == "libicucore.dylib") return "";
		else if (libFileName == "libinfo.dylib") return "";
		else if (libFileName == "libiodbc.2.dylib") return "";
		else if (libFileName == "libiodbc.dylib") return "";
		else if (libFileName == "libiodbcinst.2.dylib") return "";
		else if (libFileName == "libiodbcinst.dylib") return "";
		else if (libFileName == "libipsec.dylib") return "";
		else if (libFileName == "libk5crypto.dylib") return "";
		else if (libFileName == "libkrb4.dylib") return "";
		else if (libFileName == "libkrb5.dylib") return "";
		else if (libFileName == "libkrb5support.dylib") return "";
		else if (libFileName == "libkrb524.dylib") return "";
		else if (libFileName == "liblapack.dylib") return "";
		else if (libFileName == "liblber.dylib") return "";
		else if (libFileName == "libldap_r.dylib") return "";
		else if (libFileName == "libldap.dylib") return "";
		else if (libFileName == "liblzma.dylib") return "";
		else if (libFileName == "libm.dylib") return "";
		else if (libFileName == "libMatch.dylib") return "";
		else if (libFileName == "libmecab.dylib") return "";
		else if (libFileName == "libmenu.dylib") return "";
		else if (libFileName == "libmx.A.dylib") return "";
		else if (libFileName == "libmx.dylib") return "";
		else if (libFileName == "libncurses.5.dylib") return "";
		else if (libFileName == "libncurses.dylib") return "";
		else if (libFileName == "libnetsnmp.5.dylib") return "";
		else if (libFileName == "libnetsnmp.15.dylib") return "";
		else if (libFileName == "libnetsnmp.dylib") return "";
		else if (libFileName == "libnetsnmpagent.dylib") return "";
		else if (libFileName == "libnetsnmphelpers.dylib") return "";
		else if (libFileName == "libnetsnmpmibs.dylib") return "";
		else if (libFileName == "libnetsnmptrapd.dylib") return "";
		else if (libFileName == "libobjc.dylib") return "";
		else if (libFileName == "libpam.dylib") return "";
		else if (libFileName == "libpanel.dylib") return "";
		else if (libFileName == "libpcap.dylib") return "";
		else if (libFileName == "libpcre.dylib") return "";
		else if (libFileName == "libpcreposix.dylib") return "";
		else if (libFileName == "libpgtypes.3.dylib") return "";
		else if (libFileName == "libpgtypes.dylib") return "";
		else if (libFileName == "libpoll.dylib") return "";
		else if (libFileName == "libpq.5.dylib") return "";
		else if (libFileName == "libpq.dylib") return "";
		else if (libFileName == "libproc.dylib") return "";
		else if (libFileName == "libpthread.dylib") return "";
		else if (libFileName == "libpython.dylib") return "";
		else if (libFileName == "libpython2.6.dylib") return "";
		else if (libFileName == "libpython2.7.dylib") return "";
		else if (libFileName == "libreadline.dylib") return "";
		else if (libFileName == "libresolv.dylib") return "libresolv.9.tbd";
		else if (libFileName == "librpcsvc.dylib") return "";
		else if (libFileName == "libruby.2.0.dylib") return "";
		else if (libFileName == "libruby.dylib") return "";
		else if (libFileName == "libsandbox.dylib") return "";
		else if (libFileName == "libsasl2.2.0.1.dylib") return "";
		else if (libFileName == "libsasl2.2.0.15.dylib") return "";
		else if (libFileName == "libsasl2.2.0.21.dylib") return "";
		else if (libFileName == "libsasl2.2.0.22.dylib") return "";
		else if (libFileName == "libsasl2.dylib") return "";
		else if (libFileName == "libsqlite3.0.dylib") return "";
		else if (libFileName == "libssl.dylib") return "";
		else if (libFileName == "libstdc++.6.dylib") return "";
		else if (libFileName == "libstdc++.dylib") return "";
		else if (libFileName == "libSystem.dylib") return "";
		else if (libFileName == "libtcl.dylib") return "";
		else if (libFileName == "libtcl8.5.dylib") return "";
		else if (libFileName == "libtermcap.dylib") return "";
		else if (libFileName == "libtidy.dylib") return "";
		else if (libFileName == "libtk.dylib") return "";
		else if (libFileName == "libtk8.5.dylib") return "";
		else if (libFileName == "libutil1.0.dylib") return "";
		else if (libFileName == "libxar.dylib") return "";
		else if (libFileName == "libxml2.dylib") return "libxml2.2.tbd";
		else if (libFileName == "libXplugin.dylib") return "";
		else if (libFileName == "libxslt.dylib") return "";
		else if (libFileName == "libz.1.1.3.dylib") return "";
		else if (libFileName == "libz.1.2.5.dylib") return "";
		else if (libFileName == "libz.dylib") return "libz.1.tbd";

		return libFileName;
	}
	#endif

	static CustomPostprocessSettings GetUserInterface ()
	{
		m_userInterface = Resources.Load ("CustomPostprocessSettings") as CustomPostprocessSettings;

		if (m_userInterface == null) {
			UnityEngine.Debug.Log ("CANNOT FIND CustomPostprocessInspector PREFAB!!!");
			return null;
		}

		return m_userInterface;
	}

	internal static void CopyAndReplaceDirectory(string srcPath, string dstPath)
	{
		if (Directory.Exists(dstPath))
			Directory.Delete(dstPath);
		if (File.Exists(dstPath))
			File.Delete(dstPath);

		Directory.CreateDirectory(dstPath);

		foreach (var file in Directory.GetFiles(srcPath)) {
//			UnityEngine.Debug.Log (file);
			File.Copy(file, Path.Combine(dstPath, Path.GetFileName(file)));
		}

		foreach (var dir in Directory.GetDirectories(srcPath)) {
//			UnityEngine.Debug.Log (dir);
			CopyAndReplaceDirectory(dir, Path.Combine(dstPath, Path.GetFileName(dir)));
		}
	}
}
