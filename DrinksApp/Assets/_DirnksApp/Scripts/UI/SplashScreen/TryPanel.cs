using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TryPanel : MonoBehaviour {

	public Text titleText;
	public Button startDemoButton;
	public Button cancelButton;

	void OnEnable () {
		titleText.text = TagConstant.PopUpMessages.TRY_PANEL_INFO;
	}

	// Use this for initialization
	void Start () {
		startDemoButton.onClick.AddListener (OnClickStartDemoButton);
		cancelButton.onClick.AddListener (OnClickCancelButton);
	}
	
	void OnClickStartDemoButton ()
	{
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);


		this.gameObject.SetActive (false);
	}

	void OnClickCancelButton ()
	{
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		this.gameObject.SetActive (false);
	}
}
