using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
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
	public string RecipeId;
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

	public bool isInternetAvailable;

	public Sprite[] BrandOfflineThumbImages;
	public Sprite[] BrandOfflineBannerImages;
	public Sprite[] RecipeOfflineImages;

	public List<SeralizedClassServer.OfflineBradDetails> offlineBrandDetails;
	public List<SeralizedClassServer.OfflineCollectionDetails> offlineCollectionDetails;
	public List<SeralizedClassServer.OfflineFeatureCollectionDetails> offlineFeatureCollectionDetails;
	public List<SeralizedClassServer.OfflineRecipeDetails> offlineRecipeDetails;

//	public string[] BrandArray;
	public List<string> BrandArray = new List<string>();


	private bool isProcessing = false;



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
	// Read File from Local Resource
	public void ReadFileOfflineBrandDetails()
	{
		if (offlineBrandDetails == null) {
			TextAsset myBrandDetailsData = (TextAsset)Resources.Load("BrandDetailsjson", typeof(TextAsset));
			string txt = myBrandDetailsData.text;
			offlineBrandDetails = new List<SeralizedClassServer.OfflineBradDetails> ();
			offlineBrandDetails = JsonConvert.DeserializeObject<List<SeralizedClassServer.OfflineBradDetails>> (txt);
		}
	}

	// Read File from Local Resource
	public void ReadFileOfflineCollectionDetails()
	{
		if (offlineCollectionDetails == null) {
			TextAsset myCollectionData = (TextAsset)Resources.Load("CollectionDetailsjson", typeof(TextAsset));
			string txt = myCollectionData.text;
			offlineCollectionDetails = new List<SeralizedClassServer.OfflineCollectionDetails> ();
			offlineCollectionDetails = JsonConvert.DeserializeObject<List<SeralizedClassServer.OfflineCollectionDetails>> (txt);
		}
	}
	// Read File from Local Resource
	public void ReadFileOfflineFeatureCollectionDetails()
	{
		if (offlineFeatureCollectionDetails == null) {
			TextAsset myCollectionData = (TextAsset)Resources.Load("FeatureCollectionDetailsJson", typeof(TextAsset));
			string txt = myCollectionData.text;
			offlineFeatureCollectionDetails = new List<SeralizedClassServer.OfflineFeatureCollectionDetails> ();
			offlineFeatureCollectionDetails = JsonConvert.DeserializeObject<List<SeralizedClassServer.OfflineFeatureCollectionDetails>> (txt);
		}
	}

	// Read File from Local Resource
	public void ReadFileOfflineRecipeDetails()
	{
		if (offlineRecipeDetails == null) {
			TextAsset myCollectionData = (TextAsset)Resources.Load("RecipesDetailsjson", typeof(TextAsset));
			string txt = myCollectionData.text;
			offlineRecipeDetails = new List<SeralizedClassServer.OfflineRecipeDetails> ();
			offlineRecipeDetails = JsonConvert.DeserializeObject<List<SeralizedClassServer.OfflineRecipeDetails>> (txt);
		}
	}

	public void globalShare(string message)
	{
		isProcessing = true;
		Texture2D screenTexture = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,true);
		screenTexture.ReadPixels(new Rect(0f,0f,Screen.width,Screen.height),0,0);
		screenTexture.Apply();

		byte[] dataToSave = screenTexture.EncodeToPNG();
		string destination = Path.Combine(Application.persistentDataPath,System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
		print("destination :" + destination );
		File.WriteAllBytes(destination,dataToSave);
		if(!Application.isEditor)
		{
			AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
			AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
			intentObject.Call<AndroidJavaObject>("setAction",intentClass.GetStatic<string>("ACTION_SEND"));
			AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
			AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse","file://" + destination);
			intentObject.Call<AndroidJavaObject>("putExtra",intentClass.GetStatic<string>("EXTRA_STREAM"),uriObject);

			intentObject.Call<AndroidJavaObject>("setType","text/plain");
			intentObject.Call<AndroidJavaObject>("putExtra",intentClass.GetStatic<string>("EXTRA_TITLE"),"GLOBAL SHARING");
			intentObject.Call<AndroidJavaObject>("putExtra",intentClass.GetStatic<string>("EXTRA_SUBJECT"),"SUBJECT");
			intentObject.Call<AndroidJavaObject>("putExtra",intentClass.GetStatic<string>("EXTRA_TEXT"),"" + message);

			intentObject.Call<AndroidJavaObject>("setType","image/jpeg");
			AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

			currentActivity.Call("startActivity",intentObject);

		}
		isProcessing = false;
	}
}
