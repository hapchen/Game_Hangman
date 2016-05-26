using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
public TextManager m_TextManager;
public GuessWord m_GuessWord;
public FindSceretWord m_FindSceretWord;
public float m_StartDelay = 3f;
public float m_EndDelay = 3f;
public int m_GuessTimeMax = 8;
public GameObject m_RoundPlayingUI;
public GameObject m_RoundStartingUI;
public GameObject m_RoundEndingUI;

private int m_RoundTime = 0;
private WaitForSeconds m_StartWait;
private WaitForSeconds m_EndWait;

	// Use this for initialization
	void Start () {
		m_FindSceretWord.Reset();

		m_StartWait = new WaitForSeconds(m_StartDelay);
		m_EndWait = new WaitForSeconds(m_EndDelay);

		StartCoroutine(GameLoop());
	}

	private IEnumerator GameLoop(){
		yield return StartCoroutine(RoundStarting());
		yield return StartCoroutine(RoundPlaying());
		yield return StartCoroutine(RoundEnding());

		StartCoroutine(GameLoop());// TODO: Set round number condition.
	}

	private IEnumerator RoundStarting ()
	{
		ResetAll();

		DisableControl();

		m_RoundStartingUI.SetActive(true);

		m_RoundTime++;

		yield return m_StartWait;
	}

	private IEnumerator RoundPlaying ()
	{
	    EnableControl();
	
		while (m_GuessWord.GetGuessCoinsLeft () != 0 && !m_GuessWord.m_IsPlayerWin) {
			yield return null;
		}

		yield return m_StartWait;
	}

	private IEnumerator RoundEnding ()
	{
		DisableControl ();

		m_RoundEndingUI.SetActive(true);

		//TODO: When play certain rounds we can get level up
		if (m_RoundTime == 5) {
			//Level Up!
		}

		m_TextManager.ShowSecretWord(m_FindSceretWord.m_SecretWord);

		yield return m_EndWait;
	}

	private void ResetAll ()
	{
		m_FindSceretWord.Reset();
		m_GuessWord.m_SecretWord = m_FindSceretWord.m_SecretWord;
		m_GuessWord.Reset();
		m_TextManager.Reset();

		m_GuessWord.m_GuessTimeMax =  m_GuessTimeMax;

		m_RoundStartingUI.SetActive(false);
		m_RoundEndingUI.SetActive(false);
	}

	private void DisableControl ()
	{
		m_RoundPlayingUI.SetActive(false);
	}

	private void EnableControl ()
	{
		m_RoundPlayingUI.SetActive(true);
		m_RoundStartingUI.SetActive(false);
		m_RoundEndingUI.SetActive(false);
	}
}
