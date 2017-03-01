using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;
using System.Collections.Generic;
using Newtonsoft.Json;
using Facebook.Unity;
using Facebook.MiniJSON;
using Fabric.Twitter;
public class SplashScreen : MonoBehaviour {
	enum LoginType{
		FaceBook = 1,
		Google = 2,
		Email = 3
	}

	public enum FacebookState
	{
		InitState = 0,
		LoginSate ,
		ApprequestSate
	}
	public FacebookState curState;
//	public Button signInButton;
//	public Button signUpButton;
//	public Button emailLoginButton;
//
//
//	public GameObject buttonPanel;
//	public SignInUpPanel signInUpPanel;
//
//	public SignInPanel signInPanel;
	public TryPanel tryPanel;
//	public Button tryModeButton;
	public Button facebookLogInButton;
	public Button TwitterLogInButton;
//	public Button emailSignInButton;
//	public Button emailSignUPButton;
//
//	public Button SkipLoginButton;

	// Email login
	public Text LoginEmailId;
	public Text LoginPassword;

	[Header("InputField")]
	public InputField emailSignInField;
	public InputField passwordSignInField;

	private string m_signText;
	private string m_passwordText;


	public GameObject SignInPanel;
	public GameObject RegisterPanel;

	private string TwitterUserName;
	private string TwitterUserId;
	private string TwitterUserMailId;

	public static SplashScreen Instance;


	void OnEnable ()
    {
		this.LoginPassword.text = "";
		this.LoginEmailId.text = "";
    }

	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		}
		//signInPanel.gameObject.SetActive (false);
		tryPanel.gameObject.SetActive (false);
