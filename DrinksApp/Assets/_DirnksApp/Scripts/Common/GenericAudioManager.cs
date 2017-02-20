using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GenericAudioManager : MonoBehaviour
{
    public static GenericAudioManager instance { get; private set; }
    public static ArrayList audioClipsList; 
    public static bool isFX_On = true;
    public static bool isBG_On = true;

	private const string soundsPath = "Sounds/";

    //public GameObject sliderObj;
    private Slider volumeSlider;

    public enum PlayMode
    {
        single = 0,
        loop,
    }

    public enum BGSounds
    {
		BG_Music_Main = 0,
		BG_Music_Gameplay,
    }

    public enum SFXSounds
    {
        Button_Click_1 = 0,
		Badge_Rank_Title_Won,
		Challenge_Screen,  
		levelComplete,
		Clock_Ticking, 
		Correct_Answer,
		Forfeit_Button_Click,
		Match_Lost_Tie,
		Match_Pending,
		Match_Won,
		Wrong_Answer,
    }

    private static List<AudioSource> audioSourcesList;

    void Awake()
    {
        instance = this;
        audioSourcesList = new List<AudioSource>();
        audioClipsList = new ArrayList();
    }

	void OnDestroy ()
	{
		instance = null;
	}

    void Start()
    {
        //sliderObj.SetActive(true);
        //volumeSlider = sliderObj.GetComponent<Slider>();
    }

    public static void PlayBG(BGSounds bgSound, PlayMode playMode = PlayMode.single)
    {
        //Q.Utils.QDebug.Log("bgSound "+ bgSound);
        if (CheckIsBG())
        {
			AudioClip soundClip = Resources.Load<AudioClip>(soundsPath + bgSound.ToString());
            instance.PlaySoundWithCallback(soundClip, playMode);
        }
    }

    public static void PlayFX(SFXSounds fxSound, PlayMode playMode = PlayMode.single)
    {
//        Q.Utils.QDebug.Log("fxSound " + fxSound);
        if (CheckIsSFX())
        {
			AudioClip soundClip = Resources.Load<AudioClip>(soundsPath + fxSound.ToString());
            instance.PlaySoundWithCallback(soundClip, playMode);
        }
    }
    
    public static bool isPlayingBG(BGSounds bgSound)
    {
        foreach (AudioSource audioSource in audioSourcesList)
        {
            if (audioSource.clip.name == bgSound.ToString())
            {
                return true;
            }
        }
        return false;
    }

    public static bool isPlayingFX(SFXSounds fxSound)
    {
        foreach (AudioSource audioSource in audioSourcesList)
        {
            if (audioSource.clip.name == fxSound.ToString())
            {
                return true;
            }
        }
        return false;
    }

    public static void StopAll()
    {
        foreach (AudioSource audioSource in audioSourcesList)
        {
            audioSource.Stop();            
            audioClipsList.Clear();
            Destroy(audioSource);
        }
        audioSourcesList.Clear();
        instance.StopAllCoroutines();
    }

    public static void DontStopThisBG(BGSounds clip)
    {
        for (int i = 0; i < audioSourcesList.Count; i++)
        {
            if (audioSourcesList[i].clip.name == clip.ToString())
            {
                continue;
            }
            else
            {
                audioSourcesList[i].Stop();
                audioClipsList.Remove(audioSourcesList[i].clip);
                Destroy(audioSourcesList[i]);
                audioSourcesList.Remove(audioSourcesList[i]);
                --i;
            }
        }
    }

    public static void DontStopThisFX(SFXSounds clip)
    {
        for (int i = 0; i < audioSourcesList.Count; i++)
        {
            if (audioSourcesList[i].clip.name == clip.ToString())
            {
                continue;
            }
            else
            {
                audioSourcesList[i].Stop();
                audioClipsList.Remove(audioSourcesList[i].clip);
                Destroy(audioSourcesList[i]);
                audioSourcesList.Remove(audioSourcesList[i]);
                --i;
            }
        }        
    }
    
    public static void StopSoundBG(BGSounds clip)
    {
        for (int i= 0; i < audioSourcesList.Count; i++)
        {
            if (audioSourcesList[i].clip.name == clip.ToString())
            {
                audioSourcesList[i].Stop();
                audioClipsList.Remove(audioSourcesList[i].clip);
                Destroy(audioSourcesList[i]);
                audioSourcesList.Remove(audioSourcesList[i]);
            }
        }
    }

    public static void StopSoundFX(SFXSounds clip)
    {
        for (int i = 0; i < audioSourcesList.Count; i++)
        {
            if (audioSourcesList[i].clip.name == clip.ToString())
            {
                audioSourcesList[i].Stop();
                audioClipsList.Remove(audioSourcesList[i].clip);
                Destroy(audioSourcesList[i]);
                audioSourcesList.Remove(audioSourcesList[i]);
            }
        }
    }

    private void PlaySoundWithCallback(AudioClip clip, PlayMode playMode = PlayMode.single)
    {
//        if (audioClipsList.Contains(clip))
//            return;
        AudioSource audioSource = instance.gameObject.AddComponent<AudioSource>();
        //audioSource.volume = volumeSlider.value;
        audioSource.clip = clip;
        audioClipsList.Add(clip);
        audioSource.playOnAwake = false;
        audioSource.PlayOneShot(clip);
        audioSourcesList.Add(audioSource);
        //StartCoroutine(DelayedCallback(audioSource, clip, playMode));
    }

    private IEnumerator DelayedCallback(AudioSource audioSource, AudioClip clip, PlayMode playMode)
    {
//		Q.Utils.QDebug.Log (clip.name + " ::: " + playMode);
        yield return new WaitForSeconds(clip.length);

        switch (playMode)
        {
            case PlayMode.single:
                if (audioSource)
                    audioSource.Stop();
                audioClipsList.Remove(clip);
                audioSourcesList.Remove(audioSource);
                Destroy(audioSource);
                Resources.UnloadAsset(clip);
                break;

            case PlayMode.loop:
                if (audioSource)
                    audioSource.PlayOneShot(clip);
//                else
//                    yield break;
//                StartCoroutine(DelayedCallback(audioSource, clip, playMode));
                yield break;
        }
    }

    public void SetVolume()
    {
        foreach (AudioSource audioSource in audioSourcesList)
        {
//            audioSource.volume = volumeSlider.value;
        }
    }

    private static bool CheckIsBG()
    {
		if (!isBG_On) {
			return false;
		} else {
			return true;
		}
    }

    private static bool CheckIsSFX()
    {
		if (!isFX_On) {
			return false;
		} else {
			return true;
		}
    }
}