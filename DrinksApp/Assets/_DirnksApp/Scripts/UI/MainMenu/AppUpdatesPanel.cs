using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AppUpdatesPanel : MonoBehaviour {

	[SerializeField] private Button updateButton;

	// Use this for initialization
	void Start () {
		updateButton.onClick.AddListener (OnClickUpdateButton);
	}
	
	void OnClickUpdateButton () {
	
		/*References.RemoveAllLocalTextureData ();*/

		#if UNITY_EDITOR
		Q.Utils.QDebug.Log ("UPDATE CHECK");
		#elif UNITY_ANDROID
		Application.OpenURL(TagConstant.AppStoreLink.APP_STORE_LINK_ANDROID);
		#elif UNITY_IPHONE
		Application.OpenURL(TagConstant.AppStoreLink.APP_STORE_LINK_iOS);
		#endif

		this.gameObject.SetActive (false);
	}
}
