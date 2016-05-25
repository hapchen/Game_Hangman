using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPresfsManager : MonoBehaviour {
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_UNLOCKED_KEY = "level_unlocked_";

	public static void SetMasterVolume (float volume)
	{
		if (volume <= 1f && volume >= 0f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Master volume is out of range.");
		}
	}

	public static float GetMasterVolume ()
	{
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void SetLevelUnlocked (int level)
	{
		if (level<= SceneManager.sceneCountInBuildSettings -1) {
			PlayerPrefs.SetInt (LEVEL_UNLOCKED_KEY+level.ToString(), 1);// 1 means true;
		} else {
			Debug.LogError("Level "+level+" is not in build setting list.");
		}
	}

	public static bool GetLevelUnlocked (int level)
	{
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			if (PlayerPrefs.GetInt (LEVEL_UNLOCKED_KEY + level.ToString()) == 1) {
				return true;
			} else {
				Debug.LogError ("Level " + level + " is locked.");
				return false;
			}
		} else {
			Debug.LogError("Level "+level+" is not in build setting list.");
			return false;
		}
	}

	public static void SetDifficulty (float volume)
	{
		if (volume <= 3f && volume >= 1f) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, volume);
		} else {
			Debug.LogError("Difficulty volume is out of range.");
		}
	}

	public static float GetDifficulty ()
	{
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}

}
