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
<<<<<<< HEAD
<<<<<<< HEAD
		AppManager.Instance.fbCustomShare();
=======
		SocialHanduler.Instance.FaceBookShare();
>>>>>>> origin/master
=======
		SocialHanduler.Instance.FaceBookShare();
>>>>>>> origin/master
	}

	public void OnClickShareTwitter()
	{
		AppManager.Instance.startComposer("http://www.jongwings.com/chivita/uploads/20161219-095156.png");

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

}
