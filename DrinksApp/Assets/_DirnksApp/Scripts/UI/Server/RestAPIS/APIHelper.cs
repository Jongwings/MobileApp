using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;
using System.Xml; 
using System.Xml.Serialization;  
using System.Net;
using System.Collections.Specialized;
using System;
using FitnessRun;

public class FitnessApi :RestApiExtention
{
	public FitnessApi (string methodname,RestApiHelper.CallBack inCallback):base(ServerAPIManager.baseURL,inCallback)
	{	
		//param("",methodname);
		//param("applicationKey","12345");

		//if(!string.IsNullOrEmpty(ServerAPIManager.Instance.userID))
		if(ServerAPIManager.Instance.userID != 0)
		{
			Debug.Log ("ServerAPIManager.Instance.APIkey--->>"+ServerAPIManager.Instance.APIkey);
			//param("accessToken",ServerAPIManager.Instance.APIkey);
			param("userId",ServerAPIManager.Instance.userID);

		}
	}
}







