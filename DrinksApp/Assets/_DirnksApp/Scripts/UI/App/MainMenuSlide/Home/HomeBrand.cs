using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class HomeBrand : MonoBehaviour {

	public Image brandIcon;
//	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.HomeBrand brand;
	public SeralizedClassServer.OfflineBradDetails brand1;

	public void InitBrand(SeralizedClassServer.HomeBrand collectionBrand)
	{
		brand = collectionBrand;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.brand_thumb_img);
	}
	public void InitBrand1(SeralizedClassServer.OfflineBradDetails collectionBrand,int aIndex)
	{
		brand1 = collectionBrand;
		brandIcon.sprite = AppManager.Instance.BrandOfflineThumbImages[aIndex];

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
			AppManager.Instance.BrandId = brand.brand_id;
			AppManager.Instance.BrandNameStr = brand.brnad_name;
			AppManager.Instance.BrandImageStr = brand.brand_img;
			AppManager.Instance.BrandHeaderTitle1 = brand.brand_title1;
			AppManager.Instance.BrandHeaderTitle2 = brand.brand_title2;
			AppManager.Instance.BrandHeaderTitle3 = brand.brand_title3;
			AppManager.Instance.BrandHeaderStrText1 = brand.brand_des1;
			AppManager.Instance.BrandHeaderStrText2 = brand.brand_des2;
			AppManager.Instance.BrandHeaderStrText3 = brand.brand_des3;
			MainMenuSlideManager.Instance.DetailsPanel.SetActive (true);
			MainMenuSlideManager.Instance.BrandDetailsPanel.SetActive (true);;
		}
		else
		{
			AppManager.Instance.BrandId = brand1.BrandID;
			AppManager.Instance.BrandNameStr = brand1.BrandName;
			AppManager.Instance.BrandImageStr = brand1.BrandThumpImage;
			AppManager.Instance.BrandHeaderTitle1 = brand1.BrandTitle1;
			AppManager.Instance.BrandHeaderTitle2 = brand1.BrandTitle2;
			AppManager.Instance.BrandHeaderTitle3 = brand1.BrandTitle3;
			AppManager.Instance.BrandHeaderStrText1 = brand1.BrandDescription1;
			AppManager.Instance.BrandHeaderStrText2 = brand1.BrandDescription2;
			AppManager.Instance.BrandHeaderStrText3 = brand1.BrandDescription3;
			MainMenuSlideManager.Instance.DetailsPanel.SetActive (true);
			MainMenuSlideManager.Instance.BrandDetailsPanel.SetActive (true);;
		}
	}
}
