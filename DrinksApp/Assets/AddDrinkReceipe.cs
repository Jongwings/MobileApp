using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddDrinkReceipe : MonoBehaviour {

	public Image receipeIcon;
	public Text receipeName;

	public Text brandName;
	public Text ingratiantsTxt;
	public Text PreparationTxt;

	public Dropdown BrandsDropsDown;

	// Use this for initialization
	void Start () {
	
	}
	void OnEnable()
	{
		BrandsDropsDown.options.Clear();
		foreach (string c in AppManager.Instance.BrandArray) 
		{
			BrandsDropsDown.options.Add (new Dropdown.OptionData() {text=c});
		}
		BrandsDropsDown.RefreshShownValue();

	}
	public void OnClickAddReceipe()
	{
		if(receipeName.text.Length == 0)
			AppManager.Instance.ShowMessage("Please enter the Recipe Name",PopUpMessage.eMessageType.Normal);
		else if(brandName.text.Length == 0)
			AppManager.Instance.ShowMessage("Please choose the brand",PopUpMessage.eMessageType.Normal);
		else if(ingratiantsTxt.text.Length == 0)
			AppManager.Instance.ShowMessage("Please enter the Ingredients information",PopUpMessage.eMessageType.Normal);
		else if(PreparationTxt.text.Length == 0)
			AppManager.Instance.ShowMessage("Please enter the Preparation information",PopUpMessage.eMessageType.Normal);
		else if(receipeName.text.Length != 0 && brandName.text.Length != 0 && ingratiantsTxt.text.Length !=0 && PreparationTxt.text.Length != 0)
		{
			MainMenuSlideManager.Instance.InnerPanel.SetActive (true);
			MainMenuSlideManager.Instance.PostRecipePanel.SetActive (true);
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeIcon = receipeIcon;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeName.text = receipeName.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().brandName.text = brandName.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().ingratiantsTxt.text = ingratiantsTxt.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().PreparationTxt.text = PreparationTxt.text;
		}
			


	}
}
