using UnityEngine;
using System.Collections;
using System;

public class LamdaExpression : MonoBehaviour
{

	Action sayHello = () => {
		Debug.Log ("Hello!");
	};

	Action<int> sendToLog = (arg) => { Debug.Log(arg); };

	Action<int, string, bool> sendToLogs = 
		(value, description, doLog) => 
	{
		if (doLog) Debug.Log("Logging out " 
			+ value + " and " 
			+ description); 
	};

	void Start ()
	{

		sayHello ();

		sendToLog(5);
		sendToLog(-10);
		sendToLog(42);
	}

	public static IEnumerator CheckInternetConnection (Action<bool> callback)
	{
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
			callback (false);
		} else {
			callback (true);
		}
	}


}
