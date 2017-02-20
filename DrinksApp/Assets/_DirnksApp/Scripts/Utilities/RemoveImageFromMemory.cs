using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Q.Utils;

public class RemoveImageFromMemory : MonoBehaviour {

	[SerializeField] private Image m_image;
	[SerializeField] private string m_file_name;
	public Sprite sprite;

	void OnEnable () {

		if (string.IsNullOrEmpty(m_file_name) == false) {
			m_image.CreateImageSprite (Resources.Load ("HighResImage/" + m_file_name) as Texture2D );
		}
	}

	// Use this for initialization
	void Start () {

	}

	void OnDisable () {
		m_image.sprite = null;
		Resources.UnloadUnusedAssets();
	}

	#if UNITY_EDITOR
	void OnDrawGizmosSelected() {
		if (m_image == null) {
			Debug.Log ("OnDrawGizmosSelected ====");
			if (GetComponent<Image> () != null) {
				m_image = GetComponent<Image> ();
				m_image.sprite = null;
			} else {
				Debug.Log ("NO IMAGE COMPONENT ATTACHED!!!!!");
			}
		}
	}
	#endif
}