//		tryModeButton.onClick.AddListener (OnClickTryModeButton);
		facebookLogInButton.onClick.AddListener (OnClickFacebookLogInButton);
		TwitterLogInButton.onClick.AddListener (OnClickTwitterLogInButton);
		//emailSignInButton.onClick.AddListener (OnClickEmailSignInButton);

		emailSignInField.onEndEdit.AddListener (OnEndEditEmail);
		passwordSignInField.onEndEdit.AddListener (OnEndEditPassword);

		StartCoroutine(checkInternetConnection((isConnected)=>{
			// handle connection status here
			if(isConnected)
			{
				if(AppManager.Instance.isInternetAvailable)
				{

					if(!PlayerPrefs.HasKey("IsInitiatedFirsTime"))
					{
						PlayerPrefs.SetInt("IsInitiatedFirsTime",1);
						PlayerPrefs.SetInt("isUserAlreadyLogin",0);
						PlayerPrefs.SetInt("isUserLoginWithFBAPI",0);
						PlayerPrefs.SetInt("isUserLoginWithTwitterAPI",0);
						PlayerPrefs.SetString("UserName","");
						PlayerPrefs.SetString("UserPassword","");
						PlayerPrefs.SetString("UserId","");
					}
					else
					{
						if(PlayerPrefs.GetInt("isUserAlreadyLogin") == 1)
						{
							m_signText = PlayerPrefs.GetString("UserName");
							m_passwordText = PlayerPrefs.GetString("UserPassword");
							print("Normal Username :" + m_signText);
							print("Normal Password :" + m_passwordText);
							this.UserLoginAPICalls (m_signText,m_passwordText);

						}
						else if(PlayerPrefs.GetInt("isUserLoginWithFBAPI") == 1)
						{
							//FB Auto Login
							AppManager.Instance.fbUserName = PlayerPrefs.GetString("FBUserName");
							AppManager.Instance.fbUserID = PlayerPrefs.GetString("FBUserID");
							AppManager.Instance.fbUserEmailID = PlayerPrefs.GetString("FBUserEmailID");
							AppManager.Instance.fbUserFirstName = PlayerPrefs.GetString("FBUserFirstName");

							print("FB fbUserName :" + AppManager.Instance.fbUserName);
							print("FB fbUserID :" + AppManager.Instance.fbUserID);
							print("FB fbUserEmailID :" + AppManager.Instance.fbUserEmailID);
							print("FB fbUserFirstName :" + AppManager.Instance.fbUserFirstName);

							this.UserLoginWithFBAPICalls (AppManager.Instance.fbUserName, AppManager.Instance.fbUserID, AppManager.Instance.fbUserEmailID, AppManager.Instance.fbUserFirstName);

						}
						else if(PlayerPrefs.GetInt("isUserLoginWithTwitterAPI") == 1)
						{
							//Twitter Auto Login
							AppManager.Instance.twitterUserName = PlayerPrefs.GetString("TwitterUserName");
							AppManager.Instance.twitterUserID = PlayerPrefs.GetString("TwitterUserID");
							AppManager.Instance.twitterUserEmailID = PlayerPrefs.GetString("TwitterUserEmailID");
							AppManager.Instance.twitterUserFirstName = PlayerPrefs.GetString("TwitterUserFirstName");

							print("Twitter twitterUserName :" + AppManager.Instance.twitterUserName);
							print("Twitter twitterUserID :" + AppManager.Instance.twitterUserID);
							print("Twitter twitterUserEmailID :" + AppManager.Instance.twitterUserEmailID);
							print("Twitter twitterUserFirstName :" + AppManager.Instance.twitterUserFirstName);

							UserLoginWithTWitterAPICalls (AppManager.Instance.twitterUserName, AppManager.Instance.twitterUserID, AppManager.Instance.twitterUserEmailID, AppManager.Instance.twitterUserFirstName);

						}
						else
						{
							Debug.Log("User not Login Yet");
						}
					}
				}
			}
			else
			{
				AppManager.Instance.EmailSighPanel.SetActive (false);
				AppManager.Instance.IntroPanel.SetActive (true);
				Invoke("CallMainMenuPanel", 3);//this will happen after 3 seconds
			}
		}));



	}

	void OnClickTryModeButton ()
	{
		tryPanel.gameObject.SetActive (true);
	}

	/// <summary>
	/// Raises the click facebook log in button event.
	/// </summary>
	void OnClickFacebookLogInButton ()
	{
		Debug.Log("Facebook Login Call-----:");
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		//ConnectionHandler.Instance.LoginFacebook();
		OnFacebookLogin();
	}
		
	/// <summary>
	/// Raises the click twitter log in button event.
	/// </summary>
	void OnClickTwitterLogInButton ()
	{
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		//ConnectionHandler.Instance.LoginGooglePlus();
		TwitterLogin();
	}

	public void OnClickEmailSignInButton ()
	{
		if (!string.IsNullOrEmpty (LoginEmailId.text) && !string.IsNullOrEmpty (LoginPassword.text)) {
			UserLoginAPICalls (m_signText,m_passwordText);
		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
		//AppManager.Instance.EmailSighPanel.SetActive (false);
		//AppManager.Instance.MainMenuPanel.SetActive (true);
	}

	public void UserLoginAPICalls(string username, string password)
	{
		string url = AppServerConstants.BaseURL + AppServerConstants.LOGIN;
		Debug.Log ("Login ---:" + url+ "Username :"+username+"password :"+password);
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_name", username);
		wwwForm.AddField ("password", password);
		Debug.Log ("Login ---:" + url);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (LoginToServerCallback (www));
	}

	IEnumerator LoginToServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
			if (result[0].returnvalue == "Login Fail") {
				PlayerPrefs.SetInt("isUserAlreadyLogin",0);
				AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
	
			} else {
				PlayerPrefs.SetInt("isUserAlreadyLogin",1);
				PlayerPrefs.SetString("UserName",m_signText);
				PlayerPrefs.SetString("UserPassword",m_passwordText);
				PlayerPrefs.SetString("UserId",result[0].user_id);
				AppManager.Instance.username = m_signText;
				AppManager.Instance.UserId = result[0].user_id;
				AppManager.Instance.EmailSighPanel.SetActive (false);
				AppManager.Instance.IntroPanel.SetActive (true);
				Invoke("CallMainMenuPanel", 3);//this will happen after 3 seconds
			}

		} else {
			PlayerPrefs.SetInt("isUserAlreadyLogin",0);
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}

	void CallMainMenuPanel()
	{
		AppManager.Instance.SplashScreenPanel.SetActive (false);
		AppManager.Instance.IntroPanel.SetActive (false);
		AppManager.Instance.MainMenuPanel.SetActive (true);

	}

	public void OnClickBackButton()
	{
		Debug.Log("Register Back Button Pressed"); 
		RegisterPanel.gameObject.SetActive(false);
		SignInPanel.gameObject.SetActive(true);
	}


	void OnClickSignInButton ()
	{
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		Q.Utils.QDebug.Log ("OnClickSignInButton");
	}

	public void OnClickSignUpButton ()
	{
		Debug.Log("Email Sign up ------->"); 
		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
		Q.Utils.QDebug.Log ("OnClickSignUpButton");
		//EnableSignInUpPanel (SignInUpPanel.eSignInUp.SignUp);
		AppManager.Instance.SighUpPanel.SetActive(true);
		AppManager.Instance.EmailSighPanel.SetActive (false);

	}

	public void OnClickSignUpConformButton()
	{
		AppManager.Instance.EmailSighPanel.SetActive (true);
		AppManager.Instance.SighUpPanel.SetActive(false);
	}

	public void OnClickSkipButton()
	{
		AppManager.Instance.EmailSighPanel.SetActive (false);
		AppManager.Instance.MainMenuPanel.SetActive (true);
	}




	public void DisableSignInUpPanel ()
	{
//		buttonPanel.gameObject.SetActive (true);
//		signInUpPanel.gameObject.SetActive (false);
	}

	void OnEndEditEmail(string text)
	{
		m_signText = text;
	}

	void OnEndEditPassword(string text)
	{
		m_passwordText = text;
	}

	//FaceBook Login
	/// <summary>
	/// FaceBook Login Functionality
	/// </summary>

	void OnCallInit()
	{
		FB.Init(this.OnInitComplete, this.OnHideUnity);
	}

	private void OnHideUnity(bool isGameShown)
	{
		Debug.Log("OnHideUnity");
	}

	void OnInitComplete()
	{
		switch(curState)
		{
		case FacebookState.InitState :
			{
				Debug.Log("Init state");
			}
			break;
		case FacebookState.LoginSate :
			{
				OnFacebookLogin();
			}
			break;
		case FacebookState.ApprequestSate :
			{
				OnFacebookLogin();
			}
			break;
		default : break;
		}
	}
	public void OnFacebookLogin()
	{
		if(FB.IsInitialized)
		{
			FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, FacebookLoginCallBack);
		}
		else
		{
			OnCallInit();
		}
	}

	void FacebookLoginCallBack(IResult result)
	{
		if(result.Error!=null)
		{
			curState = FacebookState.InitState;
			DestroyGameObject();
		}
		else if(!FB.IsLoggedIn)
		{

			curState = FacebookState.InitState;
			DestroyGameObject();
		}
		else
		{
			FB.API("me?fields=id,name,email,first_name",HttpMethod.GET,FacebookAPICallback);
		}
	}

	void FacebookAPICallback (IResult result)
	{
		if (result.Error == null) {
			var dict = result.ResultDictionary;
			string userName = dict ["name"].ToString ();
			string id = dict ["id"].ToString ();
			string first_name = dict ["first_name"].ToString ();
			string email = dict ["email"].ToString ();

			string AccessToken = Facebook.Unity.AccessToken.CurrentAccessToken.TokenString;
			Debug.Log ("FaceBook UserName ---->" + userName);
			Debug.Log ("FaceBook id -------->" + id);
			Debug.Log ("Facebook AccessToken ----->" + AccessToken);
			Debug.Log ("Facebook email ----->" + email);
			AppManager.Instance.username = userName;

			UserLoginWithFBAPICalls (userName, id, email, first_name);

			switch (curState) {
			case FacebookState.LoginSate:
				{
					curState = FacebookState.InitState;
					DestroyGameObject ();
				}
				break;

			default :
				break;
			}
		} else {
			AppManager.Instance.ShowMessage (Global.facebookLoginWrong, PopUpMessage.eMessageType.Error);
		}
	}

	void DestroyGameObject()
	{
		//_instance = null;
		//Destroy(this.gameObject);
	}
	//"http://www.jongwings.com/chivita/login_fb.php?user_name=%@&fb_user_id=%@&email=%@&first_name=%@",self.aFBName,self.aFBUserID,self.aFBEmailID,self.aFBFirstName];
	public void UserLoginWithFBAPICalls(string user_name, string fb_user_id, string email, string first_name)
	{
		AppManager.Instance.fbUserName = user_name;
		AppManager.Instance.fbUserID = fb_user_id;
		AppManager.Instance.fbUserEmailID = email;
		AppManager.Instance.fbUserFirstName = first_name;

		string url = AppServerConstants.BaseURL + AppServerConstants.FB_LOGIN;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_name", user_name);
		wwwForm.AddField ("fb_user_id", fb_user_id);
		wwwForm.AddField ("email", email);
		wwwForm.AddField ("first_name", first_name);
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (LoginWithFBToServerCallback (www));
	}

	IEnumerator LoginWithFBToServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {


			Debug.Log (www.text);
			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
			print("FB loginresult ----:" + result[0].returnvalue);
			if (result[0].returnvalue == "Login Fail") {
				PlayerPrefs.SetInt("isUserLoginWithFBAPI",0);
				AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);

			} else {
				print("FB loginUserId ----:" + result[0].user_id);

				PlayerPrefs.SetInt("isUserLoginWithFBAPI",1);
				PlayerPrefs.SetInt("isUserAlreadyLogin",0);
				PlayerPrefs.SetInt("isUserLoginWithTwitterAPI",0);

				PlayerPrefs.SetString("FBUserName",AppManager.Instance.fbUserName);
				PlayerPrefs.SetString("FBUserID",AppManager.Instance.fbUserID);
				PlayerPrefs.SetString("FBUserEmailID",AppManager.Instance.fbUserEmailID);
				PlayerPrefs.SetString("FBUserFirstName",AppManager.Instance.fbUserFirstName);
				AppManager.Instance.username = AppManager.Instance.fbUserName;
				AppManager.Instance.UserId = result[0].user_id;
				AppManager.Instance.EmailSighPanel.SetActive (false);
				AppManager.Instance.IntroPanel.SetActive (true);
				Invoke("CallMainMenuPanel", 3);//this will happen after 3 seconds

			}
		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
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
		TwitterSession session = Twitter.Session;
		Twitter.LogIn (LoginComplete, LoginFailure);
	}

	public void LoginComplete (TwitterSession session) {
		// Start composer or request email

		startRequestEmail();
		string username = session.userName;
		long id = session.id;
		TwitterUserName = session.userName;
		TwitterUserId = session.id.ToString();

	}

	public void LoginFailure (ApiError error) {
		//LoadingIndicatorManager.Hide();
		print("Twitter code=" + error.code + " msg=" + error.message);
		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
	}

	public void TwitterLogout()
	{
		Twitter.LogOut ();
	}

	public void startRequestEmail () {
		TwitterSession session = Twitter.Session;
		if (session != null) {
			Twitter.RequestEmail (session, requestEmailComplete, requestEmailFailure);
		} else {
			startLogin();
		}
	}

	public void requestEmailComplete (string email) {
		// Save email
		string Email = email;
		UserLoginWithTWitterAPICalls (TwitterUserName, TwitterUserId, Email, TwitterUserName);

	}

	public void requestEmailFailure (ApiError error) {
		print("Twitter code=" + error.code + " msg=" + error.message);
		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
	}

	public void UserLoginWithTWitterAPICalls(string user_name, string twitter_id, string email, string first_name)
	{
		AppManager.Instance.twitterUserName = user_name;
		AppManager.Instance.twitterUserID = twitter_id;
		AppManager.Instance.twitterUserEmailID = email;
		AppManager.Instance.twitterUserFirstName = first_name;

		string url = AppServerConstants.BaseURL + AppServerConstants.TW_LOGIN;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_name", user_name);
		wwwForm.AddField ("twitter_id", twitter_id);
		wwwForm.AddField ("email", email);
		wwwForm.AddField ("first_name", first_name);
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (LoginWithTwitterToServerCallback (www));
	}

	IEnumerator LoginWithTwitterToServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
			print("Twitter loginresult ----:" + result[0].returnvalue);
			if (result[0].returnvalue == "Login Fail") {
				PlayerPrefs.SetInt("isUserLoginWithTwitterAPI",0);
				AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);

			} else {
				print("Twitter loginUserId ----:" + result[0].user_id);

				PlayerPrefs.SetInt("isUserLoginWithTwitterAPI",1);
				PlayerPrefs.SetInt("isUserLoginWithFBAPI",0);
				PlayerPrefs.SetInt("isUserAlreadyLogin",0);
				PlayerPrefs.SetString("TwitterUserName",AppManager.Instance.twitterUserName);
				PlayerPrefs.SetString("TwitterUserID",AppManager.Instance.twitterUserID);
				PlayerPrefs.SetString("TwitterUserEmailID",AppManager.Instance.twitterUserEmailID);
				PlayerPrefs.SetString("TwitterUserFirstName",AppManager.Instance.twitterUserFirstName);
				AppManager.Instance.username = AppManager.Instance.twitterUserName;
				AppManager.Instance.UserId = result[0].user_id;
				AppManager.Instance.EmailSighPanel.SetActive (false);
				AppManager.Instance.IntroPanel.SetActive (true);
				Invoke("CallMainMenuPanel", 3);//this will happen after 3 seconds

			}
		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}

	IEnumerator checkInternetConnection(System.Action<bool> action){
		WWW www = new WWW("http://google.com");
		yield return www;
		if (www.error != null) {
			AppManager.Instance.isInternetAvailable = false;
			action (false);
		} else {
			AppManager.Instance.isInternetAvailable = true;
			action (true);
		}
	} 

}
