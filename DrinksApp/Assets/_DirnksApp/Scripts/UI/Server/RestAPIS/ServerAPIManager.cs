using UnityEngine;
using System.Collections;

namespace FitnessRun
{
	public class ServerAPIManager : Singleton<ServerAPIManager> 
	{
		protected ServerAPIManager () {}

		public const string baseURL = "http://www.jongwings.com/chivita/app/";

		public int userID;
		public string APIkey;
		public string emailId;

		public string accessToken ;
	}
}