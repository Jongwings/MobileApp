using UnityEngine;
using System.Collections;
using System.IO;

public class References : MonoBehaviour {

	public Sprite[] avatars;
    public Sprite[] localBadges;
	public Sprite[] highQualityImage;
	public Sprite timeBarSingle;
	public Sprite timeBarDual;

	#if UNITY_EDITOR
	public string colorHashCode;
	public Color colorPicked;
	#endif

	public Texture2D[] GetAllAvatar ()
	{
		Texture2D[] _avatarsTexture = new Texture2D[avatars.Length];

		for (int i=0; i<avatars.Length; i++)
		{
			_avatarsTexture [i] = avatars [i].texture;
		}

		return _avatarsTexture;
	}

	public Texture2D GetAvatarImage (int avatartype)
	{
		int avatar = avatartype - 1;
		if (avatar < 0) {
			avatar = 0;
		}
		return avatars [avatartype].texture;
	}

	/*public SportsQuizManager.Badges GetBadge (int id)
    {
        if (localBadges == null)
            return null;

        BadgesManager.eBadges _badgeType = (BadgesManager.eBadges)id;
        for (int i = 0; i < localBadges.Length; i++)
        {
            if (localBadges[i].name == _badgeType.ToString())
            {
                SportsQuizManager.Badges badge = new SportsQuizManager.Badges();
                badge.id = id;
                badge.badge = localBadges[i].texture;
				badge.title = BadgesManager.GetBadgeDescription (_badgeType).title;
				badge.description = BadgesManager.GetBadgeDescription (_badgeType).description;
//				badge.url = BadgesManager.GetBadgeDescription (_badgeType).;

                return badge;
            }
        }

        return null;
    }*/

	public enum eImageType
	{
		Badges,
		Category
	}

	public static void SaveImageToLocal (int id, string url, Texture2D texture, eImageType type)
	{
		string directory_path = Application.persistentDataPath;

		directory_path = directory_path + "/" + type.ToString ();

		if (Directory.Exists(directory_path) == false) {
			Directory.CreateDirectory (directory_path);
		}

		string file_name = Path.GetFileName (url);

		//DELETE OLD FORMAT
		string _temp_old_file = directory_path + "/" + id.ToString () + ".png";
		if (File.Exists(_temp_old_file)) {
			File.Delete (_temp_old_file);
		}

		string new_directory = directory_path + "/" + id.ToString ();
		string file_path = new_directory + "/" + file_name;

		if (Directory.Exists(new_directory) == false) {
			Directory.CreateDirectory (new_directory);
		} else {
			string[] contain_files = Directory.GetFiles (new_directory, "*.png");

			for (int i = 0; i < contain_files.Length; i++) {
				if (contain_files[i] != file_name) {
					File.Delete (contain_files [i]);
				}
			}
		}

		if (File.Exists (file_path) == false) {
			File.WriteAllBytes (file_path, texture.EncodeToPNG ());
			Q.Utils.QDebug.Log (file_path);
		}
	}

	public static Texture2D GetImageFromLocal (int id, string url, eImageType type)
	{
		Texture2D tex = null;
		byte[] fileData;

		string directory_path = Application.persistentDataPath + "/" + type.ToString ();
		string file_name = Path.GetFileName (url);
		string file_path = directory_path + "/" + id.ToString () + "/" + file_name;

		if (Directory.Exists (directory_path + "/" + id.ToString ())) {
			string[] contain_files = Directory.GetFiles (directory_path + "/" + id.ToString (), "*.png");
			
			for (int i = 0; i < contain_files.Length; i++) {
				if (Path.GetFileName (contain_files [i]) != file_name) {
					File.Delete (contain_files [i]);
				}
			}
		}

		if (File.Exists(file_path)) {
			fileData = File.ReadAllBytes(file_path);
			tex = new Texture2D(1, 1);
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}

	public static void RemoveAllLocalTextureData ()
	{
		foreach (eImageType dirType in System.Enum.GetValues (typeof (eImageType))) {
			
			string _mainDirectoryPath = Application.persistentDataPath + "/" + dirType.ToString ();
			string[] _allDirectory = Directory.GetDirectories (_mainDirectoryPath);

			for (int i = 0; i < _allDirectory.Length; i++) {
				string[] _containFiles = Directory.GetFiles (_allDirectory [i], "*.png");
				for (int j = 0; j < _containFiles.Length; j++) {
					File.Delete (_containFiles [j]);
				}
			}
		}
	}

	#if UNITY_EDITOR
	void OnDrawGizmosSelected()
	{
		if (string.IsNullOrEmpty (colorHashCode))
			return;

		colorPicked = Q.Utils.CommonUtils.HexToColor (colorHashCode);
	}
	#endif

	public Sprite GetSprite (int fileID)
	{
		for (int i = 0; i < highQualityImage.Length; i++) {
			Q.Utils.QDebug.Log (highQualityImage [i].GetInstanceID ());
			if (highQualityImage[i].GetInstanceID () == fileID) {
				return highQualityImage [i];
			}
		}
		return null;
	}
}
