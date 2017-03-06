using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

using Facebook.Unity;
using Fabric.Twitter;


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
	public ForCameraPopUp forCameraPopUp;

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

	public Sprite SelectedPhoto;


	private bool isProcessing = false;

	private string status = "Ready";
	private string lastResponse = string.Empty;

	private string shareLink = "https://developers.facebook.com/";
	private string shareTitle = "Chivita";
	private string shareDescription = "Check out my favourite recipe";
	private string shareImage = "http://www.jongwings.com/chivita/uploads/20161219-095156.png";


	// Use this for initialization

	void OnEnable()
	{
		this.FBInitialisation();
		this.startLogin();
	}

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


	public void ShowMessage2 (string msg,  
		ForCameraPopUp.eMessageType msgType = ForCameraPopUp.eMessageType.Normal)
	{		

		forCameraPopUp.PopUpPanelTwo (msg, msgType);
		forCameraPopUp.gameObject.SetActive (true);
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

	public void FaceBookShare()
	{
		if (!FB.IsInitialized) {
			// Initialize the Facebook SDK
			FB.Init(LoginCompletion, OnHideUnity);
		} else {
			// Already initialized, signal an app activation App Event
			StartCoroutine(ShareImageShot());
		}

	}
	private void LoginCompletion() {
		if (FB.IsLoggedIn)
		{
			FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, LoginComplettion1);

		}
		else
		{
			print("User cancelled login");

		}

	}
	private void LoginComplettion1(IResult result) {
		if(FB.IsLoggedIn)
			StartCoroutine(ShareImageShot());
		else
			print("User not login");
		
	}


	IEnumerator ShareImageShot()
	{
		yield return new WaitForEndOfFrame();

		var width = Screen.width;
		var height = Screen.height;
		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);

		// Read screen contents into the texture
		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
		tex.Apply();
		byte[] screenshot = tex.EncodeToPNG();

		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "InteractiveConsole.png");
		wwwForm.AddField("message", "herp derp.  I did a thing!  Did I do this right?");
		FB.API("me/photos", HttpMethod.POST, this.CallbackUploadImage, wwwForm);
	}

	public void CallbackUploadImage(IResult result)
	{
		if (result == null)
		{
			AppManager.Instance.ShowMessage("Null",PopUpMessage.eMessageType.Normal);
			return;
		}


		// Some platforms return the empty string instead of null.
		if (!string.IsNullOrEmpty(result.Error))
		{

			AppManager.Instance.ShowMessage(result.Error,PopUpMessage.eMessageType.Normal);

		}
		else if (result.Cancelled)
		{
			AppManager.Instance.ShowMessage(result.RawResult,PopUpMessage.eMessageType.Normal);

		}
		else if (!string.IsNullOrEmpty(result.RawResult))
		{
			AppManager.Instance.ShowMessage(result.RawResult,PopUpMessage.eMessageType.Normal);

		}
		else
		{
		}


//		if (result.Error == null) {
//			AppManager.Instance.ShowMessage("Recipe Shared Successfully",PopUpMessage.eMessageType.Normal);
//		}
//		else
//			AppManager.Instance.ShowMessage("please check the network connection",PopUpMessage.eMessageType.Error);
		

	}

	public void FBInitialisation()
	{
		FB.Init(this.OnInitComplete, this.OnHideUnity);

	}
	private void OnInitComplete()
	{
		this.Status = "Success - Check log for details";
		this.LastResponse = "Success Response: OnInitComplete Called\n";
		string logMessage = string.Format(
			"OnInitCompleteCalled IsLoggedIn='{0}' IsInitialized='{1}'",
			FB.IsLoggedIn,
			FB.IsInitialized);
		print("logMessage :" + logMessage);
	}

	private void OnHideUnity(bool isGameShown)
	{
		this.Status = "Success - Check log for details";
		this.LastResponse = string.Format("Success Response: OnHideUnity Called {0}\n", isGameShown);
		print("Is game shown: " + isGameShown);

	}
	public void fbCustomShare()
	{
		FB.ShareLink(
			new Uri(this.shareLink),
			this.shareTitle,
			this.shareDescription,
			new Uri(this.shareImage),
			this.HandleResult);
	}

	protected void HandleResult(IResult result)
	{
		if (result == null)
		{
			this.LastResponse = "Null Response\n";
			print("LastResponse: " + this.LastResponse);
			return;
		}

		this.LastResponseTexture = null;

		// Some platforms return the empty string instead of null.
		if (!string.IsNullOrEmpty(result.Error))
		{
			this.Status = "Error - Check log for details";
			this.LastResponse = "Error Response:\n" + result.Error;
		}
		else if (result.Cancelled)
		{
			this.Status = "Cancelled - Check log for details";
			this.LastResponse = "Cancelled Response:\n" + result.RawResult;
		}
		else if (!string.IsNullOrEmpty(result.RawResult))
		{
			this.Status = "Success - Check log for details";
			this.LastResponse = "Success Response:\n" + result.RawResult;
		}
		else
		{
			this.LastResponse = "Empty Response\n";
		}

		print("result: " + result.ToString());

	}
	protected string Status
	{
		get
		{
			return this.status;
		}

		set
		{
			this.status = value;
		}
	}

	protected Texture2D LastResponseTexture { get; set; }

	protected string LastResponse
	{
		get
		{
			return this.lastResponse;
		}

		set
		{
			this.lastResponse = value;
		}
	}
	public void startLogin () {
		TwitterSession session = Twitter.Session;
		if (session == null) {
			Twitter.LogIn (LoginComplete, LoginFailure);
		} else {
			LoginComplete (session);
		}
	}

	public void LoginComplete (TwitterSession session) {
		// Start composer or request email
	}

	public void LoginFailure (ApiError error) {
		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
	}

	public void startComposer(String imageUri) {
		TwitterSession session = Twitter.Session;

		Card card = new AppCardBuilder()
			.ImageUri (imageUri)
			.GooglePlayId ("com.drinks.chivita")
			.IPhoneId ("123456789")
			.IPadId ("123456789");

		Twitter.Compose (session, card);
	}
}
