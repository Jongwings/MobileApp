using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PostRecipe : MonoBehaviour {

	public Image receipeIcon;
	public Text receipeName;

	public Text brandName;
	public Text ingratiantsTxt;
	public Text PreparationTxt;


	// Use this for initialization
	void Start () {
	
	}

	void OnEnable()
	{
		
	}
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClickShareFaceBook()
	{
		SocialManager.Instance.FaceBookShare();
	}

	public void OnClickShareTwitter()
	{
	}

	public void OnClickSubmit()
	{
		AppManager.Instance.isPopUpForPhotoUpload = true;
		AppManager.Instance.ShowMessage1("Are you sure to submit new Recipe?",LogoutPopUpMessage.eMessageType.Normal);
	}
}
