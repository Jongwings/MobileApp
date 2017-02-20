using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitAppPanel : MonoBehaviour {

	[SerializeField] private Text m_headerText, m_descriptionText;
	[SerializeField] private Button m_YesButton, m_NoButton;

	// Use this for initialization
	void Start () {
		m_YesButton.onClick.AddListener (OnClickYesButton);
		m_NoButton.onClick.AddListener (OnClickNoButton);
	}
	
	void OnClickYesButton ()
	{
		#if UNITY_EDITOR
		Q.Utils.QDebug.Log ("On Application Quit Called");
		#endif

		Application.Quit ();
	}

	void OnClickNoButton ()
	{
		this.gameObject.SetActive (false);
	}
}
