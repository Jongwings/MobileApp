using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

[CustomEditor(typeof(CustomPostprocessSettings))]
public class CustomPostprocessSettingsEditor : Editor
{
    private CustomPostprocessSettings m_Target;

    public override void OnInspectorGUI()
    {
        m_Target = (CustomPostprocessSettings)target;

        GUILayout.BeginHorizontal();
        string ishiger = m_Target.isLower ? "  Yes" : "   No";
        EditorGUILayout.LabelField("Is Xcode Version < 7 ?");
        m_Target.isLower = EditorGUILayout.ToggleLeft(ishiger, m_Target.isLower);
        GUILayout.EndHorizontal();

        DrawSplitterLine(1f);

		m_Target.m_buildSettingsFoldOut = EditorGUILayout.Foldout(m_Target.m_buildSettingsFoldOut, "BUILD SETTINGS", CustomGUILayout.FoldHeaderStyle());
		if (m_Target.m_buildSettingsFoldOut) BuilsSettings();

        DrawSplitterLine(4f);

		m_Target.m_buildPhasesFoldOut = EditorGUILayout.Foldout(m_Target.m_buildPhasesFoldOut, "BUILD PHASES", CustomGUILayout.FoldHeaderStyle());
		if (m_Target.m_buildPhasesFoldOut) BuildPhases();

        DrawSplitterLine(4f);

		m_Target.m_otherSettingsFoldOut = EditorGUILayout.Foldout(m_Target.m_otherSettingsFoldOut, "OTHER SETTINGS", CustomGUILayout.FoldHeaderStyle());
		if (m_Target.m_otherSettingsFoldOut) OtherSettings();

        DrawSplitterLine(4f);

		m_Target.m_infoPlistFoldOut = EditorGUILayout.Foldout(m_Target.m_infoPlistFoldOut, "INFO PLIST", CustomGUILayout.FoldHeaderStyle());
		if (m_Target.m_infoPlistFoldOut) InfoPlist();

		if (GUI.changed)
			EditorUtility.SetDirty (m_Target);
    }

    void BuilsSettings()
    {
		m_Target.m_otherLinkerFlags = EditorGUILayout.Foldout(m_Target.m_otherLinkerFlags, "Other Linker Flags", CustomGUILayout.FoldSubHeaderStyle());
		if (m_Target.m_otherLinkerFlags) OtherLinkerFlags();

        GUILayout.BeginHorizontal();
        string isEnable = m_Target.ENABLE_BITCODE ? "  Yes" : "   No";
        EditorGUILayout.LabelField("Enable Bitcode");
        m_Target.ENABLE_BITCODE = EditorGUILayout.ToggleLeft(isEnable, m_Target.ENABLE_BITCODE);
        GUILayout.EndHorizontal();
    }

    void OtherLinkerFlags()
    {
        EditorGUILayout.HelpBox("Linker flags 'Example: -ObjC'", MessageType.Info);
        if (GUILayout.Button("+", GUILayout.MinWidth(200), GUILayout.Width(100)))
            m_Target.otherLinkerFlags.Add("");

        for (int i = 0; i < m_Target.otherLinkerFlags.Count; i++)
        {
            GUILayout.BeginHorizontal();

            m_Target.otherLinkerFlags[i] = EditorGUILayout.TextField((i + 1).ToString() + ". ", m_Target.otherLinkerFlags[i]);
            if (GUILayout.Button("-"))
                DeleteListIndex(m_Target.otherLinkerFlags, i);

            GUILayout.EndHorizontal();
        }
    }

    void BuildPhases()
    {
		m_Target.m_frameworkFoldOut = EditorGUILayout.Foldout(m_Target.m_frameworkFoldOut, "Framework", CustomGUILayout.FoldSubHeaderStyle());
		if (m_Target.m_frameworkFoldOut) Framework();

		m_Target.m_libraryFoldOut = EditorGUILayout.Foldout(m_Target.m_libraryFoldOut, "Library", CustomGUILayout.FoldSubHeaderStyle());
		if (m_Target.m_libraryFoldOut) Library();
    }

    void Framework()
    {
        EditorGUILayout.HelpBox("Add the Framework with proper name\n 'Example: Address.framework'", MessageType.Info);
        if (GUILayout.Button("+", GUILayout.MinWidth(200), GUILayout.Width(100)))
            m_Target.frameworkName.Add("");

        for (int i = 0; i < m_Target.frameworkName.Count; i++)
        {
            GUILayout.BeginHorizontal();

            m_Target.frameworkName[i] = EditorGUILayout.TextField((i + 1).ToString() + ". ", m_Target.frameworkName[i]);
            if (GUILayout.Button("-"))
                DeleteListIndex(m_Target.frameworkName, i);

            GUILayout.EndHorizontal();
        }
    }

