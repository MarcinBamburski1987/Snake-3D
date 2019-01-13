using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.SceneManagement;

/*BB*/
using System.IO;
using System;


public class BasicMove : MonoBehaviour {

	public static float speed = 2f;
	public float rotationSpeed = 100f;
	public int initialSize = 3;
	public List<Transform> bodyParts = new List<Transform>();
	public Transform bodyObject;
	public int points=10;

	public void speedChange(float snakeSpeed){
		speed = snakeSpeed;
	}
	public void rotationChange(float snakeRot){
		rotationSpeed = snakeRot;
	}


	// Use this for initialization
	void Start () {
		ScorePoints.highScore=PlayerPrefs.GetInt ("highscore");
		points=(int)(points*speed*(100f/rotationSpeed));
		Vector3 currentpos = transform.position;
		Transform newBodyPart = Instantiate(bodyObject, currentpos, Quaternion.identity) as Transform;
		bodyParts.Add(newBodyPart);
		for(int i=1;i<initialSize;i++)addTail();

	}

	// Update is called once per frame
	void Update () {
		movement();
		if (Input.GetKey("escape"))
			Application.Quit();
	}

	void movement()
	{
		
		transform.Rotate(Input.GetAxis("Horizontal") *rotationSpeed * Time.deltaTime, 0, 0);
		transform.Translate(Vector3.forward *speed* Time.deltaTime);

	}
	void addTail(){
		Vector3 currentPos = bodyParts[bodyParts.Count - 1].position;
		Transform newBodyPart = Instantiate(bodyObject, currentPos, Quaternion.identity) as Transform;
		bodyParts.Add(newBodyPart);

	}
	void gameOver(){
		if(ScorePoints.score>ScorePoints.highScore)
		PlayerPrefs.SetInt("highscore", ScorePoints.score);
		Application.LoadLevel (Application.loadedLevelName);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Food")
		{
			other.gameObject.SetActive (false);
			Destroy (other.gameObject);
			addTail();
			ScorePoints.score += points;
		}
		if(other.transform.tag == "BigFood")
		{
			addTail();
			addTail();
			other.gameObject.SetActive (false);
			Destroy (other.gameObject);
			ScorePoints.score += points+points;
		}
		if(other.transform.tag == "Tail" || other.transform.tag == "Bound"){
			
			if (bodyParts.Count > initialSize)
				gameOver ();
		}

	}

}