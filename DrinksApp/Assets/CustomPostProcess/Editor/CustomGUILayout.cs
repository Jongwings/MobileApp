using UnityEditor;
using UnityEngine;
using System.Collections;

public class CustomGUILayout
{
    public static GUIStyle FoldHeaderStyle()
    {
        GUIStyle foldOutStyle = new GUIStyle(EditorStyles.foldout);
        foldOutStyle.fontStyle = FontStyle.Bold;
        foldOutStyle.fontSize = 14;
        foldOutStyle.stretchWidth = false;

        Color textColor = Color.white;

        foldOutStyle.onActive.textColor = Color.white;
        foldOutStyle.onFocused.textColor = Color.white;
        foldOutStyle.onHover.textColor = Color.yellow;
        foldOutStyle.onNormal.textColor = Color.white;
        foldOutStyle.active.textColor = Color.gray;
        foldOutStyle.focused.textColor = Color.gray;
        foldOutStyle.hover.textColor = Color.cyan;
        foldOutStyle.normal.textColor = Color.gray;

        return foldOutStyle;
    }

    public static GUIStyle FoldSubHeaderStyle()
    {
        GUIStyle foldOutStyle = new GUIStyle(EditorStyles.foldout);
        foldOutStyle.fontStyle = FontStyle.Bold;
        foldOutStyle.fontSize = 12;
        foldOutStyle.stretchWidth = false;
        foldOutStyle.alignment = TextAnchor.MiddleLeft;

        Color textColor = Color.white;

        foldOutStyle.onActive.textColor = Color.white;
        foldOutStyle.onFocused.textColor = Color.white;
        foldOutStyle.onHover.textColor = Color.yellow;
        foldOutStyle.onNormal.textColor = Color.white;
        foldOutStyle.active.textColor = Color.gray;
        foldOutStyle.focused.textColor = Color.gray;
        foldOutStyle.hover.textColor = Color.cyan;
        foldOutStyle.normal.textColor = Color.gray;

        return foldOutStyle;
    }
}
