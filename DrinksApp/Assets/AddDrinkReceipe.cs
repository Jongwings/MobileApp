using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddDrinkReceipe : MonoBehaviour {

	public Image receipeIcon;
	public Text receipeName;

	public Text brandName;
	public Text ingratiantsTxt;
	public Text PreparationTxt;
	// Use this for initialization
	void Start () {
	
	}
	public void OnClickAddReceipe()
	{
		MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
		MainMenuSlideManager.Instance.PostRecipePanel.SetActive (true);;
		MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeIcon = receipeIcon;
		MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeName = receipeName;
		MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().brandName = brandName;
		MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().ingratiantsTxt = ingratiantsTxt;
		MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().PreparationTxt = PreparationTxt;

	}
}
