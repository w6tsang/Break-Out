using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptBrick : MonoBehaviour {
 
	public int lifePoints = 1;
	public int pointValue = 1;
	public GameObject brick2;
	public GameObject brick;


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnCollisionEnter()
	{
		lifePoints--;

		if (lifePoints == 2) {
			SpawnBrick2();
		}
		if (lifePoints == 1) {
			SpawnBrick();
		}
		Kill ();

	}

	void Kill(){
	
		GameObject.Find ("Paddle").GetComponent<paddlescript> ().AddPoint(pointValue);
		Destroy (gameObject);
		GameObject[] bricks = GameObject.FindGameObjectsWithTag("Blocks");
		Debug.Log (bricks.Length);
		if (bricks.Length-1 == 0) {
			if(Application.loadedLevelName == "Level1"){
				Application.LoadLevel("Level2");
			}
			else{
				Application.LoadLevel("GameOver");
			}
			Debug.Log ("NewLevel");
			GameObject.Find ("Paddle").GetComponent<paddlescript> ().SpawnBall();
		}
	}

	void SpawnBrick2(){
		brick2 = (GameObject)Instantiate (brick2, transform.position, Quaternion.identity);
		
	}
	void SpawnBrick(){
		brick = (GameObject)Instantiate (brick, transform.position, Quaternion.identity);
	}

}
