﻿using UnityEngine;
using System.Collections;

public class OnScreenLogger : MonoBehaviour {

	public static OnScreenLogger Instance;
	public string streamingError = "";

	private Vector2 scrollPosition = Vector2.zero;
	[SerializeField] private GameObject BGObject;
	bool isDebugging = false;
	bool isBackground = false;

	void Awake () {

		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad (this.gameObject);
		}
		else {
			DestroyImmediate (this);
		}
	}

	void Start ()
	{
		Application.RegisterLogCallback (HandleLog);
	}

	void HandleLog(string logString, string stackTrace, LogType type)
	{
		if (type == LogType.Error ||
			type == LogType.Exception ||
			type == LogType.Warning )
		{
			streamingError += "\n" + logString + "\n >>> " + stackTrace;
		}

		if (streamingError.Length > 10000)
		{
			streamingError = streamingError.Remove(0, 3000);
		}
	}

	public void ShowFriendList ()
	{
		//SocialHandler.Instance.GoogleFriends (callback);
	}

	void callback(bool suc)
	{
		
	}

	#if !CLIENT_BUILD

	void OnGUI ()
	{
	isDebugging = GUI.Toggle (new Rect (150, Screen.height - 50, 100, 100), isDebugging, "Debug");
	isBackground = GUI.Toggle (new Rect (300, Screen.height - 50, 100, 100), isBackground, "ShowBG");

	if (isDebugging == false)
	isBackground = false;

	BGObject.SetActive (isBackground);

	if (! isDebugging)
	return;


	GUILayout.BeginArea (new Rect  (10, 10, 400, 300));
	scrollPosition = GUILayout.BeginScrollView (scrollPosition, GUILayout.Width (400), GUILayout.Height (300));
	GUILayout.TextField ("\nLogs\n : " + streamingError, "Label");
	GUILayout.EndScrollView ();
	GUILayout.EndArea ();
	}

	#endif

}

