using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeController : MonoBehaviour {

	public GameObject ShakeAnimation;
	public GameObject ShakeAniText;
	public Sprite[] animationSpr;
	private int frameCounter = 0;     

	public void OnclickBack()
	{
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.addOnsPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);
	}

	public void OnClickNext()
	{
		GameMenuController.Instance.shakeUPDrinksPanel.SetActive (false);
		GameMenuController.Instance.pickGlassPanel.SetActive (true);
		AppManager.Instance.ToggleButtons.SetActive (false);

	}

	void Update ()  
	{  
		//Call the 'PlayLoop' method as a coroutine with a 0.04 delay  
		StartCoroutine("PlayLoop",0.04f);  
		//Set the material's texture to the current value of the frameCounter variable  
//		goMaterial.mainTexture = textures[frameCounter];
		ShakeAnimation.GetComponent<Image>().sprite = animationSpr[frameCounter];

	}  

	//The following methods return a IEnumerator so they can be yielded:  
	//A method to play the animation in a loop  
	IEnumerator PlayLoop(float delay)  
	{  
		//Wait for the time defined at the delay parameter  
		yield return new WaitForSeconds(delay);    

		//Advance one frame  
		frameCounter = (++frameCounter)%animationSpr.Length;  

		//Stop this coroutine  
		StopCoroutine("PlayLoop");  
	}    

	IEnumerator Play(float delay)  
	{  
		//Wait for the time defined at the delay parameter  
		yield return new WaitForSeconds(delay);    

		//If the frame counter isn't at the last frame  
		if(frameCounter < animationSpr.Length-1)  
		{  
			//Advance one frame  
			++frameCounter;  
		}  

		//Stop this coroutine  
		StopCoroutine("PlayLoop");  
	}   


}
