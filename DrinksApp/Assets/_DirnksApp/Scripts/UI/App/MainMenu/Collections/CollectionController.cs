using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using Q.Utils;

public class CollectionController : MonoBehaviour {

	public class CollectionDictionary
	{
		public List<SeralizedClassServer.CollectionBrand> categoryList = new List<SeralizedClassServer.CollectionBrand> ();
	}

	public GameObject collectionBrandPrefab;
	public GameObject collectionReceipePrefab;
	public GameObject FlavourReceipePrefab;

	public GameObject flavourPanel;

	public Transform collectionBrandScrollTransform;
	public Transform collectionReceipeScrollTrandform;
	public Transform flavourScrollTrandform;



	// Use this for initialization
	void Start () {
		

	}

	void clearGrid(Transform aTransform)
	{
		foreach (Transform item in aTransform.transform)
		{
			if (item != null)
			{
				Destroy(item.gameObject);
			}
		}
	}

	void OnEnable()
	{
		if(AppManager.Instance.isInternetAvailable)
		{
			flavourPanel.SetActive (false);
			CollectionsAPICalls ();
			CollectionReceipeAPICalls ();
		}
		else
		{
			AppManager.Instance.ReadFileOfflineFeatureCollectionDetails();
			this.DisplayOfflineFeatureCollection(AppManager.Instance.offlineFeatureCollectionDetails);
			AppManager.Instance.ReadFileOfflineCollectionDetails();
			this.DisplayOfflineCollection(AppManager.Instance.offlineCollectionDetails);

		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CollectionsAPICalls()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.FEATURE_COLLECTION;

		WWWForm wwwForm = new WWWForm ();

		//		wwwForm.AddField ("user_name", "daniel");
		//		wwwForm.AddField ("password", "test123");
		WWW www = new WWW (url);
		StartCoroutine (CollectionServerCallback (www));
	}

	IEnumerator CollectionServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			List<SeralizedClassServer.CollectionBrand> categoryList = new List<SeralizedClassServer.CollectionBrand> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.CollectionBrand>> (temp);

			//Debug.Log (JsonConvert.SerializeObject (newCategory));
			DisplayCollectionBrands (categoryList);
		}
	}

	void DisplayCollectionBrands(List<SeralizedClassServer.CollectionBrand> collectionBrandList)
	{
		clearGrid(collectionBrandScrollTransform);
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.CollectionBrand brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionBrandPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionBrandScrollTransform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<Brand> ().InitBrand (brand);
			count++;
		}
	}
	void DisplayOfflineFeatureCollection(List<SeralizedClassServer.OfflineFeatureCollectionDetails> collectionBrandList)
	{
		clearGrid(collectionBrandScrollTransform);
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.OfflineFeatureCollectionDetails brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionBrandPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionBrandScrollTransform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<Brand> ().InitBrand1 (brand);
			count++;
		}
	}

	public void CollectionReceipeAPICalls()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_COLLECTION;


		WWWForm wwwForm = new WWWForm ();

		//		wwwForm.AddField ("user_name", "daniel");
		//		wwwForm.AddField ("password", "test123");
		WWW www = new WWW (url);
		StartCoroutine (CollectionReceipeServerCallback (www));
	}

	IEnumerator CollectionReceipeServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			List<SeralizedClassServer.CollectionList> categoryList = new List<SeralizedClassServer.CollectionList> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.CollectionList>> (temp);

			//Debug.Log (JsonConvert.SerializeObject (newCategory));
			DisplayCollectionBrands1 (categoryList);
		}
	}

//	string GetResponseMessage (string serverResponse)
//	{
//		IDictionary response = (IDictionary)Facebook.MiniJSON.Json.Deserialize(serverResponse);
//		string _response_msg = JsonConvert.SerializeObject(response[ServerConstant.RESPONSE_MSG]);
//
//		return _response_msg;
//	}

//	void LoadScrollView(List<Collection> collectionList)
//	{
//		foreach (Collection catagory in collectionList) {
//			Debug.Log ("" + catagory.collection_id);
//			Debug.Log ("" + catagory.collection_name);
//
//			Debug.Log ("" + catagory.recipes_image);
//			StartCoroutine("LoadImage","http://www.jongwings.com/chivita/"+catagory.recipes_image);
//		}
//	}

//	IEnumerator LoadImage(string url) {
//		WWW www = new WWW(url);
//		yield return www;
//		Renderer renderer = temp.GetComponent<Renderer>();
//		Texture mtexture = www.texture;
//		temp.sprite = mtexture.ToSprite ();
//	}

//	IEnumerator LoadImage (string url)
//	{
//		WWW image = new WWW (url);
//		yield return image;
//
//		if (image.error == null) {
//			temp.CreateImageSprite (image.texture);
//			Debug.LogError ("Load Image Working Fine");
//
//		} else {
//			Debug.LogError (image.error);
//			//m_urlText.text += "\n"+"<color=red>" +image.error +"</color>";
//		}
////		m_imagePanel.SetActive (true);
////
////		TestingAppManager.Instance.ShowLoading (false);
//	} 

	void DisplayCollectionBrands1(List<SeralizedClassServer.CollectionList> collectionBrandList)
	{
		clearGrid(collectionReceipeScrollTrandform);

		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.CollectionList brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionReceipePrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionReceipeScrollTrandform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<CollectList> ().InitBrand (brand, this);
			count++;
		}
	}

	void DisplayOfflineCollection(List<SeralizedClassServer.OfflineCollectionDetails> collectionBrandList)
	{
		clearGrid(collectionReceipeScrollTrandform);

		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.OfflineCollectionDetails brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionReceipePrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionReceipeScrollTrandform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<CollectList> ().InitBrand1 (brand, this);
			count++;
		}
	}

	public void FlavourAPICalls()
	{
		flavourPanel.SetActive (true);
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_Recipe;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (FlavourServerCallback (www));
	}

	IEnumerator FlavourServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			List<SeralizedClassServer.SearchDrinkListOfRecipes> categoryList = new List<SeralizedClassServer.SearchDrinkListOfRecipes> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.SearchDrinkListOfRecipes>> (temp);

			//Debug.Log (JsonConvert.SerializeObject (newCategory));
			DisplayFlavourBrands (categoryList);
		}
	}

	void DisplayFlavourBrands(List<SeralizedClassServer.SearchDrinkListOfRecipes> collectionBrandList)
	{
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.SearchDrinkListOfRecipes brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(FlavourReceipePrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (flavourScrollTrandform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<SearchDrinkBrand> ().InitBrand (brand);
			count++;
		}
	}


}
