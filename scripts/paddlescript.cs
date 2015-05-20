using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class paddlescript : MonoBehaviour {
	// Use this for initialization
	float value;
	public GameObject ball;
	public GameObject attachedBall;
	public float points;

	void Start () {
		points = 0;
		if (Application.loadedLevelName == "GameOver") {
			Destroy(gameObject);
		} else {
			DontDestroyOnLoad (gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate () {
	value = Input.GetAxis ("Horizontal");
		if (transform.position.x < -5.25 && value == -1) {
			value = 0;
		}
		if (transform.position.x > 5.25 && value == 1) {
			value = 0;
		}
		this.transform.Translate(5*Time.deltaTime*value,0,0);

		if (attachedBall) {
			attachedBall.transform.position = transform.position + new Vector3 (0, .35f, 0);
		}

		if (attachedBall != null) {
			if (Input.GetButtonDown ("Jump")) {
				attachedBall.GetComponent<Rigidbody> ().AddForce (Input.GetAxis ("Horizontal") * 200f, 200f, 0);
				attachedBall = null;
			}
		}
		GameObject.Find("score").GetComponent<Text>().text = "Score: "+ points;

	}

	void OnCollisionEnter( Collision col)
	{
		foreach (ContactPoint contact in col.contacts) {

			if (contact.thisCollider == GetComponent<Collider>()) {
				float distanceCentre = contact.point.x - transform.position.x;
				contact.otherCollider.attachedRigidbody.AddForce (150f * distanceCentre, 0, 0);
			}
		}
		Debug.Log ("collided");
	}

	public void AddPoint(float v){
		points += v;
	}

	public void SpawnBall(){
		attachedBall = (GameObject)Instantiate (ball, transform.position, Quaternion.identity);
	}



}
