using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Q.Utils;

public class BrandDetails : MonoBehaviour {

	public Image BrandBannerImage;
	public Text BrandName;
	public Text BrandHeader1;
	public Text BrandHeaderDetails1;
	public Text BrandHeader2;
	public Text BrandHeaderDetails2;
	public Text BrandHeader3;
	public Text BrandHeaderDetails3;

//	public RectTransform BrandDetailsRect1;

	void OnEnable () {
		this.BrandName.text = AppManager.Instance.BrandNameStr;
		this.BrandHeader1.text = AppManager.Instance.BrandHeaderTitle1;
		this.BrandHeaderDetails1.text = AppManager.Instance.BrandHeaderStrText1;
		this.BrandHeader2.text = AppManager.Instance.BrandHeaderTitle2;
		this.BrandHeaderDetails2.text = AppManager.Instance.BrandHeaderStrText2;
		this.BrandHeader3.text = AppManager.Instance.BrandHeaderTitle3;
		this.BrandHeaderDetails3.text = AppManager.Instance.BrandHeaderStrText3;
		StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+AppManager.Instance.BrandImageStr);

	}

	IEnumerator LoadImage (string url)
	{
		WWW image = new WWW (url);
		yield return image;

		if (image.error == null) {
			BrandBannerImage.CreateImageSprite (image.texture);
		} else {
			Debug.LogError (image.error);
		}
	} 

	public void OnClickBackButton()
	{
		AppManager.Instance.BrandNameStr = "";
		AppManager.Instance.BrandImageStr = "";
		AppManager.Instance.BrandHeaderTitle1 = "";
		AppManager.Instance.BrandHeaderTitle2 = "";
		AppManager.Instance.BrandHeaderTitle3 = "";
		AppManager.Instance.BrandHeaderStrText1 = "";
		AppManager.Instance.BrandHeaderStrText2 = "";
		AppManager.Instance.BrandHeaderStrText3 = "";
		MainMenuSlideManager.Instance.BrandDetailsPanel.SetActive(false);
		MainMenuSlideManager.Instance.DetailsPanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (true);
	}
	public void OnClickRecipesWithThisDrinkButton()
	{

	}

	void Update () {
//		BrandDetailsRect1.sizeDelta = new Vector2(BrandDetailsRect1.rect.width, BrandHeaderDetails1.preferredHeight); // Setting the height to equal the height of text
	}
}
