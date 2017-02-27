using UnityEngine;
using System.Collections;
using Fabric.Twitter;
using Facebook.Unity;
using System.Collections.Generic;
using Newtonsoft.Json;


public class SocialMAnager : MonoBehaviour {

	public static SocialMAnager Instance;

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void TwitterLogin() {
		startLogin();
	}

	public void TwitterSignin(string data)
	{
		//serverLoginController.GetUserLoginWithTwitter("1212312123",data);
	}

	public void TwitterAccountSettingPopUp()
	{
		//PopUpManager.Show (TwitterSigninHeader, TwitterSigninDescription);
	}

	public void TwitterSignSuccess(string twitterid, string twitterScreenName)
	{
		//serverLoginController.GetUserLoginWithTwitter(twitterid,twitterScreenName);
	}

	public void startLogin () {
		TwitterSession session = Twitter.Session;
		Twitter.LogIn (LoginComplete, LoginFailure);
	}

	public void LoginComplete (TwitterSession session) {
		// Start composer or request email

		startRequestEmail();
		string username = session.userName;
		long id = session.id;
//		TwitterUserName = session.userName;
//		TwitterUserId = session.id.ToString();

	}

	public void LoginFailure (ApiError error) {
		//LoadingIndicatorManager.Hide();
		print("Twitter code=" + error.code + " msg=" + error.message);
		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
	}

	public void TwitterLogout()
	{
		Twitter.LogOut ();
	}

	public void startRequestEmail () {
		TwitterSession session = Twitter.Session;
		if (session != null) {
			Twitter.RequestEmail (session, requestEmailComplete, requestEmailFailure);
		} else {
			startLogin();
		}
	}

	public void requestEmailComplete (string email) {
		// Save email
		string Email = email;

	}

	public void requestEmailFailure (ApiError error) {
		print("Twitter code=" + error.code + " msg=" + error.message);
		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
	}




	public void startComposer(string imageUri) {

		TwitterSession session = Twitter.Session;
		if (session != null) {
			Card card = new AppCardBuilder()
				.ImageUri (imageUri)
				.GooglePlayId ("com.drinks.chivita")
				.IPhoneId ("123456789")
				.IPadId ("123456789");

			Twitter.Compose (session, card);
		} else {
			startLogin();
		}

	}

	public void TakeScreenShotAndShare()
	{
		Texture2D screeshot = new Texture2D (480, 320, TextureFormat.RGB24, false);
		Texture border = new Texture2D (2, 2, TextureFormat.RGB24, false);
		screeshot.ReadPixels (new Rect (120, 98, 298, 198), 0, 0);
		AndroidGlopalShare (screeshot);
	}

	public void AndroidGlopalShare(Texture2D MyImage)
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		// Save your image on designate path
		byte[] bytes = MyImage.EncodeToPNG();
		string path = Application.persistentDataPath + "/MyImage.png";
		File.WriteAllBytes(path, bytes);
		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
		intentObject.Call("setAction", intentClass.GetStatic("ACTION_SEND"));
		intentObject.Call("setType", "image/*");
		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_SUBJECT"), "Media Sharing ");
		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_TITLE"), "Media Sharing ");
		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_TEXT"), "Media Sharing Android Demo");
		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
		AndroidJavaClass fileClass = new AndroidJavaClass("java.io.File");
		AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", path);// Set Image Path Here
		AndroidJavaObject uriObject = uriClass.CallStatic("fromFile", fileObject);
		// string uriPath = uriObject.Call("getPath");
		bool fileExist = fileObject.Call("exists");
		Debug.Log("File exist : " + fileExist);
		// Attach image to intent
		if (fileExist)
		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_STREAM"), uriObject);
		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
		AndroidJavaObject currentActivity = unity.GetStatic("currentActivity");
		currentActivity.Call("startActivity", intentObject);
		- See more at: http://www.theappguruz.com/blog/general-sharing-in-android-ios-in-unity#sthash.As5IOlYE.dpuf
		#endif
	//- See more at: http://www.theappguruz.com/blog/general-sharing-in-android-ios-in-unity#sthash.As5IOlYE.dpuf
	}

	public void FaceBookShare()
	{
		var snap = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		snap.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
		snap.Apply();
		var screenshot = snap.EncodeToPNG();

		int i = UnityEngine.Random.Range (0, 2);

		var wwwForm = new WWWForm();
		wwwForm.AddBinaryData("image", screenshot, "picture.png");
		wwwForm.AddField ("name", "this will be the caption for the image");

		FB.API("me/photos", HttpMethod.POST, CallbackUploadImage, wwwForm);
	}

	public void CallbackUploadImage(IResult result)
	{
		if (result.Error == null) {
		}
	}



}
