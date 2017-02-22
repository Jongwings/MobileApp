using UnityEngine;
using System.Collections;

public class AppManager : MonoBehaviour {
	
	public string UserId;
	public string username;

	public GameObject EmailSighPanel;
	public GameObject SighUpPanel;
	public GameObject MainMenuPanel;
	public GameObject IntroPanel;
	public GameObject MainMenuSlideButton;
	public GameObject ToggleButtons;
	public PopUpMessage popUpMessage;

	public static AppManager Instance;

	public bool isRecipeDetailsForFavourite;
	public bool isRecipeDetailsForCreation;
	public bool isRecipeDetailsForSearch;

	[Header("Recipe Details")]
	public string RecipeNameStr;
	public string RecipeIngrdeientsStr;
	public string RecipePreparationStr;
	public string RecipeImageStr;
	public string RecipeRating;


	[Header("Brand Details")]
	public string BrandNameStr;
	public string BrandImageStr;
	public string BrandHeaderTitle1;
	public string BrandHeaderTitle2;
	public string BrandHeaderTitle3;
	public string BrandHeaderStrText1;
	public string BrandHeaderStrText2;
	public string BrandHeaderStrText3;



	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
		EmailSighPanel.SetActive (true);
		SighUpPanel.SetActive (false);
		MainMenuPanel.SetActive (false);
		IntroPanel.SetActive (false);
		MainMenuSlideButton.SetActive (true);
		ToggleButtons.SetActive (true);
	}
	public void ShowMessage (string msg,  
		PopUpMessage.eMessageType msgType = PopUpMessage.eMessageType.Normal)
	{		

		popUpMessage.PopUpPanelTwo (msg, msgType);
		popUpMessage.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
