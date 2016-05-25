using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {
	public float fadeInTime;
	public bool isBlackFadeIn;
	private Image fadePanel;
	private Color currentColor = Color.white;
	// Use this for initialization
	void Start ()
	{
		fadePanel = GetComponent<Image> ();
		if (isBlackFadeIn) {
			currentColor = Color.black;
		}
		fadePanel.color = currentColor;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float fadeInSpeed = Time.deltaTime / fadeInTime;
			currentColor.a -= fadeInSpeed;
			fadePanel.color = currentColor;
		} else {
			gameObject.SetActive(false);
		}
	}

	void OnMouseDown ()
	{
		gameObject.SetActive(false);
	}
}
