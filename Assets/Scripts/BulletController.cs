using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour {
	public AudioClip myExplosion;
	// Use this for initialization
	void Start () {
		Color newColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		gameObject.GetComponent<Renderer> ().material.color = newColor;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (Vector3.up * Time.deltaTime * 10f);
		if (this.gameObject.transform.position.y >= 20f) {
			Destroy (this.gameObject);
		}

	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
			this.gameObject.GetComponent<AudioSource> ().clip = myExplosion;
			this.gameObject.GetComponent<AudioSource> ().Play ();
			GameObject.FindGameObjectWithTag ("Spaceship").GetComponent<SpaceshipController>().updateScore(10);
		}
	}
}
