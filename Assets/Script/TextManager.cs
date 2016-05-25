using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public Text m_GuessedText;
	public Text m_SystemText;
	//[HideInInspector]public string m_GuessedWord; 

	// Use this for initialization
	void Start () {
		m_SystemText.text = "Welcome to Hang Man.";
	}
	
	// Update is called once per frame
	void Update () {
		//ShowGuessedText();
	}

	public void SystemTextUpdate (string text)
	{
		m_SystemText.text = text;
	}

	public void ShowGuessedText (string guessWord)
	{
		m_GuessedText.text = guessWord;
	}
}
