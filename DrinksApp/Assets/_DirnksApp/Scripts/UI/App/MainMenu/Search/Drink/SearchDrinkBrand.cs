using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class SearchDrinkBrand : MonoBehaviour {

	public Image brandIcon;
	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.SearchDrinkListOfRecipes brand;
	public SeralizedClassServer.OfflineRecipeDetails brand1;

	public void InitBrand(SeralizedClassServer.SearchDrinkListOfRecipes collectionBrand)
	{
		brand = collectionBrand;
		brandName.text = collectionBrand.brand_name;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.recipes_image);
	}

	public void InitBrand1(SeralizedClassServer.OfflineRecipeDetails collectionBrand,int aIndex)
	{
		brand1 = collectionBrand;
		brandName.text = collectionBrand.RecipeName;
		brandIcon.sprite = AppManager.Instance.RecipeOfflineImages[aIndex];

	}
	IEnumerator LoadImage (string url)
	{
		WWW image = new WWW (url);
		yield return image;

		if (image.error == null) {
			brandIcon.CreateImageSprite (image.texture);
//			Debug.LogError ("Load Image Working Fine");

		} else {
			Debug.LogError (image.error);
			//m_urlText.text += "\n"+"<color=red>" +image.error +"</color>";
		}
		//		m_imagePanel.SetActive (true);
		//
		//		TestingAppManager.Instance.ShowLoading (false);
	} 

	public void onclickBrand()
	{
		if(AppManager.Instance.isInternetAvailable)
		{
			AppManager.Instance.RecipeNameStr = brand.recipes_name;
			AppManager.Instance.RecipePreparationStr = brand.preparation;
			AppManager.Instance.RecipeIngrdeientsStr = brand.ingredients;
			AppManager.Instance.RecipeImageStr = brand.recipes_image;
			AppManager.Instance.RecipeRating = brand.rating.ToString();
			MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
			MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);

			AppManager.Instance.isRecipeDetailsForCreation = false;
			AppManager.Instance.isRecipeDetailsForFavourite = false;
			AppManager.Instance.isRecipeDetailsForSearch = true;

			//Hide Main Menus Slide Button
			AppManager.Instance.MainMenuSlideButton.SetActive (false);

			//Hide Side Menu Screens Home, Profile , Favourite , Creaion, Logout
			MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

			//Hide Tab Bar Buttons
			AppManager.Instance.ToggleButtons.SetActive (false);
		}
		else
		{
			AppManager.Instance.RecipeId = brand1.RecipeID;
			AppManager.Instance.RecipeNameStr = brand1.RecipeName;
			AppManager.Instance.RecipePreparationStr = brand1.Preparation;
			AppManager.Instance.RecipeIngrdeientsStr = brand1.Ingeridents;
			AppManager.Instance.RecipeImageStr = brand1.RecipeImage;
			MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
			MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);

			AppManager.Instance.isRecipeDetailsForCreation = false;
			AppManager.Instance.isRecipeDetailsForFavourite = false;
			AppManager.Instance.isRecipeDetailsForSearch = true;

			//Hide Main Menus Slide Button
			AppManager.Instance.MainMenuSlideButton.SetActive (false);

			//Hide Side Menu Screens Home, Profile , Favourite , Creaion, Logout
			MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

			//Hide Tab Bar Buttons
			AppManager.Instance.ToggleButtons.SetActive (false);
		}
	}
}
