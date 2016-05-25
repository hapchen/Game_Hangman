using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionController : MonoBehaviour {

	public Slider volumeSlider;
	public Slider difficultySlider;

	float defultMusicVolume = 1f;
	float defultDifficulty = 1f;
	private MusicManager musicManager;
	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicManager>();
		volumeSlider.value = PlayerPresfsManager.GetMasterVolume();
		difficultySlider.value = PlayerPresfsManager.GetDifficulty();
	}
	
	// Update is called once per frame
	void Update () {
		musicManager.SetMusicVolume(volumeSlider.value);
	}

	public void Save(){
		PlayerPresfsManager.SetMasterVolume(volumeSlider.value);
		PlayerPresfsManager.SetDifficulty(difficultySlider.value);
	}

	public void Defult ()
	{
		PlayerPresfsManager.SetMasterVolume(defultMusicVolume);
		volumeSlider.value = defultMusicVolume;
		PlayerPresfsManager.SetDifficulty(defultDifficulty);
		difficultySlider.value = defultDifficulty;
	}
}
