using UnityEngine;
using System.Collections;

public class ExoticController : MonoBehaviour {



	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;
	public GameObject FlavourFour;
	public GameObject FlavourFive;
	public GameObject FlavourSix;
	public GameObject FlavourSeven;
	public GameObject FlavourEight;
	public GameObject FlavourNine;
	public GameObject FlavourTen;
	public GameObject FlavourEleven;




	void OnEnable()
	{
		
		switch (GameMenuController.Instance.exoticState) {
		case GameMenuController.Exotic.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.Exotic.one:
			OnclickFlavourOne ();
			break;
		case GameMenuController.Exotic.two:
			OnclickFlavourTwo ();

			break;
		case GameMenuController.Exotic.three:
			OnclickFlavourThree ();
			break;
		case GameMenuController.Exotic.four:
			OnclickFlavourFour ();
			break;
		case GameMenuController.Exotic.five:
			OnclickFlavourFive ();
			break;
		case GameMenuController.Exotic.six:
			OnclickFlavourSix ();
			break;
		case GameMenuController.Exotic.seven:
			OnclickFlavourSeven ();
			break;
		case GameMenuController.Exotic.eight:
			OnclickFlavourEight ();
			break;
		case GameMenuController.Exotic.nine:
			OnclickFlavourNine ();
			break;
		case GameMenuController.Exotic.ten:
			OnclickFlavourTen ();
			break;
		case GameMenuController.Exotic.eleven:
			OnclickFlavourEleven ();
			break;

		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.brandsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);

	}

	public void OnClickNext()
	{
		GameMenuController.Instance.exoticBrandPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.none;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.one;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.two;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.three;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.four;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.five;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.six;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.seven;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.eight;

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
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.nine;

	}
	public void OnclickFlavourTen()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.ten;

	}
	public void OnclickFlavourEleven()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSeven.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEight.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourNine.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTen.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourEleven.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.exoticState = GameMenuController.Exotic.eleven;

	}

}
