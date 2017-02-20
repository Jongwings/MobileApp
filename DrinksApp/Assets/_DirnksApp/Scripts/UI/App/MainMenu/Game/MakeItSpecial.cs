using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MakeItSpecial : MonoBehaviour {

	public GameObject item1;
	public GameObject item2;
	public GameObject item3;

	public GameObject FilledGlass;

	public Sprite filledGlassSpr1;
	public Sprite filledGlassSpr2;
	public Sprite filledGlassSpr3;


	void OnEnable()
	{
		switch(GameMenuController.Instance.MakeItSplState)
		{
		case GameMenuController.MakeItSpl.none:
			item1.transform.FindChild ("Image").gameObject.SetActive (false);
			item2.transform.FindChild ("Image").gameObject.SetActive (false);
			item3.transform.FindChild ("Image").gameObject.SetActive (false);
			break;
		case GameMenuController.MakeItSpl.one:
			item1.transform.FindChild ("Image").gameObject.SetActive (true);
			item2.transform.FindChild ("Image").gameObject.SetActive (false);
			item3.transform.FindChild ("Image").gameObject.SetActive (false);
			break;
		case GameMenuController.MakeItSpl.two:
			item1.transform.FindChild ("Image").gameObject.SetActive (false);
			item2.transform.FindChild ("Image").gameObject.SetActive (true);
			item3.transform.FindChild ("Image").gameObject.SetActive (false);
			break;
		case GameMenuController.MakeItSpl.three:
			item1.transform.FindChild ("Image").gameObject.SetActive (false);
			item2.transform.FindChild ("Image").gameObject.SetActive (false);
			item3.transform.FindChild ("Image").gameObject.SetActive (true);
			break;
		}

		switch(GameMenuController.Instance.ChooseGlassState)
		{
		case GameMenuController.ChooseGlass.none:
			FilledGlass.GetComponent<Image>().sprite = filledGlassSpr1;
			break;
		case GameMenuController.ChooseGlass.one:
			FilledGlass.GetComponent<Image>().sprite = filledGlassSpr1;
			break;
		case GameMenuController.ChooseGlass.two:
			FilledGlass.GetComponent<Image>().sprite = filledGlassSpr2;
			break;
		case GameMenuController.ChooseGlass.three:
			FilledGlass.GetComponent<Image>().sprite = filledGlassSpr3;
			break;
		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.pourAnimationPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive(false);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.makeSpeacialPanel.SetActive (false);
		GameMenuController.Instance.servePanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);

	}

	public void OnclickItem1()
	{
		item1.transform.FindChild ("Image").gameObject.SetActive (true);
		item2.transform.FindChild ("Image").gameObject.SetActive (false);
		item3.transform.FindChild ("Image").gameObject.SetActive (false);
		GameMenuController.Instance.MakeItSplState = GameMenuController.MakeItSpl.one;
	}
	public void OnclickItem2()
	{
		item1.transform.FindChild ("Image").gameObject.SetActive (false);
		item2.transform.FindChild ("Image").gameObject.SetActive (true);
		item3.transform.FindChild ("Image").gameObject.SetActive (false);
		GameMenuController.Instance.MakeItSplState = GameMenuController.MakeItSpl.two;
	}
	public void OnclickItem3()
	{
		item1.transform.FindChild ("Image").gameObject.SetActive (false);
		item2.transform.FindChild ("Image").gameObject.SetActive (false);
		item3.transform.FindChild ("Image").gameObject.SetActive (true);
		GameMenuController.Instance.MakeItSplState = GameMenuController.MakeItSpl.three;
	}
}
