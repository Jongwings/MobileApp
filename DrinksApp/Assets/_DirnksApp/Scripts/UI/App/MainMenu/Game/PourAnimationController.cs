using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PourAnimationController : MonoBehaviour {

	public GameObject PourAnimationGlass;
	public GameObject PourAnimationCane;

	public Sprite[] animationGlassSpr1;
	public Sprite[] animationGlassSpr2;
	public Sprite[] animationGlassSpr3;
	public Sprite[] pourCaneAniSpr;

	void OnEnable()
	{
		switch(GameMenuController.Instance.ChooseGlassState)
		{
		case GameMenuController.ChooseGlass.none:
			PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr1[0];
			break;
		case GameMenuController.ChooseGlass.one:
			PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr1[0];
			break;
		case GameMenuController.ChooseGlass.two:
			PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr2[0];
			break;
		case GameMenuController.ChooseGlass.three:
			PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr3[0];
			break;
		}
	}

	public void OnclickBack()
	{
		GameMenuController.Instance.pourAnimationPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.pourAnimationPanel.SetActive (false);
		GameMenuController.Instance.makeSpeacialPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);

	}
	public void OnClickScreen()
	{
		
	}

	void Update()
	{

	}
}
