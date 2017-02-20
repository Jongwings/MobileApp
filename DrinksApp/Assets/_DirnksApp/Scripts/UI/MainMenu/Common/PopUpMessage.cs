using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpMessage : MonoBehaviour {

	public Button okButton;
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

		if (m_callback != null) {
			m_callback ();
			m_callback = null;
		}

		ClosePopUp ();
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
