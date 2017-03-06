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

	public Button nextButton;
	private int frameCounter = 0;
	bool isEnableGlassAnimation = false;

	public AudioClip impact;
	AudioSource audio;

	public void Start()
	{
		audio = GetComponent<AudioSource>();
	}
	void OnEnable()
	{
		frameCounter = 0;
		isEnableGlassAnimation = false;
//		if(!Application.isEditor)
			nextButton.interactable = false;
		
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

		Invoke("enableGlassAnimation", 1);//this will happen after 3 seconds

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
	void enableGlassAnimation()
	{
		frameCounter = 0;
		isEnableGlassAnimation = true;
		audio.PlayOneShot(impact, 0.7F);

	}
		

	void Update()
	{
		if(isEnableGlassAnimation == true)
		{
			if(frameCounter < 14)
				StartCoroutine("PlayLoop",0.20f);
			else
			{
				isEnableGlassAnimation = false;
				nextButton.interactable = true;
			}
			
			
			switch(GameMenuController.Instance.ChooseGlassState)
			{
			case GameMenuController.ChooseGlass.none:
				PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr1[frameCounter];
				break;
			case GameMenuController.ChooseGlass.one:
				PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr1[frameCounter];
				break;
			case GameMenuController.ChooseGlass.two:
				PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr2[frameCounter];
				break;
			case GameMenuController.ChooseGlass.three:
				PourAnimationGlass.GetComponent<Image>().sprite = animationGlassSpr3[frameCounter];
				break;
			}
		}
	}

	IEnumerator PlayLoop(float delay)  
	{  
		//Wait for the time defined at the delay parameter  
		yield return new WaitForSeconds(delay);    

		//Advance one frame  

		switch(GameMenuController.Instance.ChooseGlassState)
		{
		case GameMenuController.ChooseGlass.none:
			frameCounter = (++frameCounter)%animationGlassSpr1.Length;  
			break;
		case GameMenuController.ChooseGlass.one:
			frameCounter = (++frameCounter)%animationGlassSpr1.Length;  
			break;
		case GameMenuController.ChooseGlass.two:
			frameCounter = (++frameCounter)%animationGlassSpr2.Length;  
			break;
		case GameMenuController.ChooseGlass.three:
			frameCounter = (++frameCounter)%animationGlassSpr3.Length;  
			break;
		}

		//Stop this coroutine  
		StopCoroutine("PlayLoop");  
	}    
}
