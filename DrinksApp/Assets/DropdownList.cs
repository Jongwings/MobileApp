using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Collections.Generic;

public class DropdownList : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler   {
	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		isOpen = false;
	}

	#endregion

	#region IPointerEnterHandler implementation
	public void OnPointerEnter (PointerEventData eventData)
	{
		isOpen = true;
	}
	#endregion

	public bool isOpen;
	public Text Title;

	public RectTransform containerRectTransform;

	public GameObject itemPrefab;


	// Use this for initialization
	void Start () {
		isOpen = false;
		//containerRectTransform = this.transform.FindChild ("Container").GetComponent<RectTransform> ();
	}

	void OnEnable()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 scale = containerRectTransform.localScale;
		scale.y = Mathf.Lerp (scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
		containerRectTransform.localScale = scale;
	}

	public void IsEnableList()
	{
		Vector3 scale = containerRectTransform.localScale;
		scale.y = Mathf.Lerp (scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
		containerRectTransform.localScale = scale;
	}


	public void ItemsAPICalls()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_COLLECTION;


		WWWForm wwwForm = new WWWForm ();

		//		wwwForm.AddField ("user_name", "daniel");
		//		wwwForm.AddField ("password", "test123");
		WWW www = new WWW (url);
		StartCoroutine (ItemsServerCallback (www));
	}

	IEnumerator ItemsServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			List<SeralizedClassServer.CollectionList> categoryList = new List<SeralizedClassServer.CollectionList> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.CollectionList>> (temp);

			//Debug.Log (JsonConvert.SerializeObject (newCategory));
			DisplayItems (categoryList);
		}
	}

	void DisplayItems(List<SeralizedClassServer.CollectionList> collectionBrandList)
	{
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.CollectionList brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(itemPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (containerRectTransform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<DrobDownSelection> ().selection (this);
			count++;
		}
	}
}