    void Library()
    {
        EditorGUILayout.HelpBox("Add the Library with proper name\n 'Example: libc++.dylib'", MessageType.Info);
        if (GUILayout.Button("+", GUILayout.MinWidth(200), GUILayout.Width(100)))
            m_Target.libraryName.Add("");

        for (int i = 0; i < m_Target.libraryName.Count; i++)
        {
            GUILayout.BeginHorizontal();

            m_Target.libraryName[i] = EditorGUILayout.TextField((i + 1).ToString() + ". ", m_Target.libraryName[i]);
            if (GUILayout.Button("-"))
                DeleteListIndex(m_Target.libraryName, i);

            GUILayout.EndHorizontal();
        }
    }

    void OtherSettings()
    {
		m_Target.m_fileToReplaceFoldOut = EditorGUILayout.Foldout(m_Target.m_fileToReplaceFoldOut, "Replace Files", CustomGUILayout.FoldSubHeaderStyle());
		if (m_Target.m_fileToReplaceFoldOut) FileToReplace();

		m_Target.m_folderReferenceFoldOut = EditorGUILayout.Foldout(m_Target.m_folderReferenceFoldOut, "Add Folder Reference", CustomGUILayout.FoldSubHeaderStyle());
		if (m_Target.m_folderReferenceFoldOut) AddFolderReference();
    }

    void FileToReplace()
    {
        EditorGUILayout.HelpBox("Add Files to Replace for Example:" +
            "\nFile Name: UnityAppController.h" +
            "\nSource: XcodeAssets ('XcodeAssets' is foldername kept outside Assets)" +
            "\nDestination: Classes (file path in xcode build)", MessageType.Info);

        if (GUILayout.Button("+", GUILayout.MinWidth(200), GUILayout.Width(100)))
        {
            CustomPostprocessSettings.ReplaceAnyFile temp = new CustomPostprocessSettings.ReplaceAnyFile();
            m_Target.fileToReplace.Add(temp);
        }
        DrawSplitterLine(1);
        for (int i = 0; i < m_Target.fileToReplace.Count; i++)
        {

            m_Target.fileToReplace[i].fileName = EditorGUILayout.TextField("File Name:", m_Target.fileToReplace[i].fileName);
            m_Target.fileToReplace[i].sourcePath = EditorGUILayout.TextField("Source:", m_Target.fileToReplace[i].sourcePath);
            m_Target.fileToReplace[i].destinationPath = EditorGUILayout.TextField("Destination:", m_Target.fileToReplace[i].destinationPath);

            //GUILayout.BeginHorizontal();
            if (GUILayout.Button("-", GUILayout.MinWidth(200), GUILayout.Width(100)))
                DeleteListIndex(m_Target.fileToReplace, i);

            // GUILayout.EndHorizontal();
            DrawSplitterLine(1);
        }
    }

    void AddFolderReference()
    {
        EditorGUILayout.HelpBox("Add the folder path." +
            "\nExample 1 'Assets/Plugins/Folder1' = Plugins/Folder1" +
            "\nExample 2 'Assets/GoogleFramework' = GoogleFramework" +
            "\nNOTE: Folder to refer can only be kept under Assets", MessageType.Info);

        if (GUILayout.Button("+", GUILayout.MinWidth(200), GUILayout.Width(100)))
            m_Target.folderToAdd.Add("");

        for (int i = 0; i < m_Target.folderToAdd.Count; i++)
        {
            GUILayout.BeginHorizontal();

            m_Target.folderToAdd[i] = EditorGUILayout.TextField((i + 1).ToString() + ". ", m_Target.folderToAdd[i]);
            if (GUILayout.Button("-"))
                DeleteListIndex(m_Target.folderToAdd, i);

            GUILayout.EndHorizontal();
        }
    }

    void InfoPlist()
    {
        EditorGUILayout.HelpBox("Work In Progress", MessageType.Info);
    }

    void DrawSplitterLine(float lineThickness)
    {
        GUILayout.Box("", new GUILayoutOption[] { GUILayout.ExpandWidth(true), GUILayout.Height(lineThickness) });
    }

    void DeleteListIndex<T>(List<T> list, int index)
    {
        list.RemoveAt(index);
    }
}
