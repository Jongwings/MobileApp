using UnityEngine;
using System.Collections;

public class ActiveController : MonoBehaviour {



	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;
	public GameObject FlavourFour;





	void OnEnable()
	{
		
		switch (GameMenuController.Instance.activeState) {
		case GameMenuController.Active.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.Active.one:
			OnclickFlavourOne ();
			break;
		case GameMenuController.Active.two:
			OnclickFlavourTwo ();

			break;
		case GameMenuController.Active.three:
			OnclickFlavourThree ();
			break;
		case GameMenuController.Active.four:
			OnclickFlavourFour ();
			break;
		
		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
		GameMenuController.Instance.brandsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.activeBrandsPanel.SetActive (false);
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
		GameMenuController.Instance.activeState = GameMenuController.Active.one;
	}
	public void OnclickFlavourTwo()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.activeState = GameMenuController.Active.one;

	}
	public void OnclickFlavourThree()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.activeState = GameMenuController.Active.one;

	}
	public void OnclickFlavourFour()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourFour.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.activeState = GameMenuController.Active.one;

	}

	 
}
