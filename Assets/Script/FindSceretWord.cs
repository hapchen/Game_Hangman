using UnityEngine;
using System.Collections;

public class FindSceretWord : MonoBehaviour {
	public TextAsset m_TextAsset;
	public GuessWord m_GuessWord;
	/*[HideInInspector]*/public string m_SecretWord; 

	private string[] m_TextStringList;

//	// Use this for initialization
//	void Start () {
//		Reset();
//		m_GuessWord = GetComponent<GuessWord>();
//		m_GuessWord.m_SecretWord = m_SecretWord;
//	}
//
	private string[] LoadWord ()
	{
		string[] textList;
		textList = m_TextAsset.ToString().Split(' ');

		return textList;
	}

	private string ChooseWords(string[] textList){
		int i = Random.Range(0,textList.Length);
		return textList[i];
	}

	public void Reset ()
	{
		m_TextStringList = LoadWord();
		m_SecretWord = ChooseWords(m_TextStringList);
	}
}
