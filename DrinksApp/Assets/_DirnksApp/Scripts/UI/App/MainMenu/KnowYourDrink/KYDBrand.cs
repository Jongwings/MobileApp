using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class KYDBrand : MonoBehaviour {

	public Image brandIcon;
	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.KYDBrand brand;

	public void InitBrand(SeralizedClassServer.KYDBrand collectionBrand)
	{
		brand = collectionBrand;
		brandName.text = collectionBrand.brnad_name;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+collectionBrand.brand_thumb_img);
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
		Debug.Log ("OnClick Brand ------>"+brand.brnad_name);
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
}
