using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;

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

		if(AppManager.Instance.isInternetAvailable)
			StartCoroutine ("LoadImage", "http://www.jongwings.com/chivita/"+AppManager.Instance.BrandImageStr);
		else
		{
			if(AppManager.Instance.BrandNameStr == "CHIVITA 100%")
				BrandBannerImage.sprite = AppManager.Instance.BrandOfflineBannerImages[0];
			else if(AppManager.Instance.BrandNameStr == "CHIVITA ACTIVE")
				BrandBannerImage.sprite = AppManager.Instance.BrandOfflineBannerImages[1];
			else if(AppManager.Instance.BrandNameStr == "CHI EXOTIC")
				BrandBannerImage.sprite = AppManager.Instance.BrandOfflineBannerImages[2];
			else if(AppManager.Instance.BrandNameStr == "HAPPY HOUR")
				BrandBannerImage.sprite = AppManager.Instance.BrandOfflineBannerImages[3];
			else if(AppManager.Instance.BrandNameStr == "CHI ICE TEA")
				BrandBannerImage.sprite = AppManager.Instance.BrandOfflineBannerImages[4];
		}
		
			

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
		if(AppManager.Instance.isInternetAvailable)
			CollectionReceipeAPICalls();
	}

	public void CollectionReceipeAPICalls()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_Recipe;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("brand_id", AppManager.Instance.BrandId);
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (CollectionReceipeServerCallback (www));
	}

	IEnumerator CollectionReceipeServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
			if (result[0].returnvalue == "No records found") {
				AppManager.Instance.ShowMessage("No Records Found",PopUpMessage.eMessageType.Normal);	
			}
			else
			{
				AppManager.Instance.isForCollectionRecipe = false;
				MainMenuSlideManager.Instance.RecipesWithThisDrinkPanel.SetActive(true);
			}
		}
	}

	void Update () {
//		BrandDetailsRect1.sizeDelta = new Vector2(BrandDetailsRect1.rect.width, BrandHeaderDetails1.preferredHeight); // Setting the height to equal the height of text
	}
}
