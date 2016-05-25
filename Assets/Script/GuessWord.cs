using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class GuessWord : MonoBehaviour {
	public string m_SecretWord;
	public int m_GuessTimeMax;
	public int m_GuessTime = 0;
	public TextManager m_TextManager;

	private List<string> m_LetterGuessed = new List<string>();

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TryWord (string inputText)
	{
		string guessWord = inputText.ToLower ();

		//Check input text is legal
		if (guessWord.Length != 1 || !IsGuessWordLegal (guessWord)) {
			m_TextManager.SystemTextUpdate ("Oops! Please enter one letter.");
			return;
		}

		//Check the inputtext guessed or not
		if (m_LetterGuessed.Contains (guessWord)) {
			m_TextManager.SystemTextUpdate ("Oops! You have already guessed the letter: " + guessWord);
			return;
		}

		// Add the new letter to guessword list and update the Text. 
		else {
			m_LetterGuessed.Add(guessWord);
			m_TextManager.ShowGuessedText(CompareGuessWord());
		}

		//Check the letter is in secretword
		if (m_SecretWord.Contains(guessWord)){
			m_TextManager.SystemTextUpdate ("Good guess! " + guessWord);

			//Check player guess the whole word;
			if (IsGuessRight(m_SecretWord)){
				m_TextManager.SystemTextUpdate("-------------");
				m_TextManager.SystemTextUpdate("You won!");
			}
			return;
		}

		//Player use one guess coin.
		m_TextManager.SystemTextUpdate("Oops! The letter is not in my word: "+ guessWord);
		m_GuessTime++;

		//Player uses all guess coins;
		if (m_GuessTime == m_GuessTimeMax){
			m_TextManager.SystemTextUpdate ("Sorry, you ran out of guesses. The word is "+m_SecretWord);
		}

	}

	private bool IsGuessWordLegal (string inputText) 
	{
		string allLetters = "abcdefghijklmnopqrstuvwxyz";
		return (allLetters.Contains(inputText));
	}

	private bool IsGuessRight (string secretWord)
	{
		int rightValue = 0;

		foreach (char letter in secretWord) {
			if (m_LetterGuessed.Contains(letter.ToString())) {
				rightValue++;
			}
		}

		return (rightValue == secretWord.Length);
	}

	private string CompareGuessWord ()
	{
		string result = "";

		foreach (char letter in m_SecretWord) {
			if (m_LetterGuessed.Contains (letter.ToString ())) {
				result += letter.ToString ();
			} else {
				result +="_ ";
			}
		}

		return result;
	}

	public void Reset(){// Reset the guessed word text;
		m_TextManager.ShowGuessedText(CompareGuessWord());
	}
}
