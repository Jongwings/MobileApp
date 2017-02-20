using System;
//using Assets.Scripts.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts.Helpers
{
    public static class UnityObjectHelper
    {
        public static T GetObject<T>(string fieldName, bool logErrorIfMissing = true) where T : Object
        {
            var gameObject = GetObject(fieldName, logErrorIfMissing);
            if (gameObject != null)
            {
                return gameObject.ToComponent<T>(logErrorIfMissing);
            }

            return default(T);
        }

        public static GameObject GetObject(string fieldName, bool logErrorIfMissing = true)
        {
            var gameObject = GameObject.Find(fieldName);

            if (gameObject != null)
            {
                return gameObject;
            }

            if (logErrorIfMissing)
            {
				//Debug.LogError(string.Format("Could not find game object: {0}", fieldName));
				Debug.LogError ("Could not cast game object: {0} to component type: {1}" + fieldName);

            }

            return null;
        }

        public static T ToComponent<T>(this GameObject gameObject, bool logErrorIfMissing = true) where T : Object
        {
            if (gameObject == null)
            {
                throw new ArgumentException("gameObject");
            }

            var result = gameObject.GetComponent<T>();

            if (result != null)
            {
                return result;
            }

            if (logErrorIfMissing)
            {
				Debug.LogError ("Could not cast game object: {0} to component type: {1}" + gameObject.name);
				//Debug.LogError(string.Format("Could not cast game object: {0} to component type: {1}", gameObject.name, typeof (T)));
            }

            return default(T);
        }
    }
}