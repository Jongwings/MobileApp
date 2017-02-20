using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using Newtonsoft.Json;

public class ProfileHanduler : MonoBehaviour {


	public InputField name;
	public InputField username;
	public InputField emailID;
	private string m_name;
	private string m_userName;
	private string m_emailId;
	// Use this for initialization
	void Start () {
		name.onEndEdit.AddListener (OnEndEditUsrNameInputField);
		username.onEndEdit.AddListener (OnEndEditUsrNameInputField);
		emailID.onEndEdit.AddListener (OnEndEditEmailInputField);
	}

	void OnEndEditNameInputField (string text)
	{
		m_name = text;
	}

	void OnEndEditUsrNameInputField (string text)
	{
		m_userName = text;
	}

	void OnEndEditEmailInputField (string text)
	{
		m_emailId = text;
	}
	


	public void OnclickUpdateProfile()
	{
		Debug.Log ("Update Profile Button Click");
		//GETUserProfileICalls ();
		ProfileUpdateAPICalls ();

	}

	public void SetProfile(string name, string username, string email)
	{
		Debug.Log ("name ---:" + name + "username :" + username + "email--:" + email);
		this.name.text= name;
		this.username.text = username;
		this.emailID.text = email;
	}

	// Update is called once per frame
	void OnClickUpdate () {
		ProfileUpdateAPICalls ();
	}
	//edit-user.php?name=%@&email=%@&user_id=%@

	public void ProfileUpdateAPICalls()
	{
		string url = "http://www.jongwings.com/chivita/app/edit-user.php?";
		//string url = AppServerConstants.BaseURL + AppServerConstants.PROFILEEDIT;
		Debug.Log ("Profile edit this.name.text---:" + this.name.text+ "this.emailID.text :"+this.emailID.text+"user_id :"+AppManager.Instance.UserId);
		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("name", this.name.text.Trim());
		wwwForm.AddField ("email", this.emailID.text.Trim());
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);

		Debug.Log ("Profile ---:" + url);

		WWW www = new WWW (url, wwwForm);
		StartCoroutine (ProfileUpdateCallback (www));
	}

	IEnumerator ProfileUpdateCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			MainMenuSlideManager.Instance.OnclickHideMainMenuSlideScreen ();

//			List<SeralizedClassServer.Login> result = new List<SeralizedClassServer.Login> ();
//			result = JsonConvert.DeserializeObject<List<SeralizedClassServer.Login>> (www.text);
//			Debug.Log ("Profile ----:" + result[0].returnvalue);
//			if (result[0].returnvalue == "Login Fail") {
//			} else {
//				AppManager.Instance.EmailSighPanel.SetActive (false);
//				AppManager.Instance.MainMenuPanel.SetActive (true);
//			}

		} else {
			Debug.Log (www.error);

			AppManager.Instance.ShowMessage (Global.emailLoginWrong,  PopUpMessage.eMessageType.Error);
		}
	}



}
