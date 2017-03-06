using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
using System.Collections.Generic;
using Newtonsoft.Json;

public class BrandRecipes : MonoBehaviour {

	public Image brandIcon;
	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.BrandRecipesList brand;
	public SeralizedClassServer.OfflineRecipeDetails brand1;
	public SeralizedClassServer.CollectionsRecipesList brand2;
	public RecipesWithThisBrandController recipesWithThisBrandController;

	bool isForCollection = false;

	public void InitBrand(SeralizedClassServer.BrandRecipesList collectionBrand, RecipesWithThisBrandController mCollectionController)
	{
		isForCollection = false;
		recipesWithThisBrandController = mCollectionController;
		brand = collectionBrand;
		brandName.text = collectionBrand.recipes_name;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.recipes_image);
	}
	public void InitBrand1(SeralizedClassServer.OfflineRecipeDetails collectionBrand, RecipesWithThisBrandController mCollectionController, int aIndex)
	{
		recipesWithThisBrandController = mCollectionController;
		brand1 = collectionBrand;
		brandName.text = collectionBrand.RecipeName;
		brandIcon.sprite = AppManager.Instance.RecipeOfflineImages[aIndex];
	}
	public void InitBrand2(SeralizedClassServer.CollectionsRecipesList collectionBrand, RecipesWithThisBrandController mCollectionController)
	{
		isForCollection = true;
		recipesWithThisBrandController = mCollectionController;
		brand2 = collectionBrand;
		brandName.text = collectionBrand.recipes_name;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.recipes_image);
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
			this.aGetRatingInformation();
			/*
			if(isForCollection == false)
			{
				AppManager.Instance.RecipeId = brand.recipes_id;
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
//				MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

				//Hide Tab Bar Buttons
				AppManager.Instance.ToggleButtons.SetActive (false);
			}
			else
			{
				AppManager.Instance.RecipeId = brand2.recipes_id;
				AppManager.Instance.RecipeNameStr = brand2.recipes_name;
				AppManager.Instance.RecipePreparationStr = brand2.preparation;
				AppManager.Instance.RecipeIngrdeientsStr = brand2.ingredients;
				AppManager.Instance.RecipeImageStr = brand2.recipes_image;
				AppManager.Instance.RecipeRating = "";

				MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
				MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);

				AppManager.Instance.isRecipeDetailsForCreation = false;
				AppManager.Instance.isRecipeDetailsForFavourite = false;
				AppManager.Instance.isRecipeDetailsForSearch = true;

				//Hide Main Menus Slide Button
				AppManager.Instance.MainMenuSlideButton.SetActive (false);

				//Hide Side Menu Screens Home, Profile , Favourite , Creaion, Logout
//				MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

				//Hide Tab Bar Buttons
				AppManager.Instance.ToggleButtons.SetActive (false);
			}
			*/
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

	void aGetRatingInformation()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_Recipe;
		WWWForm wwwForm = new WWWForm ();

		if(isForCollection == false)
			wwwForm.AddField ("recipe_id", brand.recipes_id);
		else
			wwwForm.AddField ("recipe_id", brand2.recipes_id);
		
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (RatingInfoSereverCallback (www));
	}
	IEnumerator RatingInfoSereverCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			List<SeralizedClassServer.MyRecipes> categoryList = new List<SeralizedClassServer.MyRecipes> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.MyRecipes>> (temp);
			bool isHaveRecord = false ;
			foreach(SeralizedClassServer.MyRecipes brand in categoryList)
			{

				AppManager.Instance.RecipeId = brand.recipes_id;
				AppManager.Instance.RecipeNameStr = brand.recipes_name;
				AppManager.Instance.RecipePreparationStr = brand.preparation;
				AppManager.Instance.RecipeIngrdeientsStr = brand.ingredients;
				AppManager.Instance.RecipeImageStr = brand.recipes_image;
				AppManager.Instance.RecipeRating = brand.rating;

				MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
				MainMenuSlideManager.Instance.RecipeDetailsPanel.SetActive(true);

				AppManager.Instance.isRecipeDetailsForCreation = false;
				AppManager.Instance.isRecipeDetailsForFavourite = false;
				AppManager.Instance.isRecipeDetailsForSearch = true;

				//Hide Main Menus Slide Button
				AppManager.Instance.MainMenuSlideButton.SetActive (false);
				//Hide Tab Bar Buttons
				AppManager.Instance.ToggleButtons.SetActive (false);

			}

		} 
	}
}
