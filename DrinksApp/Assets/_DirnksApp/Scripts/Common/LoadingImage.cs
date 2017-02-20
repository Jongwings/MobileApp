using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingImage : MonoBehaviour {

    [SerializeField] private Transform indicator;
	[SerializeField] private Image filledImage;

	void OnEnable () {

		if (filledImage != null) {
			
			filledImage.fillAmount = 0;
			filledImage.fillClockwise = true;
			
			StartCoroutine ("FillValueIncrease");
		}
	}

	void OnDisable () {

		StopCoroutine ("FillValueDecrease");
		StopCoroutine ("FillValueIncrease");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (indicator != null) {
			
			indicator.transform.Rotate (0, 0, -(400 * Time.deltaTime));
		}
    }

	IEnumerator FillValueIncrease ()
	{
		while (filledImage.fillAmount < 1f) {

			filledImage.fillAmount += Time.deltaTime;
			yield return 0;
		}

		filledImage.fillAmount = 1f;
		filledImage.fillClockwise = false;

		StartCoroutine ("FillValueDecrease");
	}

	IEnumerator FillValueDecrease ()
	{
		while (filledImage.fillAmount > 0) {

			filledImage.fillAmount -= Time.deltaTime;
			yield return 0;
		}

		filledImage.fillAmount = 0;
		filledImage.fillClockwise = true;

		StartCoroutine ("FillValueIncrease");
	}
}
