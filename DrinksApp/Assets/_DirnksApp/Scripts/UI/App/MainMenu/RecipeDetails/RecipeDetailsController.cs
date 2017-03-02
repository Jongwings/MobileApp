using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;

public class RecipeDetailsController : MonoBehaviour {

	public Image RecipeImage;
	public Text RecipeName;
	public Text RecipeIngrdients;
	public Text RecipePreparation;

	// Use this for initialization
	void OnEnable () {
		this.RecipeName.text = AppManager.Instance.RecipeNameStr;
		this.RecipeIngrdients.text = AppManager.Instance.RecipeIngrdeientsStr;
		this.RecipePreparation.text = AppManager.Instance.RecipePreparationStr;

		if(AppManager.Instance.isInternetAvailable)
			StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+AppManager.Instance.RecipeImageStr);
		else
		{
			int aIndex = System.Convert.ToInt32(AppManager.Instance.RecipeId);
			RecipeImage.sprite = AppManager.Instance.RecipeOfflineImages[(aIndex - 1)];
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

	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClickBackButton()
	{
		AppManager.Instance.RecipeNameStr = "";
		AppManager.Instance.RecipeIngrdeientsStr = "";
		AppManager.Instance.RecipePreparationStr = "";
		AppManager.Instance.RecipeImageStr = "";
		MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(false);
		MainMenuSlideManager.Instance.InnerPanel.SetActive (false);

		if(AppManager.Instance.isRecipeDetailsForFavourite == true)
		{
			MainMenuSlideManager.Instance.FavouriatesPanel.SetActive(true);
		}
		else if(AppManager.Instance.isRecipeDetailsForCreation == true)
		{
			MainMenuSlideManager.Instance.creditsPanel.SetActive(true);
		}		
		else if(AppManager.Instance.isRecipeDetailsForSearch == true)
		{
			AppManager.Instance.isRecipeDetailsForSearch = false;
		}

		AppManager.Instance.isRecipeDetailsForFavourite = false;
		AppManager.Instance.isRecipeDetailsForCreation = false;


		AppManager.Instance.MainMenuSlideButton.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);


	}
	public void OnClickRateButton()
	{
		MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(false);
		MainMenuSlideManager.Instance.RecipeRatingPanel.SetActive(true);

	}

	public void OnClickShareButton()
	{
		SocialHanduler.Instance.FaceBookShare();
	}
}
