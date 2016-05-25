using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
//I find out the onLevelWasLoaded method only call after new level adding. So I have to add a audiosource in 00 scene indepentently.	
	public AudioClip[] levelMusicChangeArray;
	private AudioSource music;

	void Awake ()
	{
		DontDestroyOnLoad(gameObject);
	}
	// Use this for initialization
	void Start ()
	{
			music = GetComponent<AudioSource> ();
	}

	void OnLevelWasLoaded (int level)
	{
		SetMusicVolume(PlayerPresfsManager.GetMasterVolume());
		AudioClip thisLevelMusic = levelMusicChangeArray [level];
		if (thisLevelMusic) {
			music.Stop();
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play();
		}

	}

	public void SetMusicVolume (float volume)
	{
		music.volume = volume;
	}


}

