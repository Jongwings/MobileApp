using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using Q.Utils;

public class KYDBrandsController : MonoBehaviour {

	public class CollectionDictionary
	{
		public List<SeralizedClassServer.CollectionBrand> categoryList = new List<SeralizedClassServer.CollectionBrand> ();
	}

	public GameObject collectionBrandPrefab;

	public Transform collectionBrandScrollTransform;


	// Use this for initialization
	void Start () {
		if(AppManager.Instance.isInternetAvailable)
			CollectionsAPICalls ();
		else
		{
			AppManager.Instance.ReadFileOfflineBrandDetails();
			this.DisplayCollectionBrands1(AppManager.Instance.offlineBrandDetails);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CollectionsAPICalls()
	{
		string url = AppServerConstants.BaseURL+AppServerConstants.LIST_BRAND;

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
			List<SeralizedClassServer.KYDBrand> categoryList = new List<SeralizedClassServer.KYDBrand> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.KYDBrand>> (temp);

			//Debug.Log (JsonConvert.SerializeObject (newCategory));
			DisplayCollectionBrands (categoryList);
		}
	}

	void DisplayCollectionBrands(List<SeralizedClassServer.KYDBrand> collectionBrandList)
	{
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.KYDBrand brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionBrandPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionBrandScrollTransform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<KYDBrand> ().InitBrand (brand);
			count++;
		}
	}

	void DisplayCollectionBrands1(List<SeralizedClassServer.OfflineBradDetails> collectionBrandList)
	{
		GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
		int count = 0;
		foreach(SeralizedClassServer.OfflineBradDetails brand in collectionBrandList)
		{
			collectionBrandGameObject[count] = Instantiate(collectionBrandPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
			collectionBrandGameObject [count].transform.SetParent (collectionBrandScrollTransform.transform, false);
			collectionBrandGameObject [count].transform.GetComponent<KYDBrand> ().InitBrand1 (brand,count);
			count++;
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


}
