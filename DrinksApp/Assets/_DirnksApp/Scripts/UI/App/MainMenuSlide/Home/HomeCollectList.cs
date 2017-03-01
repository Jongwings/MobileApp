using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class HomeCollectList : MonoBehaviour {

	public Image brandIcon;
	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.HomeCollectionList brand;
	public SeralizedClassServer.OfflineFeatureCollectionDetails brand1;

	public void InitBrand(SeralizedClassServer.HomeCollectionList collectionBrand)
	{
		brand = collectionBrand;
		brandName.text = collectionBrand.collection_name;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.recipes_image);
	}
	public void InitBrand1(SeralizedClassServer.OfflineFeatureCollectionDetails collectionBrand)
	{
		brand1 = collectionBrand;
		brandName.text = collectionBrand.CollectionName;
		if(collectionBrand.CollectionName == "Cocktails")
			brandIcon.sprite = AppManager.Instance.RecipeOfflineImages[4];
		else if(collectionBrand.CollectionName == "Mixtures")
			brandIcon.sprite = AppManager.Instance.RecipeOfflineImages[0];

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
			AppManager.Instance.isForCollectionRecipe = true;
			AppManager.Instance.BrandId = brand.collection_id;
			AppManager.Instance.collectionName = brand.collection_name;
			MainMenuSlideManager.Instance.DetailsPanel.SetActive (true);
			MainMenuSlideManager.Instance.RecipesWithThisDrinkPanel.SetActive (true);
		}
		else
		{
			AppManager.Instance.isForCollectionRecipe = true;
			AppManager.Instance.BrandId = brand1.CollectionID;
			AppManager.Instance.collectionName = brand1.CollectionName;
			MainMenuSlideManager.Instance.DetailsPanel.SetActive (true);
			MainMenuSlideManager.Instance.RecipesWithThisDrinkPanel.SetActive (true);
		}
	}
}
