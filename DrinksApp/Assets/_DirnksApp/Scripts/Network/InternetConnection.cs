using UnityEngine;
using System;
using System.Collections;

public class InternetConnection : MonoBehaviour {

    private static InternetConnection m_instance;
    public static InternetConnection Instance { get { return m_instance; } }
    private static bool m_isconnected = false;
	private IEnumerator internetRoutine;

	public const float CHECK_INTERVAL = 10F;
	public const int TIMEOUT_VALUE = 20;
	public static bool isFirstChecked = false;
    
	public static bool Check
    {
        get { return m_isconnected; }
    }

	public Action<bool> OnInternetConnectionStatus;

    void Awake ()
    {
        if (m_instance == null)
            m_instance = this;

        InternetCheckLoop();
    }

	public static InternetConnection Init (GameObject obj)
    {
        if (m_instance == null)
        {
			m_instance = obj.AddComponent<InternetConnection>();            
        }
        return m_instance;
    }

    void InternetCheckLoop ()
    {
		if (internetRoutine != null)
		{
			StopCoroutine(internetRoutine);
		}
		internetRoutine = CheckForInternetConnection (ConnectionCallback);
		StartCoroutine(internetRoutine);
    }

	IEnumerator CheckForInternetConnection (System.Action<bool> callback)
    {
//		WWW www = new WWW (ServerConstant.BASEURL);
		WWW www = new WWW ("https://www.google.com");
		float elapsedTime = 0f;
		bool internetTimeout = false;

		while (!www.isDone) 
		{			
			elapsedTime += Time.deltaTime;
			yield return null;

			if (elapsedTime > TIMEOUT_VALUE) 
			{
				internetTimeout = true;
				break;
			}
		}
		if (internetTimeout ||
		    www.error != null ||
		    www.responseHeaders.Count == 0) {
			if (www.error != null) {
				HandleErrorReport (www.error);
			}
			callback (false);
		} else {
			callback (true);
		}

		isFirstChecked = true;
		yield return new WaitForSeconds(CHECK_INTERVAL);
        InternetCheckLoop();
    }

    void ConnectionCallback (bool isConnected)
    {
        m_isconnected = isConnected;

		if (OnInternetConnectionStatus != null) {
			OnInternetConnectionStatus (isConnected);
		}
    }

	void HandleErrorReport (string error)
	{
		if (error.Contains ("Could not validate certificate")) {
		}
	}

	void WaitForInternetConnection ()
	{
	}
}