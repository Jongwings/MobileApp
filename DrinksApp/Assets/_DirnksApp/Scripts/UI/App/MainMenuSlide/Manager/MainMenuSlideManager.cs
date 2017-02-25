using UnityEngine;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

public class MainMenuSlideManager : MonoBehaviour {

	public GameObject homeScreenPanel;

	public GameObject profilePanel;
	public GameObject creditsPanel;
	public GameObject FavouriatesPanel;
	public GameObject LogOutPanel;

	[Header("INNER PAGES")]
	public GameObject InnerPanel;
	public GameObject RecipeDetailsPanel;
	public GameObject RecipeRatingPanel;
	public GameObject PostRecipePanel;

	[Header ("Details Pages")]
	public GameObject DetailsPanel;
	public GameObject BrandDetailsPanel;
	public GameObject RecipesWithThisDrinkPanel;

	public RectTransform MainMenuSlidePanelRectTransform;

	public static MainMenuSlideManager Instance;



	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
		profilePanel.SetActive (false);
		creditsPanel.SetActive (false);
		FavouriatesPanel.SetActive (false);
		LogOutPanel.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnclickHideMainMenuSlideScreen()
	{
		Debug.Log ("Main Menu Hide ----:");
		MainMenuSlideOnclickHide ();
		homeScreenPanel.SetActive (false);
		profilePanel.SetActive (false);
		creditsPanel.SetActive (false);
		FavouriatesPanel.SetActive (false);
		LogOutPanel.SetActive (false);
	}

	public void OnclickHome()
	{
		
		MainMenuSlideOnclickHide ();
		homeScreenPanel.SetActive (true);
		profilePanel.SetActive (false);
		creditsPanel.SetActive (false);
		FavouriatesPanel.SetActive (false);
		LogOutPanel.SetActive (false);
	}

	public void OnclickProfile()
	{
		GETUserProfileICalls ();

	}

	public void OnclickFavourites()
	{
		FavouriatesPanel.SetActive (true);
		profilePanel.SetActive (false);
		creditsPanel.SetActive (false);
		LogOutPanel.SetActive (false);

		MainMenuSlideOnclickHide ();
	}

	public void OnclickCredit()
	{
		creditsPanel.SetActive (true);
		profilePanel.SetActive (false);
		FavouriatesPanel.SetActive (false);
		LogOutPanel.SetActive (false);

		MainMenuSlideOnclickHide ();
	}

	public void OnclickLogout()
	{
//		LogOutPanel.SetActive (true);
//		profilePanel.SetActive (false);
//		creditsPanel.SetActive (false);
//		FavouriatesPanel.SetActive (false);
		AppManager.Instance.ShowMessage1("Are you sure want to Log Out?",LogoutPopUpMessage.eMessageType.Normal);

	}

	public void MainMenuSlideOnclickShow()
	{
		//MainMenuPanelManager.Instance.MainMenuSlidePanel.SetActive (true);
		if (MainMenuSlidePanelRectTransform != null) {
			Debug.Log ("MainMenuSlideOnclickShow :111");

			LeanTween.move (MainMenuSlidePanelRectTransform, new Vector3 (-500f, 0f, 0f), 1f).setDelay (.5f);
		}
	}



	public void MainMenuSlideOnclickHide()
	{
		Debug.Log ("MainLeftActionBarHide :");
		//MainLeftActionBar.anchoredPosition3D += new Vector3(200f,0f,0f);
		//LeanTween.moveX( MainLeftActionBar, .5f, 05f).setEase(LeanTweenType.easeOutExpo).setDelay(1f);
		//LeanTween.moveZ( MainLeftActionBar, MainLeftActionBar.anchoredPosition3D.z - 80f, 1.5f).setEase(LeanTweenType.punch).setDelay(2.0f);

		//LeanTween.moveX (MainLeftActionBar, 1f, .2f);
		LeanTween.move(MainMenuSlidePanelRectTransform, new Vector3(-1050f,0f,0f), 1f).setDelay(.5f);
	}

	public void OnClickOutside()
	{
		MainMenuSlideOnclickHide ();
	}
		//Profile
	//NSString *str = [NSString stringWithFormat:@"http://www.jongwings.com/chivita/app/list-user.php?user_id=%@",aAppDelegate.aUserID];
	public void GETUserProfileICalls()
	{
		string url = AppServerConstants.BaseURL + AppServerConstants.LIST_USER;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (GetUserProfileServerCallback (www));
	}

	IEnumerator GetUserProfileServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.UserList> userList = new List<SeralizedClassServer.UserList> ();
			userList = JsonConvert.DeserializeObject<List<SeralizedClassServer.UserList>> (www.text);
			foreach (SeralizedClassServer.UserList user in userList) {
				Debug.Log ("user.username  ----:" + user.username+"AppManager.Instance.username--:"+AppManager.Instance.username);
				if (user.username == AppManager.Instance.username) {
					Debug.Log ("user.username  22222----:" + user.username+"AppManager.Instance.username--:"+AppManager.Instance.username);

					profilePanel.SetActive (true);
					creditsPanel.SetActive (false);
					FavouriatesPanel.SetActive (false);
					LogOutPanel.SetActive (false);

					MainMenuSlideOnclickHide ();
					profilePanel.transform.GetComponent<ProfileHanduler> ().SetProfile (user.name, user.username, user.email);
					break;
				}
			}


		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}


}
