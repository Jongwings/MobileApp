using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Q.Utils
{
	public static class CommonUtils
	{

		/// <summary>
		/// Custom made: Insert sprite into image.
		/// </summary>
		/// <param name="this Image">This image.</param>
		/// <param name="Texture2D">Texture.</param>
		public static void CreateImageSprite (this UnityEngine.UI.Image thisImage, Texture2D _texture)
		{
			if (thisImage == null)
				return;

			if (_texture == null)
				return;

			thisImage.preserveAspect = true;

			thisImage.sprite = 
				Sprite.Create (
					_texture, 
					new Rect (0, 0, (float)_texture.width,
						(float)_texture.height),
					new Vector2 (0, 0),
					1f);
		}

		/// <summary>
		/// Change only the alpha of color
		/// </summary>
		/// <returns>Color.</returns>
		/// <param name="color">Color.</param>
		/// <param name="APlha">Float.</param>
		public static void ColorAlpha (this UnityEngine.Color color, float alpha)
		{
			Color _tempColor = color;
			_tempColor.a = alpha;
			color = _tempColor;
		}

		public static Dictionary<int, string> ReadDictionaryFromFile ( TextAsset textAsset )
		{
			Dictionary<int, string> dictionary = new Dictionary<int, string>();

			string replaceString = textAsset.text.Replace("\r\n", "\n");
			string[] lines = replaceString.Split ("\n" [0]);

			foreach (string line in lines) 
			{
				if (string.IsNullOrEmpty( line)  == false &&
					line.StartsWith(";") == false &&
					line.StartsWith("#") == false &&
					line.StartsWith("'") == false &&
					line.Contains("=") == true 
				)
				{
					object[] keyvalue = line.Split('=');
					Q.Utils.QDebug.Log ( keyvalue != null && keyvalue.Length == 2 );
					Q.Utils.QDebug.Log ( dictionary.ContainsKey((int)keyvalue[1] ) == false );

					dictionary[(int)keyvalue[1]] = (string)keyvalue[0];
				}
			}
			return dictionary;
		}

		//Suffle the list
		public static void Shuffle<T>(this IList<T> list) {
			int n = list.Count;
			System.Random rnd = new System.Random();
			while (n > 1) {
				int k = (rnd.Next(0, n) % n);
				n--;
				T value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}

		// Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.
		public static string ColorToHex(Color32 color)
		{
			string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
			return hex;
		}

		public static Color HexToColor(string hex)
		{
			hex = hex.Replace ("#", "");
			byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r,g,b, 255);
		}

		public static string Md5Sum(string strToEncrypt)
		{
			System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
			byte[] bytes = ue.GetBytes(strToEncrypt);

			// encrypt bytes
			System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
			byte[] hashBytes = md5.ComputeHash(bytes);

			// Convert the encrypted bytes back to a string (base 16)
			string hashString = "";

			for (int i = 0; i < hashBytes.Length; i++)
			{
				hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
			}

			return hashString.PadLeft(32, '0');
		}
	}
}
