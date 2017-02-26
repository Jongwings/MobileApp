using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class SearchIngredientsRecipes  : MonoBehaviour {

	public Image brandIcon;
	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.SearchPanelIngredientsList brand;

	public void InitBrand(SeralizedClassServer.SearchPanelIngredientsList collectionBrand)
	{
		brand = collectionBrand;
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
}
