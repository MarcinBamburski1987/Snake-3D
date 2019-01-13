using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScorePoints : MonoBehaviour {
	
	public static int score=0;
	public static int highScore=0;
	Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	void Awake(){
		text = GetComponent<Text>();
		score=0;
		highScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Punkty: " + score + "\nNajlepszy wynik: "+ highScore;
	}
}
