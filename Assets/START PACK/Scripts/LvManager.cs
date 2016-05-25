using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LvManager : MonoBehaviour {
    public int maxGameLevel;
    public bool isAutoLoadLevel;
    public float afterSecondsLoad;

    private int currentLevel; 
    private static int gameLevelIndex=1;
    private static int previousScene;

    void Start ()
	{
		if (isAutoLoadLevel) {
			Invoke ("JustNextLv", afterSecondsLoad);
		}
    }

	public void LvLoader (string name){
        previousScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(name);
	}

    public void PlayAgain()
    {
        SceneManager.LoadScene(previousScene);
    }

//	public void LvLoader_quit (string name){
//		SceneManager.LoadScene(name);
//	}

    public void LoadNextLv()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (gameLevelIndex == maxGameLevel)
        {
            gameLevelIndex =1;
            SceneManager.LoadScene("Win");
        }else{
           gameLevelIndex++;
           SceneManager.LoadScene(currentLevel + 1);
        }
    }

    private void JustNextLv ()
	{
		currentLevel = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentLevel + 1);
	}

	public void LoadLooseSence ()
	{
		LvLoader("03b Lose");
	}

	public  void LoadSurivalScene ()
	{
		LvLoader("02 Level_up");
	}

	}

    // Remember reset the max level in prefab;