using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	float speed;
	void Start () {
		this.gameObject.transform.position = new Vector3(Random.Range(-10, 10),this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		speed = Random.Range (10f, 25f);
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.down * Time.deltaTime * speed);
		if (this.gameObject.transform.position.y <= -20f) {
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Spaceship") {
			Destroy (other.gameObject);
			GameObject.FindGameObjectWithTag ("Gamehandle").GetComponent<GameController>().setGameOver(true);
		}
	}
}
