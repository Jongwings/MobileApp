using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamicGrid : MonoBehaviour {

	public int col,row;
	// Use this for initialization
	void Start () {
		RectTransform parent = gameObject.GetComponent<RectTransform> ();
		GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup> ();
		grid.cellSize = new Vector2(parent.rect.width/2,parent.rect.height/3);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
