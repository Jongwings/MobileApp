using UnityEngine;
using System.Collections;
using System.Collections;
using UnityEngine.UI;
public class SearchHanduler : MonoBehaviour {

	public GameObject drinksPanel;
	public Sprite SearchDrinksImage;
	public Sprite SearchIngredientsImage;
	public GameObject ingradiantsPanel;
	public GameObject SearchImageBar;

	void Start()
	{
		OnclickDrinksPanel ();
	}

	public void OnclickDrinksPanel ()
	{
		Debug.Log("OnclickDrinksPanel");
		SearchImageBar.GetComponent<Image>().sprite = SearchDrinksImage;
		drinksPanel.SetActive (true);
		ingradiantsPanel.SetActive (false);
	}

	public void OnclickIngradiantPanel()
	{
		Debug.Log("OnclickIngradiantPanel");
		SearchImageBar.GetComponent<Image>().sprite = SearchIngredientsImage;
		drinksPanel.SetActive (false);
		ingradiantsPanel.SetActive (true);
	}
}
