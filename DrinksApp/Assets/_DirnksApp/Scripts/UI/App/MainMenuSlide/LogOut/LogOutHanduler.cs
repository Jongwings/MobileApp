using UnityEngine;
using System.Collections;

public class LogOutHanduler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnclickLogOut()
	{
		MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();
		AppManager.Instance.SplashScreenPanel.SetActive (true);
		AppManager.Instance.EmailSighPanel.SetActive (true);
		AppManager.Instance.MainMenuPanel.SetActive (false);

	}
}
