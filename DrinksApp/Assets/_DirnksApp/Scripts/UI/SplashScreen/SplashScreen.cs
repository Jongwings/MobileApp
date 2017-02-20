using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;
using Facebook.Unity;
using Facebook.MiniJSON;
//using Fabric.Twitter;
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
	public Text emailId;
	public Text password;

	[Header("InputField")]
	public InputField emailSignInField;
	public InputField passwordSignInField;

	private string m_signText;
	private string m_passwordText;


	public GameObject SignInPanel;
	public GameObject RegisterPanel;

    void Awake ()
    {
    }

	// Use this for initialization
	void Start () {

		//signInPanel.gameObject.SetActive (false);
		tryPanel.gameObject.SetActive (false);
//		tryModeButton.onClick.AddListener (OnClickTryModeButton);
		facebookLogInButton.onClick.AddListener (OnClickFacebookLogInButton);
		TwitterLogInButton.onClick.AddListener (OnClickTwitterLogInButton);
		//emailSignInButton.onClick.AddListener (OnClickEmailSignInButton);

		emailSignInField.onEndEdit.AddListener (OnEndEditEmail);
		passwordSignInField.onEndEdit.AddListener (OnEndEditPassword);
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
//		GenericAudioManager.PlayFX (GenericAudioManager.SFXSounds.Button_Click_1);
//		signInPanel.gameObject.SetActive (true);
		Debug.Log("Email Sign in ------->"+emailId.text); 
		//UserLoginAPI (emailId.text, password.text);
		//UserLoginAPICalls();
		if (!string.IsNullOrEmpty (emailId.text) && !string.IsNullOrEmpty (password.text)) {
			UserLoginAPICalls (m_signText,m_passwordText);
		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
		//AppManager.Instance.EmailSighPanel.SetActive (false);
		//AppManager.Instance.MainMenuPanel.SetActive (true);
	}

	public void UserLoginAPICalls(string username, string password)
	{
		AppManager.Instance.username = username;
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
			Debug.Log ("loginresult ----:" + result[0].returnvalue);
			if (result[0].returnvalue == "Login Fail") {
				AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
	
			} else {
				AppManager.Instance.UserId = result[0].user_id;
				AppManager.Instance.EmailSighPanel.SetActive (false);
				AppManager.Instance.IntroPanel.SetActive (true);
				Invoke("CallMainMenuPanel", 3);//this will happen after 3 seconds
			}

		} else {
			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}

	void CallMainMenuPanel()
	{
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
		Debug.Log("Email id --->"+text);
	}

	void OnEndEditPassword(string text)
	{
		m_passwordText = text;
		Debug.Log("Password id --->"+text);

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
			AppManager.Instance.EmailSighPanel.SetActive (false);
			AppManager.Instance.MainMenuPanel.SetActive (true);
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
//		TwitterSession session = Twitter.Session;
//		Twitter.LogIn (LoginComplete, LoginFailure);
	}

//	public void LoginComplete (TwitterSession session) {
//		// Start composer or request email
//		startRequestEmail();
//		string username = session.userName;
//		long id = session.id;
//
//	}

//	public void LoginFailure (ApiError error) {
//		//LoadingIndicatorManager.Hide();
//		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
//	}
//
//	public void TwitterLogout()
//	{
//		Twitter.LogOut ();
//	}
//
//	public void startRequestEmail () {
//		TwitterSession session = Twitter.Session;
//		if (session != null) {
//			Twitter.RequestEmail (session, requestEmailComplete, requestEmailFailure);
//		} else {
//			startLogin();
//		}
//	}
//
//	public void requestEmailComplete (string email) {
//		// Save email
//		string Email = email;
//		UnityEngine.Debug.Log ("Twitter Email ---:"+Email);
//	}
//
//	public void requestEmailFailure (ApiError error) {
//		UnityEngine.Debug.Log ("code=" + error.code + " msg=" + error.message);
//	}

}
