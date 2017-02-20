using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using Facebook.MiniJSON;


namespace FitnessRun.UI 
{
	/// <summary>
	/// This class will handle the login functinality 
	/// </summary>
	public class LoginController : MonoBehaviour {

		public GameObject loadingPanel;
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

		/// <summary>
		/// Start this instance.
		/// </summary>
		void Start()
		{
			OnCallInit ();

		}

		/// <summary>
		/// Raises the login button clicked event.
		/// </summary>
		public void OnEmailButtonClicked()
		{
			//FindObjectOfType<PanelSwitchController> ().PanelName ("SignIn");
		}

		public void OnFaceBookButtonClicked()
		{
			OnFacebookLogin ();
			//loadingPanel.SetActive (true);
		}

		public void OnGoogleButtonClicked()
		{
			loadingPanel.SetActive (true);
		}

		/// <summary>
		/// FaceBook Login Functionality
		/// </summary>

		void OnCallInit()
		{
			FB.Init(this.OnInitComplete, this.OnHideUnity);
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

		private void OnHideUnity(bool isGameShown)
		{
			Debug.Log("OnHideUnity");
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
			if(result.Error==null)
			{
				var dict = result.ResultDictionary;
				string userName = dict["name"].ToString();
				string id = dict["id"].ToString();
				string first_name = dict["first_name"].ToString();
				string email = dict["email"].ToString();

				string AccessToken = Facebook.Unity.AccessToken.CurrentAccessToken.TokenString;
				Debug.Log ("FaceBook UserName ---->" + userName);
				Debug.Log ("FaceBook id -------->" + id);
				Debug.Log ("Facebook AccessToken ----->" + AccessToken);
				Debug.Log ("Facebook email ----->" + email);


				switch(curState)
				{
				case FacebookState.LoginSate :
					{
						curState = FacebookState.InitState;
						DestroyGameObject();
					}
					break;
				
				default : break;
				}
			}
		}

		void DestroyGameObject()
		{
			//_instance = null;
			//Destroy(this.gameObject);
		}


		void GetUserLoginWithFaceBook(string name, string facebook_access_token, int gender)
		{
			FitnessApi api  = new FitnessApi("user.login",ServerResponseForLogintoServer);
			api.param("type", (int)LoginType.FaceBook);
			api.param("name",name);
			api.param ("facebook_access_token", facebook_access_token);
			api.param ("gender", gender);
			api.get(this);
		}

		void GetUserLoginWithGoogle(string name, string google_id, int gender)
		{
			FitnessApi api  = new FitnessApi("user.login",ServerResponseForLogintoServer);
			api.param("type",  (int)LoginType.Google);
			api.param("name",name);
			api.param ("google_id", google_id);
			api.param ("gender", gender);
			api.get(this);
		}

		public void UserLoginAPI(string emailId , string password)
		{
			FitnessApi api  = new FitnessApi("user.login",ServerResponseForLogintoServer);
			api.param("emailId",emailId);
			api.param ("password", password);
			api.get(this);
		}

		void ServerResponseForLogintoServer(IDictionary output,string text, string error,int responseCode,IDictionary inCustomData)
		{
			// check for errors
			if (output!=null)
			{
				string responseInfo =(string)output["responseInfo"];

				switch(responseCode){
				case 001:
					/**
				 * Successfull Login... Load Game..
				*/
					IDictionary userDetailsDict = (IDictionary)output ["responseMsg"];
					int userID = int.Parse (string.Format ("{0}", userDetailsDict ["user_id"]));
					string accessToken = string.Format ("{0}", userDetailsDict ["access_token"]);
					//
					Debug.Log ("Login Success--->>" + userID + "<<<---accessToken---->>" + accessToken);

					ServerAPIManager.Instance.accessToken = accessToken;
					ServerAPIManager.Instance.userID = userID;

					//					FreakAppManager.Instance.userID = ServeruserId;
					//					FreakAppManager.Instance.mobileNumber = mobileNumber;
					//					FreakAppManager.Instance.countryId = countryId;
					//string _name = (string)userDetailsDict["name"];
					/** 
				 * user id & accessToken which is given by the server is saved into the playerprefs...
				*/
					//					TestOTPAPI (LoadOtpScreen);

					//FindObjectOfType<PanelSwitchController> ().PanelName ("LoadSceneManagerPanel");
					break;
				case 207:
					/**
				* User email id Does not Exists.. U need to signIn first...
	 			*/
					break;
				default:
					/**
				 * Show Popup to let user know if anything has gone wrong while login in...
				 */
					break;
				}	
			} 
			else {
				Debug.Log("WWW Error from Server: "+ MiniJSON.Json.Serialize(output) + " " + text);
				////inapi.get(this);

			}  
		}

	}
}




