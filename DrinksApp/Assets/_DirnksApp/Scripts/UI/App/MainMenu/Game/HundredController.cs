using UnityEngine;
using System.Collections;

public class HundredController : MonoBehaviour {
	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;
	public GameObject FlavourFour;
	public GameObject FlavourFive;
	public GameObject FlavourSix;

	void OnEnable()
	{
		
		switch (GameMenuController.Instance.hundredState) {
		case GameMenuController.Hundred.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.Hundred.one:
			OnclickFlavourOne ();
			break;
		case GameMenuController.Hundred.two:
			OnclickFlavourTwo ();

			break;
		case GameMenuController.Hundred.three:
			OnclickFlavourThree ();
			break;
		case GameMenuController.Hundred.four:
			OnclickFlavourFour ();
			break;
		case GameMenuController.Hundred.five:
			OnclickFlavourFive ();
			break;
		case GameMenuController.Hundred.six:
			OnclickFlavourSix ();
			break;

		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
		GameMenuController.Instance.brandsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);

	}
	public void OnClickNext()
	{
		GameMenuController.Instance.hundredBrandsPanel.SetActive (false);
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
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.one;


	}
	public void OnclickFlavourTwo()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.two;


	}
	public void OnclickFlavourThree()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.three;


	}
	public void OnclickFlavourFour()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.four;


	}

	public void OnclickFlavourFive()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.five;


	}

	public void OnclickFlavourSix()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourSix.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.hundredState = GameMenuController.Hundred.six;


	}
}
