using UnityEngine;
using System.Collections;

public class AddOnsController : MonoBehaviour {



	public GameObject FlavourOne;
	public GameObject FlavourTwo;
	public GameObject FlavourThree;





	void OnEnable()
	{
		switch (GameMenuController.Instance.addOnsState) {
		case GameMenuController.AddOns.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.AddOns.one:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (true);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.AddOns.two:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.AddOns.three:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
			FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
			break;
		}

	}

	public void OnclickBack()
	{
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive(false);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.addOnsPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);

	}

	public void OnclickFlavourOne()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.addOnsState = GameMenuController.AddOns.one;

	}
	public void OnclickFlavourTwo()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (true);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.addOnsState = GameMenuController.AddOns.two;
	}

	public void OnclickFlavourThree()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourTwo.transform.FindChild ("selection").gameObject.SetActive (false);
		FlavourThree.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.addOnsState = GameMenuController.AddOns.three;

	}


	 
}
