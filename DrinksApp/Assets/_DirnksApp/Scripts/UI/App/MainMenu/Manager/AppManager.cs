using UnityEngine;
using System.Collections;

public class AppManager : MonoBehaviour {

	[Header("Chivita Login")]
	public string UserId;
	public string username;

	[Header("Chivita FB Login")]
	public string fbUserName;
	public string fbUserID;
	public string fbUserEmailID;
	public string fbUserFirstName;

	[Header("Chivita Twitter Login")]
	public string twitterUserName;
	public string twitterUserID;
	public string twitterUserEmailID;
	public string twitterUserFirstName;

	public GameObject SplashScreenPanel;
	public GameObject EmailSighPanel;
	public GameObject SighUpPanel;
	public GameObject MainMenuPanel;
	public GameObject IntroPanel;
	public GameObject MainMenuSlideButton;
	public GameObject ToggleButtons;
	public PopUpMessage popUpMessage;
	public LogoutPopUpMessage logoutPopUpMessage;

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
	public string BrandId;
	public string BrandImageStr;
	public string BrandHeaderTitle1;
	public string BrandHeaderTitle2;
	public string BrandHeaderTitle3;
	public string BrandHeaderStrText1;
	public string BrandHeaderStrText2;
	public string BrandHeaderStrText3;

	[Header("Search")]
	public string searchWord;
	public bool isSearchDrinksWord;
	public bool isSearchIngredientsWord;

	[Header("Collections")]
	public string collectionName;
	public string collectionID;

	public bool isForCollectionRecipe;

	public bool isPopUpForPhotoUpload;


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

	public void ShowMessage1 (string msg,  
		LogoutPopUpMessage.eMessageType msgType = LogoutPopUpMessage.eMessageType.Normal)
	{		

		logoutPopUpMessage.PopUpPanelTwo (msg, msgType);
		logoutPopUpMessage.gameObject.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
