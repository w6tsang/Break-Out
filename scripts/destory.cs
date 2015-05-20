using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class destory : MonoBehaviour {
	public float lives= 3;
	// Use this for initialization
	void Start () {
		lives = 3;
		GameObject.Find("Paddle").GetComponent<paddlescript>().SpawnBall(); 
		GameObject.Find("lives").GetComponent<Text>().text = "Lives: "+ lives;
	
	}
	
	// Update is called once per frameß
	void Update () {

		GameObject.Find("lives").GetComponent<Text>().text = "Lives: "+ lives;
		if (lives <= 0) {
			Application.LoadLevel("GameOver");
		}
	}

	void OnTriggerEnter(Collider other){
		Destroy (other.gameObject);
		GameObject.Find("Paddle").GetComponent<paddlescript>().SpawnBall(); 
		lives--;
	}
}
