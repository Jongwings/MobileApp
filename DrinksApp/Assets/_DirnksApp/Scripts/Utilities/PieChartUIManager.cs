using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Q.Utils;

public class PieChartUIManager : MonoBehaviour {

	public Image pieImage;
	public Color[] colorArray;

	private List<PieContent> pieChartList = new List<PieContent> ();

	private float totalPercentage = 0f;

	[System.Serializable]
	public class PieContent
	{
		public float percentage;
		public Image pie_image;
		public Color color;
	}

		
	public void InitPieValues (List<float> allpercentage)
	{
		totalPercentage = 0;

		if (pieChartList.Count > 0) {
			for (int i = 0; i < pieChartList.Count; i++) {
				Destroy (pieChartList [i].pie_image.gameObject);
			}
			pieChartList.Clear ();
		}

		for (int i = 0; i < allpercentage.Count; i++) {
			totalPercentage = totalPercentage + allpercentage [i];
		}

		for (int i=0; i < allpercentage.Count; i++) {

			PieContent _pieContent = new PieContent ();

			_pieContent.percentage = allpercentage [i] / totalPercentage;
			_pieContent.pie_image = (Image) Instantiate (pieImage);
			_pieContent.pie_image.rectTransform.gameObject.RectTransformMakeChild (pieImage.transform.parent);
			_pieContent.pie_image.rectTransform.RectTransformCopyComponent (pieImage.rectTransform);
			_pieContent.pie_image.rectTransform.SetAsFirstSibling ();

			_pieContent.color = colorArray [i];
			pieChartList.Add (_pieContent);
		}



		for (int i=0; i< pieChartList.Count; i++) {
			float fillAmount = 0f;
			if (i > 0) {
				fillAmount = pieChartList [i - 1].pie_image.fillAmount; //To add previous components fillamount
			}
			pieChartList [i].pie_image.fillAmount = fillAmount + pieChartList [i].percentage;
			pieChartList [i].pie_image.color = pieChartList [i].color;
			if (i != 0) {

				float _totalPercentage = 0;

				for (int j=0; j < i; j++) {
					_totalPercentage += pieChartList [j].percentage;
				}
			}
			pieChartList [i].pie_image.gameObject.SetActive (true);
		}
	}
}
