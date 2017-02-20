using UnityEngine;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Q.Utils
{
	public static class Country
	{
		[Serializable]
		public class CountryCode
		{
			public string iso_code_2;
			public string country_name;
			public string offical_name;
			public string iso_code_3;
			public int iso_numeric_code;
		}

		public static List<CountryCode> countryCodeList;
		public static List<CountryCode> copyOfCountryCodeList;
		public static List<CountryCode> specificCountryCodeList;

		public static List<CountryCode> GetAllCountry ()
		{
			GetCoutryListFromDatabase ();
			copyOfCountryCodeList = new List<CountryCode> (countryCodeList);
			return countryCodeList;
		}

		public static string GetCountryName (int countryCode)
		{
			GetCoutryListFromDatabase ();

			for (int i = 0; i < countryCodeList.Count; i++) {
				if (countryCodeList [i].iso_numeric_code == countryCode) {
					return countryCodeList[i].country_name;
				}
			} 
			return "";
		}

		public static int GetCountryCode (string countryName)
		{
			GetCoutryListFromDatabase ();

			for (int i = 0; i < countryCodeList.Count; i++) {
				if (countryCodeList [i].country_name == countryName) {
					return countryCodeList[i].iso_numeric_code;
				}
			} 
			return 0;
		}

		public static int GetCountryCodeByISO (string countryISO)
		{
			GetCoutryListFromDatabase ();

			for (int i = 0; i < countryCodeList.Count; i++) {
				if (countryCodeList [i].iso_code_2 == countryISO) {
					return countryCodeList[i].iso_numeric_code;
				}
			} 
			return 0;
		}

		static void GetCoutryListFromDatabase ()
		{
			if (countryCodeList == null || countryCodeList.Count == 0) {

				TextAsset _textAssets = (TextAsset)Resources.Load ("LocalDatabase/CoutryCode");
				countryCodeList = JsonConvert.DeserializeObject<List<CountryCode>> (_textAssets.text);
			}
		}

		public static List<CountryCode> GetSpecificCountryList (string str)
		{
			specificCountryCodeList = new List<CountryCode> ();
			if (countryCodeList != null) {
				for (int i = 0; i < copyOfCountryCodeList.Count; i++) {
					if (copyOfCountryCodeList [i].country_name.Length >= str.Length) {
						if (copyOfCountryCodeList [i].country_name.Substring (0, str.Length).ToLower().Equals (str.ToLower())) {
							specificCountryCodeList.Add (copyOfCountryCodeList [i]);
						}
					} else {
						if (copyOfCountryCodeList [i].country_name.Substring (0, copyOfCountryCodeList [i].country_name.ToLower().Length).Equals (str.ToLower())) {
							specificCountryCodeList.Add (copyOfCountryCodeList [i]);
						}
					}
				}
			}
			return specificCountryCodeList;
		}
	}
}
