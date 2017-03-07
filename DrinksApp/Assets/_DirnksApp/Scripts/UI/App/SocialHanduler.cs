using UnityEngine;
using System.Collections;
//using Fabric.Twitter;
using Facebook.Unity;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using System;
using System.IO;
using Reign;

public class SocialHanduler : MonoBehaviour {

	public static SocialHanduler Instance;
	public Image ReignImage;

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
//		TwitterSession session = Twitter.Session;
//		Twitter.LogIn (LoginComplete, LoginFailure);
	}

//	public void LoginComplete (TwitterSession session) {
//		// Start composer or request email
//
//		startRequestEmail();
////		string username = session.userName;
////		long id = session.id;
////		TwitterUserName = session.userName;
////		TwitterUserId = session.id.ToString();
//
//	}
//
//	public void LoginFailure (ApiError error) {
//		//LoadingIndicatorManager.Hide();
//		print("Twitter code=" + error.code + " msg=" + error.message);
//		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
//	}
//
//	public void TwitterLogout()
//	{
//		Twitter.LogOut ();
//	}
//
//	public void startRequestEmail () {
//		TwitterSession session = Twitter.Session;
//		if (session != null) {
//			Twitter.RequestEmail (session, requestEmailComplete, requestEmailFailure);
//		} else {
//			startLogin();
//		}
//	}

//	public void requestEmailComplete (string email) {
//		// Save email
////		string Email = email;
//
//	}
//
//	public void requestEmailFailure (ApiError error) {
//		print("Twitter code=" + error.code + " msg=" + error.message);
//		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
//	}




	public void startComposer() {

//		StartCoroutine (TwitterShare ());
	}

//	IEnumerator TwitterShare()
//	{
//		yield return new WaitForEndOfFrame();
//
//		// Save your image on designate path
//
//		var width = Screen.width;
//		var height = Screen.height;
//		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
//		// Read screen contents into the texture
//		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//		tex.Apply();
//		byte[] bytes = tex.EncodeToPNG();
//		string path = Application.persistentDataPath + "/MyImage.png";
//		File.WriteAllBytes(path, bytes);
//		TwitterSession session = Twitter.Session;
//		if (session != null) {
//			Card card = new AppCardBuilder()
//				.ImageUri (path)
//				.GooglePlayId ("com.drinks.chivita")
//				.IPhoneId ("123456789")
//				.IPadId ("123456789");
//
//			Twitter.Compose (session, card);
//		} else {
//			startLogin();
//		}
//	}

	public void AndroidGlopalShare()
	{
		StartCoroutine(AndroidShare());

	}

	IEnumerator AndroidShare()
	{
		yield return new WaitForEndOfFrame();


		#if UNITY_ANDROID && !UNITY_EDITOR
		// Save your image on designate path

//		var width = Screen.width;
//		var height = Screen.height;
//		var tex = new Texture2D(width, height, TextureFormat.RGB24, false);
//		// Read screen contents into the texture
//		tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
//		tex.Apply();
//		byte[] bytes = tex.EncodeToPNG();
//		string path = Application.persistentDataPath + "/MyImage.png";
//		File.WriteAllBytes(path, bytes);
//		AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
//		AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
//		intentObject.Call("setAction", intentClass.GetStatic("ACTION_SEND"));
//		intentObject.Call("setType", "image/*");
//		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_SUBJECT"), "Media Sharing ");
//		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_TITLE"), "Media Sharing ");
//		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_TEXT"), "Media Sharing Android Demo");
//		AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
//		AndroidJavaClass fileClass = new AndroidJavaClass("java.io.File");
//		AndroidJavaObject fileObject = new AndroidJavaObject("java.io.File", path);// Set Image Path Here
//		AndroidJavaObject uriObject = uriClass.CallStatic("fromFile", fileObject);
//		// string uriPath = uriObject.Call("getPath");
//		bool fileExist = fileObject.Call("exists");
//		Debug.Log("File exist : " + fileExist);
//		// Attach image to intent
//		if (fileExist)
//		intentObject.Call("putExtra", intentClass.GetStatic("EXTRA_STREAM"), uriObject);
//		AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//		AndroidJavaObject currentActivity = unity.GetStatic("currentActivity");
//		currentActivity.Call("startActivity", intentObject);
		//- See more at: http://www.theappguruz.com/blog/general-sharing-in-android-ios-in-unity#sthash.As5IOlYE.dpuf
		#endif
	//- See more at: http://www.theappguruz.com/blog/general-sharing-in-android-ios-in-unity#sthash.As5IOlYE.dpuf

	}

//
//	public void Share()
//	{
//		if(!ShareImage)
//		{
//			StartCoroutine(ShareImageShot());
//		}
//	}
//
//	IEnumerator ShareImageShot()
//	{
//
//		yield return new WaitForEndOfFrame();
//		Texture2D screenTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);
//
//		screenTexture.ReadPixels(new Rect(0f, 0f, Screen.width, Screen.height),0,0);
//
//		screenTexture.Apply();
//
//		byte[] dataToSave = screenTexture.EncodeToPNG();
//
//		string destination = Path.Combine(Application.persistentDataPath, Screenshot_Name);
//
//		File.WriteAllBytes(destination, dataToSave);
//
//		var wwwForm = new WWWForm();
//		wwwForm.AddBinaryData("image", dataToSave, "InteractiveConsole.png");
//
//		FB.API("me/photos", Facebook.HttpMethod.POST, Callback, wwwForm);
//
//	}


	public void FaceBookShare()
	{
		StartCoroutine(ShareImageShot());
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

		//FB.API("me/photos", Facebook.HttpMethod.POST, Callback, wwwForm);
		FB.API("me/photos", HttpMethod.POST, CallbackUploadImage, wwwForm);
	}

	public void CallbackUploadImage(IResult result)
	{
		if (result.Error == null) {
			AppManager.Instance.ShowMessage("Recipe Shared Successfully",PopUpMessage.eMessageType.Normal);
		}
		else
			AppManager.Instance.ShowMessage("please check the network connection",PopUpMessage.eMessageType.Error);
		
	}
	public void imagePickerClicked()
	{
		// NOTE: Unity only supports loading png and jpg data
		StreamManager.LoadFileDialog(FolderLocations.Pictures, 128, 128, new string[]{".png", ".jpg", ".jpeg"}, imageLoadedCallback);
	}

	public void cameraPickerClicked()
	{
		StreamManager.LoadCameraPicker(CameraQuality.Med, 128, 128, imageLoadedCallback);
	}

	private void imageLoadedCallback(Stream stream, bool succeeded)
	{
		//enableButtons();
		MessageBoxManager.Show("Image Status", "Image Loaded: " + succeeded);
		if (!succeeded)
		{
			if (stream != null) stream.Dispose();
			return;
		}

		try
		{
			var data = new byte[stream.Length];
			stream.Read(data, 0, data.Length);
			var newImage = new Texture2D(4, 4);
			newImage.LoadImage(data);
			newImage.Apply();
			ReignImage.sprite = Sprite.Create(newImage, new Rect(0, 0, newImage.width, newImage.height), new Vector2(.5f, .5f));
		}
		catch (Exception e)
		{
			MessageBoxManager.Show("Error", e.Message);
		}
		finally
		{
			// NOTE: Make sure you dispose of this stream !!!
			if (stream != null) stream.Dispose();
		}
	}

}
