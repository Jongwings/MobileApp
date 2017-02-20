using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Q.Utils
{
	public static class TransformUtils
	{
		public static void SetVector2X (this UnityEngine.Vector2 vector2, float xVal)
		{
			vector2 = new Vector2 (xVal, vector2.y);
			Debug.Log (vector2);
		}

		public static void SetVector2Y (this UnityEngine.Vector2 vector2, float yVal)
		{
			vector2 = new Vector2 (vector2.x, yVal);
		}

		public static void AllignRectTransformDeltaSize (GameObject gObj, Texture2D texture)
		{
			RectTransform _rect = gObj.GetComponent<RectTransform> ();

			float _ratio = (float)texture.width / (float)texture.height;
			float _width = _rect.sizeDelta.y * _ratio;

			_rect.sizeDelta = new Vector2 (_width, _rect.sizeDelta.y);
		}

		public static void RectTransformMakeChild (this UnityEngine.GameObject rectTransform, Transform parent, bool asFirstSibling = false)
		{
			RectTransform _recttransform = rectTransform.GetComponent<RectTransform> ();

			_recttransform.SetParent (parent, false);
			if (asFirstSibling)
				_recttransform.SetAsFirstSibling ();

			_recttransform.localScale = new Vector3 (1f, 1f, 1f);

			rectTransform.SetActive (true);
		}

		public static void RectTransformCopyComponent (this UnityEngine.RectTransform destRect, RectTransform sourceRect)
		{
			destRect.anchoredPosition = sourceRect.anchoredPosition;
			destRect.sizeDelta = sourceRect.sizeDelta;
		}

		public static void RectTransformChildSetLocal (Transform transform, Transform parent)
		{
			RectTransform rectTransform = transform.GetComponent<RectTransform> ();

			rectTransform.transform.SetParent (parent);

			rectTransform.anchoredPosition = new Vector2 (0, 0);
			rectTransform.sizeDelta = new Vector2 (0, 0);

			rectTransform.gameObject.SetActive (true);
		}

		public static Image GetLockImage (GameObject gObj)
		{
			Image[] childrens = gObj.GetComponentsInChildren<Image> ();

			for (int i = 0; i < childrens.Length; i++) {
				if (childrens[i].transform.name == "Lock") {
					return childrens [i];
				}
			}

			return null;
		}
	}
}
