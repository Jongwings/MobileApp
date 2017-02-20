using UnityEngine;
using System.Collections;

public class HappyHourController : MonoBehaviour {




	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;
	public GameObject FlavourFour;
	public GameObject FlavourFive;





	void OnEnable()
	{
		

		switch (GameMenuController.Instance.happyHourState) {
		case GameMenuController.HappyHour.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);

			break;
		case GameMenuController.HappyHour.one:
			OnclickFlavourOne ();
			break;
		case GameMenuController.HappyHour.two:
			OnclickFlavourTwo ();

			break;
		case GameMenuController.HappyHour.three:
			OnclickFlavourThree ();
			break;
		case GameMenuController.HappyHour.four:
			OnclickFlavourFour ();
			break;
		case GameMenuController.HappyHour.five:
			OnclickFlavourFive ();
			break;

		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
		GameMenuController.Instance.brandsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);

	}
	public void OnClickNext()
	{
		GameMenuController.Instance.happyHourBrandsPanel.SetActive (false);
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
		GameMenuController.Instance.happyHourState = GameMenuController.HappyHour.one;


	}
	public void OnclickFlavourTwo()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.happyHourState = GameMenuController.HappyHour.two;

	}
	public void OnclickFlavourThree()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.happyHourState = GameMenuController.HappyHour.three;

	}
	public void OnclickFlavourFour()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.happyHourState = GameMenuController.HappyHour.four;

	}

	public void OnclickFlavourFive()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFive.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.happyHourState = GameMenuController.HappyHour.five;

	}
}
