using UnityEngine;
using System.Collections;

public class IceTeaController : MonoBehaviour {




	public GameObject FlavourOne;





	void OnEnable()
	{
		switch (GameMenuController.Instance.activeState) {
		case GameMenuController.Active.none:
			FlavourOne.transform.FindChild ("selection").gameObject.SetActive (false);

			break;
		case GameMenuController.Active.one:
			OnclickFlavourOne ();
			break;
		

		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.brandsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (true);

	}

	public void OnClickNext()
	{
		GameMenuController.Instance.TeaBrandsPanel.SetActive (false);
		GameMenuController.Instance.addDrinksPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
		GameMenuController.Instance.hardDrinksState = GameMenuController.HardDrink.none;

	}

	public void OnclickFlavourOne()
	{
		FlavourOne.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.iceTeaState = GameMenuController.IceTea.one;

	}

}
