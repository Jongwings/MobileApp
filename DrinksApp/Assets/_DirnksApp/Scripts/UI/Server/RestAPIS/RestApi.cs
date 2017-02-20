
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml; 
using System.Xml.Serialization;  
using MiniJSON;
using System;
using System.Linq;

public class RestApiHelper : MonoBehaviour 
{	
	
	public delegate void CallBack(IDictionary output,string resultText, string error,int responseCode,IDictionary inCustomData);
	
	
	static GameObject restApiHelperGameObject;
	static RestApiHelper restApiHelper;
	
	public static RestApiHelper  GetInstance()
	{
		if(restApiHelper==null)
		{
			restApiHelperGameObject=new GameObject("restApiHelperGameObject");
			restApiHelper = restApiHelperGameObject.AddComponent<RestApiHelper>();
			
			DontDestroyOnLoad(restApiHelperGameObject);
		}
		
		
		return restApiHelper;
		
	}
	
	
	
	//------------------------------------------------------------
	public void CallGetApi(RestAPI api, string url)
	{		
		api.wwwRequestObject = new WWW(url);
		StartCoroutine( HandleWWW(api.wwwRequestObject ,api ) );
	}
	
	
	
	public void CallPostApi(RestAPI api,string url,Dictionary<string,string> apiparams)
	{
		WWWForm form = new WWWForm();
		foreach(KeyValuePair<string, string> item in apiparams)
		{
			form.AddField(item.Key,item.Value);
		}		
		StartCoroutine( HandleWWW( new WWW(url,form), api) );		
	}
	//------------------------------------------------------------
	IEnumerator HandleWWW( WWW www ,RestAPI api)
	{
		yield return www;
		api.invokeCallback(www);	
	}

	public void StartHandleWWWAfterDelay(float seconds, WWW www ,RestAPI api)
	{
		StartCoroutine(HandleWWWAfterDelay(seconds,www,api));

	}
	IEnumerator HandleWWWAfterDelay(float seconds, WWW www ,RestAPI api)
	{
		yield return new WaitForSeconds(seconds);
		yield return www;
		api.invokeCallback(www);	
	}
}




public class RestAPI 
{
	Dictionary<string,string> apiparams;
	protected Dictionary<string,string> customData;
	
	
	protected RestApiHelper.CallBack callback;
	
	protected string url;
	public WWW wwwRequestObject;

	protected bool isRequestCanceled=false;

	
	public RestAPI (string inurl,RestApiHelper.CallBack inCallback)
	{
		url = inurl;
		callback = inCallback;
		apiparams = new Dictionary<string,string>();
		
	}
	
	public  void param(string key,string val)
	{
		apiparams[key]=val;
		
	}
	
	public  void setCustomData(string key,string val)
	{
		if(customData==null)
			customData = new Dictionary<string,string>();
	}
	
	public  void param(string key,int val)
	{
		apiparams[key]=(""+val);
		
	}

	public static bool HasSpecialChars(string yourString)
	{
		//Debug.Log ("HasSpecialChars yourString -------->>"+ yourString); 
		if(!String.IsNullOrEmpty(yourString)){
			return yourString.Any (ch => !Char.IsLetterOrDigit (ch));
		} else {
			return false;
		}
	}

	public static string EncoedeIfRequired(string inputstring){
		
		if (HasSpecialChars(inputstring))
		{
			return WWW.EscapeURL (inputstring);
			
		}
		return inputstring;
	}


	public  virtual void get(Component anobject)
	{
		RestApiHelper helper= RestApiHelper.GetInstance();
		foreach(KeyValuePair<string, string> item in apiparams)
		{

			string value = EncoedeIfRequired(item.Value);
			string key = EncoedeIfRequired(item.Key);

			url = url + key+ "=" + value + "&";
		}
//		Debug.Log("Calling api  "+this+ "Time Stamp : " + System.DateTime.Now.ToLongTimeString());
		isRequestCanceled=false;
		helper.CallGetApi(this,url);
	}


	public  virtual  void post(Component anobject)
	{

		RestApiHelper helper= RestApiHelper.GetInstance();
		helper.CallPostApi(this,url,apiparams);
		isRequestCanceled=false;
		apiparams=null;
		
	}
	
	public virtual void invokeCallback(WWW www)
	{
		if(callback != null)
		{	
			
			IDictionary resultDict = (IDictionary)Json.Deserialize(www.text);
			//			IDictionary userDetailsDict = (IDictionary)resultDict["user"];
			//			
			if(www.error != null)
				resultDict=null;
			
			callback( resultDict,www.text,www.error,000 ,customData );
			callback = null;
		}
	}


	public override string  ToString()
	{
		return url;
	}
	
	public void CancelWWWRequest()
	{
		wwwRequestObject.Dispose();
		wwwRequestObject=null;
		isRequestCanceled=true;
	}

};



public class RestApiExtention:RestAPI
{
	public float retryDely=4;//seconds
	public float retryAttempts=3;//times
	public float currentRetryAttempts=0;//times

	#if UNITY_WEBPLAYER  || UNITY_IOS ||  UNITY_ANDROID
	static public bool isMultipleConectionAllowed =false;
	#else
	static public bool isMultipleConectionAllowed =false;
	#endif 
	
	static private bool isConnetionGoingOn;

	static RestApiExtention restartbleRequest;
	static int apiCallCount;
	[System.Flags]
	public enum ExtentionType
	{
		None=0,
		RetryAfterNetworkError=1<<0,
		AutoCancelIfRequired=1<<2,
		CancelAndRestartIfRequired=1<<3 // At a time only one request can be this mode

	};

