using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;

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
		MainMenuSlideManager.Instance.RecipeRatingPanel.SetActive(false);
		MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);
	}
	public void OnClickShareButton()
	{
		SocialManager.Instance.FaceBookShare();
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
	}

	public void RateButtonCicked2()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
	}

	public void RateButtonCicked3()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr1;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
	}

	public void RateButtonCicked4()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr1;
	}

	public void RateButtonCicked5()
	{
		RateButton1.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton2.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton3.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton4.gameObject.GetComponent<Image> ().sprite = starSpr2;
		RateButton5.gameObject.GetComponent<Image> ().sprite = starSpr2;
	}
}
