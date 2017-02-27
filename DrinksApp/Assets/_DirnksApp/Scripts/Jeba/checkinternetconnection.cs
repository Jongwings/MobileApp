using UnityEngine;
using System.Collections;

public class checkinternetconnection : MonoBehaviour {
	ConnectionTesterStatus connectionTestResult = ConnectionTesterStatus.Undetermined;

	// Use this for initialization
	void Start () {
		StartCoroutine(checkInternetConnection((isConnected)=>{
			// handle connection status here
		}));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator checkInternetConnection(System.Action<bool> action){
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
			AppManager.Instance.isInternetAvailable = false;
			print("Internet Not available");
			action (false);
		} else {
			AppManager.Instance.isInternetAvailable = true;
			print("Internet available");
			action (true);
		}
	} 
}
