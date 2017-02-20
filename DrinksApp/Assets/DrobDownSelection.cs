using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DrobDownSelection : MonoBehaviour {
	public Text name;
	DropdownList dropdownList;
	// Use this for initialization
	void Start () {
	
	}

	public void selection(DropdownList mdropdownList)
	{
		dropdownList = mdropdownList;
	}

	public void OnClickSelection()
	{
		dropdownList.IsEnableList ();
	}
}
