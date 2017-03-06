using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LogoutPopUpMessage : MonoBehaviour {

	public Button okButton;
	public Button noButton;
	public Text message;

	private System.Action m_callback;

	public enum eMessageType
	{
		Normal = 0,
		Warning,
		Error
	}

	// Use this for initialization
	void Start () {
		okButton.onClick.AddListener (OnClickOkButton);
		noButton.onClick.AddListener (OnClickNoButton);
	}

	public void PopUpPanel (string msg, 
		eMessageType msgType = eMessageType.Normal)
	{
		message.text = msg;

//		if (msgType == eMessageType.Normal)
//			message.color = Color.white;
//		else if (msgType == eMessageType.Warning)
//			message.color = Color.yellow;
//		else if (msgType == eMessageType.Error)
//			message.color = Color.red;
	}

	public void PopUpPanelTwo (string msg,  
		eMessageType msgType = eMessageType.Normal)
	{
		message.text = msg;

		//		if (msgType == eMessageType.Normal)
		//			message.color = Color.white;
		//		else if (msgType == eMessageType.Warning)
		//			message.color = Color.yellow;
		//		else if (msgType == eMessageType.Error)
		//			message.color = Color.red;
	}
	public void PopUpPanel (string msg, System.Action callback, eMessageType msgType = eMessageType.Normal)
	{
		m_callback = callback;
		message.text = msg;

		if (msgType == eMessageType.Normal)
			message.color = Color.white;
		else if (msgType == eMessageType.Warning)
			message.color = Color.yellow;
		else if (msgType == eMessageType.Error)
			message.color = Color.red;
	}

	void OnClickOkButton ()
	{
		//GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		if(AppManager.Instance.isPopUpForPhotoUpload == false)
		{
			if (m_callback != null) {
				m_callback ();
				m_callback = null;
			}

			ClosePopUp ();
			PlayerPrefs.DeleteAll();
			AppManager.Instance.UserId = "";
			AppManager.Instance.username = "";
			SplashScreen.Instance.LoginEmailId.text = "";
			SplashScreen.Instance.LoginPassword.text = "";
			MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();
			AppManager.Instance.SplashScreenPanel.SetActive (true);
			AppManager.Instance.EmailSighPanel.SetActive (true);
			AppManager.Instance.MainMenuPanel.SetActive (false);
		}
		else
		{
			if (m_callback != null) {
				m_callback ();
				m_callback = null;
			}

			ClosePopUp ();
			PostRecipe.Instance.postReciepeApiCall();
		}

	}

	void OnClickNoButton()
	{
		if(AppManager.Instance.isPopUpForPhotoUpload == false)
		{
			if (m_callback != null) {
				m_callback ();
				m_callback = null;
			}

			ClosePopUp ();
			MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();
			MainMenuSlideManager.Instance.homeScreenPanel.SetActive (true);
		}
		else
		{
			if (m_callback != null) {
				m_callback ();
				m_callback = null;
			}

			ClosePopUp ();
			MainMenuSlideManager.Instance.PostRecipePanel.SetActive(false);
			MainMenuSlideManager.Instance.InnerPanel.SetActive (false);
		}


	}

	public void ClosePopUp ()
	{
//		if (m_nextState != MainMenuPanelManager.eMainMenuState.Unknown)
//			MainMenuPanelManager.Instance.SwitchPanel (m_nextState);

		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
