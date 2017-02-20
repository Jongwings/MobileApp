using UnityEngine;
using System.Collections;
//using Fabric.Twitter;
public class SocialMAnager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


		public void TwitterLogin() {
			startLogin();
		}
	
		public void TwitterSignin(string data)
		{
			//serverLoginController.GetUserLoginWithTwitter("1212312123",data);
		}
	
		public void TwitterAccountSettingPopUp()
		{
			//PopUpManager.Show (TwitterSigninHeader, TwitterSigninDescription);
		}
	
		public void TwitterSignSuccess(string twitterid, string twitterScreenName)
		{
			//serverLoginController.GetUserLoginWithTwitter(twitterid,twitterScreenName);
		}
	
		public void startLogin () {
//			TwitterSession session = Twitter.Session;
//			Twitter.LogIn (LoginComplete, LoginFailure);
		}
	
		//public void LoginComplete (TwitterSession session) {
			// Start composer or request email
//			startRequestEmail();
//			string username = session.userName;
//			long id = session.id;

		//}
	
		//public void LoginFailure (ApiError error) {
			//LoadingIndicatorManager.Hide();
			//UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
		//}
	
		public void TwitterLogout()
		{
			//Twitter.LogOut ();
		}

	public void startRequestEmail () {
//		TwitterSession session = Twitter.Session;
//		if (session != null) {
//			Twitter.RequestEmail (session, requestEmailComplete, requestEmailFailure);
//		} else {
//			startLogin();
//		}
	}

	public void requestEmailComplete (string email) {
		// Save email
		string Email = email;
	}

//	public void requestEmailFailure (ApiError error) {
//		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
//	}


}
