using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShakeController : MonoBehaviour {

	public GameObject ShakeAnimation;
	public GameObject ShakeAniText;
	public Sprite[] animationSpr;
	private int frameCounter = 0;
	public Button nextButtton;

	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;
	double shakeDetectionThreshold = 2.0f; 

	float lowPassFilterFactor = 0.01666666666667f; 
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	bool isShakeDetected = false;

	public AudioClip impact;
	AudioSource audio;

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

	void OnEnable()
	{
	}

	// Use this for initialization
	public void Start()
	{
		audio = GetComponent<AudioSource>();
		if(!Application.isEditor)
			nextButtton.interactable = false;
		
		shakeDetectionThreshold *= shakeDetectionThreshold;
		lowPassValue = Input.acceleration;
	}

	void Update ()  
	{  
		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			print("Shake event detected at time : "+Time.time);
			//Call the 'PlayLoop' method as a coroutine with a 0.04 delay  
			ShakeAniText.gameObject.SetActive(false);
			isShakeDetected = true;
			Invoke("ResetShakeDetect", 2);//this will happen after 3 seconds
			nextButtton.interactable = true;
			audio.PlayOneShot(impact, 0.7F);

			//Set the material's texture to the current value of the frameCounter variable  
			//		goMaterial.mainTexture = textures[frameCounter];
		}
		if(isShakeDetected == true)
		{
			StartCoroutine("PlayLoop",0.04f);
			ShakeAnimation.GetComponent<Image>().sprite = animationSpr[frameCounter];
		}

	}  

	void ResetShakeDetect()
	{
		isShakeDetected = false;
		frameCounter = 0;
		StopCoroutine("PlayLoop");  
		ShakeAnimation.GetComponent<Image>().sprite = animationSpr[0];

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