	protected ExtentionType extentionType;


	public enum ErrorCodes
	{

		ExeededRetries=3042,
		AutoCanceled=3043,
		NetWorkError=3044,
		ServerError=3045,
		MultipleConections=3046,
		JsonError=3047,
		Canceled=3048,
	};


	public RestApiExtention (string inurl,RestApiHelper.CallBack inCallback):base(inurl,inCallback)
	{

	}



	public RestApiExtention (string inurl,RestApiHelper.CallBack inCallback,ExtentionType anExtentionType):this(inurl,inCallback)
	{
		SetExtension(anExtentionType);
		
	}

	protected void SetExtension(ExtentionType aextensionType)
	{
		extentionType = aextensionType;
		
		if((extentionType & ExtentionType.RetryAfterNetworkError) == ExtentionType.RetryAfterNetworkError)
		{
			currentRetryAttempts=0;
			
		}

	}

	void SaveApiReferenceIfRequired ()
	{
		if ((extentionType & ExtentionType.AutoCancelIfRequired) == ExtentionType.AutoCancelIfRequired || (extentionType & ExtentionType.CancelAndRestartIfRequired) == ExtentionType.CancelAndRestartIfRequired) {
			RestApiExtention.restartbleRequest = this;
		}
	}



	public static void RestartTheSuspendedRequest()
	{
		if (RestApiExtention.restartbleRequest != null && (RestApiExtention.restartbleRequest.extentionType & ExtentionType.CancelAndRestartIfRequired) == ExtentionType.CancelAndRestartIfRequired)
		{
			RestApiExtention request = RestApiExtention.restartbleRequest;
			RestApiExtention.restartbleRequest =null;

			request.get(null);
		}


	}

	static void RestartableRequestSetup ()
	{
		if (RestApiExtention.isMultipleConectionAllowed == false && RestApiExtention.apiCallCount>0) {
			if (RestApiExtention.restartbleRequest != null)
				RestApiExtention.restartbleRequest.CancelWWWRequest ();
		}
	}

	public override void get(Component anobject)
	{

		RestartableRequestSetup ();


		base.get(anobject);
		SaveApiReferenceIfRequired ();

		RestApiExtention.apiCallCount++;


	}
	
	
	public override void post(Component anobject)
	{
		RestartableRequestSetup ();
		base.post(anobject);
		SaveApiReferenceIfRequired ();
		RestApiExtention.apiCallCount++;

	}

	

	public override void invokeCallback(WWW www)
	{
		apiCallCount--;

		if(callback != null)
		{

			int responcecode=0;
			string error =null;
			
			if(isRequestCanceled )//cancel
			{
				if ((extentionType & ExtentionType.AutoCancelIfRequired) == ExtentionType.AutoCancelIfRequired)
				{
					error = "RestApiExtention:AutoCancel";
					responcecode = (int)ErrorCodes.AutoCanceled;
					callback( null,error,error ,responcecode ,customData);
					callback = null;
					customData=null;
					isRequestCanceled=false;
					return;
				}else if((extentionType & ExtentionType.CancelAndRestartIfRequired) == ExtentionType.CancelAndRestartIfRequired)
				{
					//Ignore the cancel request
					Debug.Log("Suspended");
					isRequestCanceled=false;
					return;

				}else
				{
					error = "RestApiExtention:Canceled";
					responcecode = (int)ErrorCodes.Canceled;
					callback( null,error,error ,responcecode ,customData);
					callback = null;
					customData=null;
					isRequestCanceled=false;
					return;
				}

				
			}else
			{
				error=www.error;//Actual server error
				//GameStateManager.Instance.checkNetworkConnection = true;
			}


			string resultText;
			IDictionary resultDict;
			
			if(error != null)//Network related error
			{
			
				Debug.LogError("***Network error!!  Call Admin Guy!! ==>"+error + "***APICALL** "+www.url);
				resultDict=null;
				resultText = error;
				ExtentionType temp = extentionType;

				if((temp & ExtentionType.RetryAfterNetworkError) == ExtentionType.RetryAfterNetworkError && currentRetryAttempts < retryAttempts)
				{
					currentRetryAttempts++;
					RestApiHelper.GetInstance().StartHandleWWWAfterDelay(retryDely,www,this);
					return;
					
				}else
				{
					Debug.LogError("***Network error!!  Call Admin Guy!! ==>"+error + "***APICALL** "+www.url);
					responcecode = (int)ErrorCodes.ExeededRetries;

				}

				//GameStateManager.Instance.checkNetworkConnection = true;
			}
			else
			{
				//Handling API related error in advancd
				Debug.Log("***APICALL**  TimeStamp:"+ System.DateTime.Now.ToLongTimeString()+ " "+www.url+"\n=>"+www.text);
				resultDict = (IDictionary)Json.Deserialize(www.text);
				resultText=www.text;
				if(resultDict!=null)
				{
					responcecode=int.Parse(string.Format("{0}",resultDict["responseCode"]));
				}
				
				else 
					Debug.LogError("***Server error!! Call server ppl !! ==>"+www.text + "***APICALL** "+www.url);
					//GameStateManager.Instance.checkNetworkConnection = true;
				
			}
			
			callback( resultDict,resultText,error ,responcecode ,customData);
			callback = null;
			customData=null;
		}
	}
	

}


