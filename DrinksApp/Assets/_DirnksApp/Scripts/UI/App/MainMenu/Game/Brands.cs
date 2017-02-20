using UnityEngine;
using System.Collections;

public class Brands : MonoBehaviour {

	public GameObject BrandActive;
	public GameObject BrandHappyHour;
	public GameObject BrandHundred;
	public GameObject BrandIceTea;
	public GameObject BrandExotic;

	void OnEnable()
	{
		AppManager.Instance.MainMenuSlideButton.SetActive (true);
		switch (GameMenuController.Instance.brandState) {
		case GameMenuController.ChooseBrand.none:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (false);

			break;
		case GameMenuController.ChooseBrand.Active:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (true);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseBrand.HappyHour:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (true);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseBrand.Hundred:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (true);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseBrand.IceTea:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (true);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseBrand.Exotic:
			BrandActive.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHappyHour.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandHundred.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandIceTea.transform.FindChild ("selection").gameObject.SetActive (false);
			BrandExotic.transform.FindChild ("selection").gameObject.SetActive (true);
			break;

		}
	}


	public void OnclickExoticBrand()
	{
		GameMenuController.Instance.brandsPanel.SetActive (false);
		GameMenuController.Instance.exoticBrandPanel.SetActive (true);
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (false);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.brandState = GameMenuController.ChooseBrand.Exotic;

	}

	public void OnclickActiveBrand()
	{
		GameMenuController.Instance.brandsPanel.SetActive (false);
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.activeBrandsPanel.SetActive (true);
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (false);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.brandState = GameMenuController.ChooseBrand.Active;

	}

	public void OnclickHundredBrand()
	{
		GameMenuController.Instance.brandsPanel.SetActive (false);
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
		GameMenuController.Instance.hundredBrandsPanel.SetActive (true);
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (false);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.brandState = GameMenuController.ChooseBrand.Hundred;


	}

	public void OnclickHappHourBrand()
	{
		GameMenuController.Instance.brandsPanel.SetActive (false);
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (true);
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (false);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.brandState = GameMenuController.ChooseBrand.HappyHour;


	}

	public void OnclickTeaBrand()
	{
		GameMenuController.Instance.brandsPanel.SetActive (false);
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
		GameMenuController.Instance.TeaBrandsPanel.SetActive (true);
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (false);
		AppManager.Instance.MainMenuSlideButton.SetActive (false);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.brandState = GameMenuController.ChooseBrand.IceTea;


	}
}
