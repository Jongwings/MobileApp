using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Q.Utils;
using Newtonsoft.Json;
public class PostRecipe : MonoBehaviour {

	public Image receipeIcon;
	public Text receipeName;

	public Text brandName;
	public Text ingratiantsTxt;
	public Text PreparationTxt;

	public static PostRecipe Instance;

	bool isForFacebook = false;


	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
	}

	void OnEnable()
	{
		
	}
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClickShareFaceBook()
	{
		isForFacebook = true;
		this.postScreenshotUploadApiCall();
	}

	public void OnClickShareTwitter()
	{
		isForFacebook = false;
		this.postScreenshotUploadApiCall();


	}

	public void OnClickSubmit()
	{
		AppManager.Instance.isPopUpForPhotoUpload = true;
		AppManager.Instance.ShowMessage1("Are you sure to submit new Recipe?",LogoutPopUpMessage.eMessageType.Normal);
	}

	public void postReciepeApiCall()
	{
		byte[] bytes = AppManager.Instance.SelectedPhoto.texture.EncodeToPNG();

		string url = AppServerConstants.BaseURL + AppServerConstants.Post_Recipe;
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);
		wwwForm.AddField ("rec_name", receipeName.text);
		wwwForm.AddField ("ing", ingratiantsTxt.text);
		wwwForm.AddField ("prep", PreparationTxt.text);
		wwwForm.AddField ("b_id", "1");
		wwwForm.AddBinaryData("image", bytes, "ipodfile.png", "image/png");
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (PostRecipeServerCallBack (www));
	}

	IEnumerator PostRecipeServerCallBack (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
			if (result[0].returnvalue == "Recipes added successfully") {
				AppManager.Instance.ShowMessage(result[0].returnvalue,PopUpMessage.eMessageType.Normal);

			} else {
				AppManager.Instance.ShowMessage(result[0].returnvalue,PopUpMessage.eMessageType.Error);
			}

		} else {
			PlayerPrefs.SetInt("isUserAlreadyLogin",0);
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}

	public void postScreenshotUploadApiCall()
	{
		Texture2D screenTexture = new Texture2D(Screen.width,Screen.height,TextureFormat.RGB24,true);
		screenTexture.ReadPixels(new Rect(0f,0f,Screen.width,Screen.height),0,0);
		screenTexture.Apply();

		byte[] bytes = screenTexture.EncodeToPNG();

		string url = AppServerConstants.BaseURL + AppServerConstants.Screenshot_Upload;
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddBinaryData("image", bytes, "ipodfile.png", "image/png");
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (postScreenshotServerCallBack (www));
	}

	IEnumerator postScreenshotServerCallBack (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.PostScreenshot> result = new List<SeralizedClassServer.PostScreenshot> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.PostScreenshot>> (www.text);
			print(result[0].returnvalue);
			if(isForFacebook == true)
				AppManager.Instance.fbCustomShare("uploads/manual-screen-short.png");
			else
				AppManager.Instance.startComposer("http://www.jongwings.com/chivita/uploads/manual-screen-short.png");
			


		} else {
		}
	}
}
