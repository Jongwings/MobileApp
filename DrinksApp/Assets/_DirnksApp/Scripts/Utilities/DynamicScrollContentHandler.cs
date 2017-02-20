using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DynamicScrollContentHandler : MonoBehaviour {

	[SerializeField]private ScrollRect scrollRect;
	[SerializeField]private RectTransform content;
	[SerializeField]private HorizontalLayoutGroup horizontalLayoutGroup;
	[SerializeField]private VerticalLayoutGroup verticalLayoutGroup;
	[SerializeField]private RectTransform contentItem;
	private bool isHorizontal;
	private Vector2 contentDeltaSize;
	private const string itemName = "~MAIN_ITEM";

	void Awake () {
		InitScrollContent ();
	}

	void InitScrollContent () {
		if (scrollRect == null)
			scrollRect = GetComponent<ScrollRect> ();

		content = scrollRect.content;

		contentItem = content.transform.GetChild (0).GetComponent<RectTransform> ();
		contentItem.transform.name = itemName;
		contentItem.gameObject.SetActive (false);

		contentDeltaSize = content.sizeDelta;
		isHorizontal = scrollRect.horizontal;

		if (isHorizontal == true) {
			if (content.GetComponent<HorizontalLayoutGroup> () == null) {
				content.gameObject.AddComponent<HorizontalLayoutGroup> ();
			}
				
			contentItem.pivot = new Vector2 (1f, 0.5f);
			horizontalLayoutGroup = content.GetComponent<HorizontalLayoutGroup> ();
		} else {
			if (content.GetComponent<VerticalLayoutGroup> () == null) {
				content.gameObject.AddComponent<VerticalLayoutGroup> ();
			}

			contentItem.pivot = new Vector2 (0.5f, 1f);
			verticalLayoutGroup = content.GetComponent<VerticalLayoutGroup> ();
		}
	}

	public void SetContentLayout ()
	{
		Vector2 _content_sizeDelta = contentDeltaSize;

		if (isHorizontal) {
			int horGroupCal = horizontalLayoutGroup.padding.left + Mathf.RoundToInt (horizontalLayoutGroup.spacing) * m_contentItemsList.Count;
			int itemWeidthCal = Mathf.RoundToInt (contentItem.sizeDelta.x) * m_contentItemsList.Count;
			_content_sizeDelta.x = horGroupCal + itemWeidthCal;

			if (_content_sizeDelta.x < contentDeltaSize.x) {
				content.sizeDelta = contentDeltaSize;
				return;
			}
				
		} else {
			int vertGroupCal = verticalLayoutGroup.padding.top + Mathf.RoundToInt (verticalLayoutGroup.spacing) * m_contentItemsList.Count;
			int itemHeightCal = Mathf.RoundToInt (contentItem.sizeDelta.y) * m_contentItemsList.Count;
			_content_sizeDelta.y = vertGroupCal + itemHeightCal;

			if (_content_sizeDelta.y < contentDeltaSize.y){
				content.sizeDelta = contentDeltaSize;
				return;
			}
		}

		content.sizeDelta = _content_sizeDelta;
		scrollRect.SetLayoutVertical ();
	}

	// Use this for initialization
	void Start () {
		m_contentItemsList = GetChildComponents<RectTransform> (content.transform);
	}

	[SerializeField] private List<RectTransform> m_contentItemsList = new List<RectTransform> ();
	private int m_totatItemContent = 0;

	// Update is called once per frame
	void Update () {

		if (GetChildComponents<RectTransform>(content.transform).Count != m_contentItemsList.Count) {

			Debug.Log (GetChildComponents<RectTransform> (content.transform).Count +
			":::" + m_contentItemsList.Count);

			m_contentItemsList = new List<RectTransform> ();
			m_contentItemsList = GetChildComponents<RectTransform> (content.transform);

			SetContentLayout ();
		}
	}

	List<T> GetChildComponents <T> (Transform parent)
	{
		List<T> _list = new List<T> ();
		foreach (Transform child in parent) {
			if ((child.name != itemName) &&
				(child.gameObject.activeInHierarchy == true) &&
				child.GetComponent<T>() != null ) {

				_list.Add (child.GetComponent<T>());
			
			}
		}
		return _list;
	}
}
