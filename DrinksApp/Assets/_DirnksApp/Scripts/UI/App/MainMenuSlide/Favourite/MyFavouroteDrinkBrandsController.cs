using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.UI;
using Q.Utils;

public class MyFavouroteDrinkBrandsController : MonoBehaviour {



	public GameObject collectionBrandPrefab;

	public Transform collectionBrandScrollTransform;



	// Use this for initialization
	void Start () {
		CollectionsAPICalls ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CollectionsAPICalls()
	{
		Debug.Log("User id");
		string url = "http://www.jongwings.com/chivita/app/favourite-recipe.php?";

		Debug.Log(AppManager.Instance.UserId);

		//string url = AppServerConstants.BaseURL+AppServerConstants.FAVOURITE_Recipe;

		WWWForm wwwForm = new WWWForm ();
		wwwForm.AddField ("user_id", AppManager.Instance.UserId);
		Debug.Log(url);
		//		wwwForm.AddField ("user_name", "daniel");
		//		wwwForm.AddField ("password", "test123");
		WWW www = new WWW (url, wwwForm);
		StartCoroutine (CollectionServerCallback (www));
	}

	IEnumerator CollectionServerCallback (WWW www)
	{
		yield return www;
		if (www.error == null) {
			Debug.Log (www.text);
			string temp = www.text;
			bool isHaveRecord = false ;
			List<SeralizedClassServer.MyFavouriteRecipes> categoryList = new List<SeralizedClassServer.MyFavouriteRecipes> ();
			categoryList = JsonConvert.DeserializeObject<List<SeralizedClassServer.MyFavouriteRecipes>> (temp);
			foreach(SeralizedClassServer.MyFavouriteRecipes brand in categoryList)
			{
				if(brand.recipes_name == null)
				{
					AppManager.Instance.ShowMessage("No Records Found",PopUpMessage.eMessageType.Error);
					isHaveRecord = false;
					break;
				}
				else
					isHaveRecord = true;
			}
			if(isHaveRecord == true)
				DisplayCollectionBrands (categoryList);
		}
	}

	void DisplayCollectionBrands(List<SeralizedClassServer.MyFavouriteRecipes> collectionBrandList)
	{
		if(collectionBrandList.Count > 0)
		{
			clearGrid();
			GameObject[] collectionBrandGameObject = new GameObject[collectionBrandList.Count];
			int count = 0;
			foreach(SeralizedClassServer.MyFavouriteRecipes brand in collectionBrandList)
			{
				collectionBrandGameObject[count] = Instantiate(collectionBrandPrefab,  Vector3.zero, Quaternion.identity) as GameObject;
				collectionBrandGameObject [count].transform.SetParent (collectionBrandScrollTransform.transform, false);
				collectionBrandGameObject [count].transform.GetComponent<MyFavouriteDrinkBrand> ().InitBrand (brand);
				count++;
			}
		}
	}

	void clearGrid()
	{
		foreach (Transform item in collectionBrandScrollTransform.transform)
		{
			if (item != null)
			{
				Destroy(item.gameObject);
			}
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
