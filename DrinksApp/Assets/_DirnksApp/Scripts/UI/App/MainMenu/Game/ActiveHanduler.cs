using UnityEngine;
using System.Collections;

public class Active : MonoBehaviour {

	public GameObject SelectionEnacble;

	void OnEnable()
	{
		SelectionEnacble.SetActive (false);
	}





}
