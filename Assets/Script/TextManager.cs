using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	public Text m_GuessedText;
	public Text m_SystemText;
	public Text m_GuessCoinsText;
	public Text m_ShowSecretWordText;
	public InputField m_InputText;
	//[HideInInspector]public string m_GuessedWord; 

	// Use this for initialization
	void Start () {
		m_SystemText.text = "Welcome to Hang Man.";
	}


	public void SystemTextUpdate (string text)
	{
		m_SystemText.text = text;
	}

	public void ShowGuessedText (string guessWord)
	{
		m_GuessedText.text = guessWord;
	}

	public void GuessTimeUpdate (string guessTimeLeft)
	{
		m_GuessCoinsText.text = guessTimeLeft;
	}

	public void ShowSecretWord (string secretWrod)
	{
		m_ShowSecretWordText.text = secretWrod;
	}

	public void Reset ()
	{
		m_InputText.text = "";
		m_SystemText.text = "Welcome to Hang Man.";
	}
}
