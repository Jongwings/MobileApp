using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;
public class HomeBrand : MonoBehaviour {

	public Image brandIcon;
//	public Text brandName;
	[HideInInspector]
	public SeralizedClassServer.HomeBrand brand;

	public void InitBrand(SeralizedClassServer.HomeBrand collectionBrand)
	{
		brand = collectionBrand;
//		brandName.text = collectionBrand.brnad_name;
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
		//Debug.Log ("OnClick Brand ------>"+brand.collection_name);
	}
}
