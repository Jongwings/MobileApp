using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ForCameraPopUp : MonoBehaviour {

	public Button GalleryButton;
	public Button CameraButton;
	public Button CancelButton;
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
		GalleryButton.onClick.AddListener (OnClickGalleryButton);
		CameraButton.onClick.AddListener (OnClickCameraButton);
		CancelButton.onClick.AddListener (OnClickCancelButton);
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

	void OnClickCameraButton ()
	{
		if (m_callback != null) {
			m_callback ();
			m_callback = null;
		}
		ClosePopUp ();
		AddDrinkReceipe.Instance.cameraPickerClicked();
	}

	void OnClickGalleryButton()
	{
		if (m_callback != null) {
			m_callback ();
			m_callback = null;
		}
		ClosePopUp ();
		AddDrinkReceipe.Instance.imagePickerClicked();
	}

	void OnClickCancelButton()
	{
		if (m_callback != null) {
			m_callback ();
			m_callback = null;
		}
		ClosePopUp ();
	}

	public void ClosePopUp ()
	{
		this.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
