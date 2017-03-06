using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.IO;
using Reign;

public class AddDrinkReceipe : MonoBehaviour {

	public Image receipeIcon;
	public Text receipeName;

	public Text brandName;
	public Text ingratiantsTxt;
	public Text PreparationTxt;

	public Button ImagePickerButton;

	public Dropdown BrandsDropsDown;

	public static AddDrinkReceipe Instance;


	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
		ImagePickerButton.onClick.AddListener(OnClickAddPictureBtn);

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
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeIcon.sprite = AppManager.Instance.SelectedPhoto;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().receipeName.text = receipeName.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().brandName.text = brandName.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().ingratiantsTxt.text = ingratiantsTxt.text;
			MainMenuSlideManager.Instance.PostRecipePanel.transform.GetComponent<PostRecipe> ().PreparationTxt.text = PreparationTxt.text;
		}
	}
	private void OnClickAddPictureBtn()
	{
		AppManager.Instance.ShowMessage2("Take a picture",ForCameraPopUp.eMessageType.Normal);

	}
	public void imagePickerClicked()
	{
		print("Image Picker function called");
		// NOTE: Unity only supports loading png and jpg data
		StreamManager.LoadFileDialog(FolderLocations.Pictures, 500, 500, new string[]{".png", ".jpg", ".jpeg"}, imageLoadedCallback);
	}
	public void cameraPickerClicked()
	{
		print("Camera Picker function called");
		// NOTE: Unity only supports loading png and jpg data
		StreamManager.LoadCameraPicker(CameraQuality.Med, 500, 500, imageLoadedCallback);
	}
	private void imageLoadedCallback(Stream stream, bool succeeded)
	{
		MessageBoxManager.Show("Image Status", "Image Loaded: " + succeeded);
		if (!succeeded)
		{
			if (stream != null) stream.Dispose();
			return;
		}

		try
		{
			var data = new byte[stream.Length];
			stream.Read(data, 0, data.Length);
			var newImage = new Texture2D(4, 4);
			newImage.LoadImage(data);
			newImage.Apply();
			this.receipeIcon.sprite = Sprite.Create(newImage, new Rect(0, 0, newImage.width, newImage.height), new Vector2(.5f, .5f));
			AppManager.Instance.SelectedPhoto = Sprite.Create(newImage, new Rect(0, 0, newImage.width, newImage.height), new Vector2(.5f, .5f));

		}
		catch (Exception e)
		{
			MessageBoxManager.Show("Error", e.Message);
		}
		finally
		{
			// NOTE: Make sure you dispose of this stream !!!
			if (stream != null) stream.Dispose();
		}
	}

}
