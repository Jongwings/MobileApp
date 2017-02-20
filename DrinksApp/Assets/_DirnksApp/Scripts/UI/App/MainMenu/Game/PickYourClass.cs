using UnityEngine;
using System.Collections;

public class PickYourClass : MonoBehaviour {

	public GameObject Glass1;
	public GameObject Glass2;
	public GameObject Glass3;

	void OnEnable()
	{
		switch (GameMenuController.Instance.ChooseGlassState) {
		case GameMenuController.ChooseGlass.none:
			Glass1.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass2.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass3.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseGlass.one:
			Glass1.transform.FindChild ("selection").gameObject.SetActive (true);
			Glass2.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass3.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseGlass.two:
			Glass1.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass2.transform.FindChild ("selection").gameObject.SetActive (true);
			Glass3.transform.FindChild ("selection").gameObject.SetActive (false);
			break;
		case GameMenuController.ChooseGlass.three:
			Glass1.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass2.transform.FindChild ("selection").gameObject.SetActive (false);
			Glass3.transform.FindChild ("selection").gameObject.SetActive (true);
			break;
		}

	}
	
	public void OnclickBack()
	{
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.pickGlassPanel.SetActive (false);
		GameMenuController.Instance.pourAnimationPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);

	}

	public void OnclickGlassOne()
	{
		Glass1.transform.FindChild ("selection").gameObject.SetActive (true);
		Glass2.transform.FindChild ("selection").gameObject.SetActive (false);
		Glass3.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.ChooseGlassState = GameMenuController.ChooseGlass.one;

	}
	public void OnclickGlassTwo()
	{
		Glass1.transform.FindChild ("selection").gameObject.SetActive (false);
		Glass2.transform.FindChild ("selection").gameObject.SetActive (true);
		Glass3.transform.FindChild ("selection").gameObject.SetActive (false);
		GameMenuController.Instance.ChooseGlassState = GameMenuController.ChooseGlass.two;
	}

	public void OnclickGlassThree()
	{
		Glass1.transform.FindChild ("selection").gameObject.SetActive (false);
		Glass2.transform.FindChild ("selection").gameObject.SetActive (false);
		Glass3.transform.FindChild ("selection").gameObject.SetActive (true);
		GameMenuController.Instance.ChooseGlassState = GameMenuController.ChooseGlass.three;

	}
}
