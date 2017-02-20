using UnityEngine;
using System.Collections;

namespace Q.Utils
{
	public class QDebug
	{
		#if UNITY_EDITOR
		private static bool canDebug = true;
		#else
		private static bool canDebug = false;
		#endif

		public static void Log (object message)
		{
			if (canDebug)
				Debug.Log (message);
		}

		public static void LogError (object message)
		{
			if (canDebug)
				Debug.LogError (message);
		}

		public static void LogWarning (object message)
		{
			if (canDebug)
				Debug.LogWarning (message);
		}

		public static void LogRed (object message)
		{
			if (canDebug) {
				message = "<color=red>" + message + "</color>";
				Debug.Log (message);
			}
		}

		public static void LogBlue (object message)
		{
			if (canDebug) {
				message = "<color=blue>" + message + "</color>";
				Debug.Log (message);
			}
		}

		public static void LogCyan (object message)
		{
			if (canDebug) {
				message = "<color=cyan>" + message + "</color>";
				Debug.Log (message);
			}
		}

		public static void LogGreen (object message)
		{
			if (canDebug) {
				message = "<color=green>" + message + "</color>";
				Debug.Log (message);
			}
		}

		public static void LogGray (object message)
		{
			if (canDebug) {
				message = "<color=gray>" + message + "</color>";
				Debug.Log (message);
			}
		}
	}
}
	