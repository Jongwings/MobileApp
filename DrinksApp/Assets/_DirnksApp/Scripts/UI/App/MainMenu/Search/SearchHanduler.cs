using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class SearchHanduler : MonoBehaviour {

	public GameObject drinksPanel;
	public Sprite SearchDrinksImage;
	public Sprite SearchIngredientsImage;
	public GameObject ingradiantsPanel;
	public GameObject SearchImageBar;



	public GameObject SearchPanel;
	public GameObject SearchIngredientsPanel;

	public Text searchText;
	public InputField searchTextInputField;


	void Start()
	{
		OnclickDrinksPanel ();
		searchTextInputField.onEndEdit.AddListener (OnEndEditSearchTextField);

	}
	void OnEndEditSearchTextField(string text)
	{
		AppManager.Instance.searchWord = text;
		drinksPanel.SetActive (false);
		ingradiantsPanel.SetActive (false);
		if(AppManager.Instance.isSearchDrinksWord == true && AppManager.Instance.isSearchIngredientsWord == false)
		{
			SearchPanel.SetActive(true);
			SearchIngredientsPanel.SetActive(false);
		}
		else if(AppManager.Instance.isSearchDrinksWord == false && AppManager.Instance.isSearchIngredientsWord == true)
		{
			SearchPanel.SetActive(false);
			SearchIngredientsPanel.SetActive(true);
		}
	}

	public void OnclickDrinksPanel ()
	{
		AppManager.Instance.isSearchDrinksWord = true;
		AppManager.Instance.isSearchIngredientsWord = false;
		AppManager.Instance.searchWord = "";
		searchText.text = "";
		Debug.Log("OnclickDrinksPanel");
		SearchImageBar.GetComponent<Image>().sprite = SearchDrinksImage;
		drinksPanel.SetActive (true);
		ingradiantsPanel.SetActive (false);
		SearchPanel.SetActive(false);
		SearchIngredientsPanel.SetActive(false);

	}

	public void OnclickIngradiantPanel()
	{
		AppManager.Instance.isSearchDrinksWord = false;
		AppManager.Instance.isSearchIngredientsWord = true;
		AppManager.Instance.searchWord = "";
		searchText.text = "";
		Debug.Log("OnclickIngradiantPanel");
		SearchImageBar.GetComponent<Image>().sprite = SearchIngredientsImage;
		drinksPanel.SetActive (false);
		ingradiantsPanel.SetActive (true);
		SearchPanel.SetActive(false);
		SearchIngredientsPanel.SetActive(false);

	}


	public void OnSearchBtnPressed()
	{
		if(searchText.text == "")
		{
			AppManager.Instance.ShowMessage("Please enter word to search",PopUpMessage.eMessageType.Error);
		}
		else
		{
			AppManager.Instance.searchWord = searchText.text;
			Debug.Log("searchText.text :" + searchText.text);
			Debug.Log("searchWord :" + AppManager.Instance.searchWord);
			Debug.Log("On Search Btn Pressed");
			drinksPanel.SetActive (false);
			ingradiantsPanel.SetActive (false);
			if(AppManager.Instance.isSearchDrinksWord == true && AppManager.Instance.isSearchIngredientsWord == false)
			{
				SearchPanel.SetActive(true);
				SearchIngredientsPanel.SetActive(false);
			}
			else if(AppManager.Instance.isSearchDrinksWord == false && AppManager.Instance.isSearchIngredientsWord == true)
			{
				SearchPanel.SetActive(false);
				SearchIngredientsPanel.SetActive(true);
			}
		}

	}
}
