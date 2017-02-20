using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;

public class AppMainMenuPanel : MonoBehaviour {
	public enum eAppSubMenuPanel
	{
		Collection,
		AddYourDrink,
		Search,
		KnowYourDrinks,
		Game
	}


	public eAppSubMenuPanel currentSubPanel;
	public PopUpMessage popUpMessage;


	[Header("TOGGLE BUTTON")]
	public Toggle CollectionSelectionToggle;
	public Toggle AddYourDrinkToggle;
	public Toggle SearchToggle;
	public Toggle KnowYourDrinksToggle;
	public Toggle GameToggle;
	[Header("TOGGLE PANEL")]
	public GameObject CollectionSelectionPanel;
	public GameObject AddYourDrinkPanel;
	public GameObject SearchPanel;
	public GameObject KnowYourDrinksPanel;
	public GameObject GamePanel;

	public static AppMainMenuPanel instance;

	// Use this for initialization
	void Start () {
		CollectionSelectionToggle.onValueChanged.AddListener (OnClickCollectionSelectionToggle);
		AddYourDrinkToggle.onValueChanged.AddListener (OnClickAddYourDrinkSelectionToggle);
		SearchToggle.onValueChanged.AddListener (OnClickSearchSelectionToggle);
		KnowYourDrinksToggle.onValueChanged.AddListener (OnClickKnowYourDrinkSelectionToggle);
		GameToggle.onValueChanged.AddListener (OnClickGameSelectionToggle);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayToogleSound ()
	{
//		if (GenericAudioManager.instance != null && m_isAndroidback == false) {
//			GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
//		}
//		m_isAndroidback = false;
	}

	void OnClickCollectionSelectionToggle (bool isOn)
	{
		if (isOn) {
			PlayToogleSound ();
		}
		SwitchTogglePanel (eAppSubMenuPanel.Collection);
	}

	void OnClickAddYourDrinkSelectionToggle (bool isOn)
	{
		if (isOn) {
			PlayToogleSound ();
		}
		SwitchTogglePanel (eAppSubMenuPanel.AddYourDrink);
	}

	void OnClickSearchSelectionToggle (bool isOn)
	{
		if (isOn) {
			PlayToogleSound ();
		}
		SwitchTogglePanel (eAppSubMenuPanel.Search);
	}

	void OnClickKnowYourDrinkSelectionToggle (bool isOn)
	{
		if (isOn) {
			PlayToogleSound ();
		}
		SwitchTogglePanel (eAppSubMenuPanel.KnowYourDrinks);
	}

	void OnClickGameSelectionToggle (bool isOn)
	{
		if (isOn) {
			PlayToogleSound ();
		}
		SwitchTogglePanel (eAppSubMenuPanel.Game);
	}


	public void SwitchTogglePanel (eAppSubMenuPanel state)
	{
		currentSubPanel = state;
		Debug.Log ("SwitchTogglePanel ----:" + state);
		CollectionSelectionPanel.gameObject.SetActive (state == eAppSubMenuPanel.Collection);
		AddYourDrinkPanel.gameObject.SetActive (state == eAppSubMenuPanel.AddYourDrink);
		SearchPanel.gameObject.SetActive (state == eAppSubMenuPanel.Search);
		KnowYourDrinksPanel.gameObject.SetActive (state == eAppSubMenuPanel.KnowYourDrinks);
		GamePanel.gameObject.SetActive (state == eAppSubMenuPanel.Game);
		MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

	}
	public void ShowMessage (string msg, PopUpMessage.eMessageType msgType = PopUpMessage.eMessageType.Normal)
	{		

		popUpMessage.PopUpPanelTwo (msg, msgType);
		popUpMessage.gameObject.SetActive (true);
	}


}
