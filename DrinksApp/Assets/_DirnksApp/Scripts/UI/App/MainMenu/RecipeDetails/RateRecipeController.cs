using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RateRecipeController : MonoBehaviour {

	public Sprite starSpr1;
	public Sprite starSpr2;

	public GameObject RateButton1;
	public GameObject RateButton2;
	public GameObject RateButton3;
	public GameObject RateButton4;
	public GameObject RateButton5;

	public Text RecipeName;
	public Image RecipeImage;


	// Use this for initialization
	void OnEnable () {

		this.RecipeName.text = AppManager.Instance.RecipeNameStr;
		if(AppManager.Instance.isInternetAvailable)
			StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+AppManager.Instance.RecipeImageStr);
		else
		{
			int aIndex = System.Convert.ToInt32(AppManager.Instance.RecipeId);
			RecipeImage.sprite = AppManager.Instance.RecipeOfflineImages[(aIndex - 1)];
		}
			

		if(AppManager.Instance.RecipeRating == "0")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		}
		else if(AppManager.Instance.RecipeRating == "1")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		}
		else if(AppManager.Instance.RecipeRating == "2")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		}
		else if(AppManager.Instance.RecipeRating == "3")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		}
		else if(AppManager.Instance.RecipeRating == "4")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		}
		else if(AppManager.Instance.RecipeRating == "5")
		{
			RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
			RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr2;
		}


	}


	IEnumerator LoadImage (string url)
	{
		WWW image = new WWW (url);
		yield return image;

		if (image.error == null) {
			RecipeImage.CreateImageSprite (image.texture);
			//			Debug.LogError ("Load Image Working Fine");

		} else {
			Debug.LogError (image.error);
			//m_urlText.text += "\n"+"<color=red>" +image.error +"</color>";
		}
		//		m_imagePanel.SetActive (true);
		//
		//		TestingAppManager.Instance.ShowLoading (false);
	} 


	public void OnClickBackButton()
	{
		AppManager.Instance.RecipeRating = "0";
		MainMenuSlideManager.Instance.RecipeRatingPanel.SetActive(false);
		MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);
	}
	public void OnClickShareButton()
	{
		this.postScreenshotUploadApiCall();
	}
	public void OnClickDrinkRecipeButton()
	{
		MainMenuSlideManager.Instance.RecipeRatingPanel.SetActive(false);
		MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);
	}
	public void RateButtonCicked1()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateRecipeApiCalls ("1");

	}

	public void RateButtonCicked2()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateRecipeApiCalls ("2");

	}

	public void RateButtonCicked3()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateRecipeApiCalls ("3");

	}

	public void RateButtonCicked4()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateRecipeApiCalls ("4");

	}

	public void RateButtonCicked5()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateRecipeApiCalls ("5");

	}
	public void RateRecipeApiCalls(string aRating)
	{
		string url = AppServerConstants.BaseURL + AppServerConstants.Rating_Recipe;
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);
		wwwForm.AddField ("recipe_id", AppManager.Instance.RecipeId);
		wwwForm.AddField ("rating", aRating);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (RateRecipeApiSereverCallback (www));
	}

	IEnumerator RateRecipeApiSereverCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.RecipeRateAndShare> result = new List<SeralizedClassServer.RecipeRateAndShare> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.RecipeRateAndShare>> (www.text);
			if (result[0].returnvalue == "Recipe rating successfully") {
				this.ShareRecipeApiCalls();
			}
			else if (result[0].returnvalue == "Recipe rating updated") {
				this.ShareRecipeApiCalls();
			}else {
				AppManager.Instance.ShowMessage (result[0].returnvalue,  PopUpMessage.eMessageType.Error);
			}

		} 
	}

	public void ShareRecipeApiCalls()
	{
		string url = AppServerConstants.BaseURL + AppServerConstants.Sharing_Recipe;
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);
		wwwForm.AddField ("recipe_id", AppManager.Instance.RecipeId);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (ShareRecipeApiSereverCallback (www));
	}
	IEnumerator ShareRecipeApiSereverCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.RecipeRateAndShare> result = new List<SeralizedClassServer.RecipeRateAndShare> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.RecipeRateAndShare>> (www.text);


			if (result[0].returnvalue == "Shared successfully") {
				AppManager.Instance.ShowMessage ("Thanks for Rating",  PopUpMessage.eMessageType.Error);
			}
			else {
				AppManager.Instance.ShowMessage (result[0].returnvalue,  PopUpMessage.eMessageType.Error);

			}

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
			AppManager.Instance.fbCustomShare("uploads/manual-screen-short.png");


		} else {
		}
	}

}
