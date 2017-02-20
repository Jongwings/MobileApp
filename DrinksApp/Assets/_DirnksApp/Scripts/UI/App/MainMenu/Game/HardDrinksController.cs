using UnityEngine;
using System.Collections;

public class HardDrinksController : MonoBehaviour {



	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;
	public GameObject FlavourFour;
	public GameObject FlavourFive;
	public GameObject FlavourSix;
	public GameObject FlavourSeven;
	public GameObject FlavourEight;
	public GameObject FlavourNine;
//	public GameObject FlavourTen;
//	public GameObject FlavourEleven;
//	public GameObject FlavourTwelve;





	void OnEnable()
	{
		switch (GameMenuController.Instance.hardDrinksState) {
		case GameMenuController.HardDrink.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.HardDrink.one:
			OnclickFlavourOne ();
			break;
		case GameMenuController.HardDrink.two:
			OnclickFlavourTwo ();

			break;
		case GameMenuController.HardDrink.three:
			OnclickFlavourThree ();
			break;
		case GameMenuController.HardDrink.four:
			OnclickFlavourFour ();
			break;
		case GameMenuController.HardDrink.five:
			OnclickFlavourFive ();
			break;
		case GameMenuController.HardDrink.six:
			OnclickFlavourSix ();
			break;
		case GameMenuController.HardDrink.seven:
			OnclickFlavourSeven ();
			break;
		case GameMenuController.HardDrink.eight:
			OnclickFlavourEight ();
			break;
		case GameMenuController.HardDrink.nine:
			OnclickFlavourNine ();
			break;
		
		}

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourTwelve.transform.FindChild ("selection").gameObject.SetActive (false);

	}

	public void OnclickBack()
	{
		GameMenuController.Instance.addDrinksPanel.SetActive (false);

		switch (GameMenuController.Instance.brandState) {
		case GameMenuController.ChooseBrand.none:
			GameMenuController.Instance.brandsPanel.SetActive (true);
			break;
		case GameMenuController.ChooseBrand.Active:
			GameMenuController.Instance.activeBrandsPanel.SetActive (true);
			break;
		case GameMenuController.ChooseBrand.HappyHour:
			GameMenuController.Instance.happyHourBrandsPanel.SetActive (true);

			break;
		case GameMenuController.ChooseBrand.Hundred:
			GameMenuController.Instance.hundredBrandsPanel.SetActive (true);

			break;
		case GameMenuController.ChooseBrand.IceTea:
			GameMenuController.Instance.TeaBrandsPanel.SetActive (true);

			break;
		case GameMenuController.ChooseBrand.Exotic:
			GameMenuController.Instance.exoticBrandPanel.SetActive (true);
			break;

		}	
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.addDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.addOnsState = GameMenuController.AddOns.none;
	}

	public void OnclickFlavourOne()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.one;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourTwo()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.two;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourThree()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.three;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourFour()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.four;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}

	public void OnclickFlavourFive()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.five;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourSix()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.six;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourSeven()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.seven;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourEight()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.eight;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}
	public void OnclickFlavourNine()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.nine;

//		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
//		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
	}


}
