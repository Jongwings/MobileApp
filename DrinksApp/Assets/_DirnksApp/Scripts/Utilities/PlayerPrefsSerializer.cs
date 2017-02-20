using UnityEngine;
using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Q.Utils
{
	public class PlayerPrefsSerializer
	{
		public static BinaryFormatter binary_fromat = new BinaryFormatter();
		
		// serializableObject is any struct or class marked with [Serializable]
		public static void SaveData (string prefKey, object serializableObject)
		{
			MemoryStream memoryStream = new MemoryStream ();
			binary_fromat.Serialize (memoryStream, serializableObject);
			string tmp = System.Convert.ToBase64String (memoryStream.ToArray ());
			PlayerPrefs.SetString ( prefKey, tmp);
		}
		
		public static object LoadData<T> (string prefKey)
		{
			if (!PlayerPrefs.HasKey(prefKey))
				return default(T);
			
			string serializedData = PlayerPrefs.GetString(prefKey);
			MemoryStream dataStream = new MemoryStream(System.Convert.FromBase64String(serializedData));
			
			T deserializedObject = (T)binary_fromat.Deserialize(dataStream);
			
			return deserializedObject;
		}
		
	}
}
