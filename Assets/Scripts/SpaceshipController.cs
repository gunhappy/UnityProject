using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour {

	public GameObject myBullet;
	public int score=0;
	public Text score_text;
	// Use this for initialization
	void Start () {
		this.score = 0;
		GameObject.FindGameObjectWithTag ("Gamehandle").GetComponent<GameController>().setGameOver(false);
	}

	public void updateScore(int newscore){
		this.score += newscore;
	}

	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.x <= -11) {
			this.gameObject.transform.position = new Vector3(-11,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		}

		else if (this.gameObject.transform.position.x >= 11) {
			this.gameObject.transform.position = new Vector3(11,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
		}
		if (Input.GetAxis ("Horizontal") != 0) {
			this.gameObject.transform.Translate (Input.GetAxis ("Horizontal") * Vector3.right * Time.deltaTime * 5f);
		}
		if (Input.GetAxis("Vertical") != 0 ) {
			this.gameObject.transform.Translate (Input.GetAxis ("Vertical") * Vector3.up * Time.deltaTime *5f);
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			Instantiate (myBullet,this.gameObject.transform.position,Quaternion.identity);
		}

		score_text.text = "Score: " + this.score;
	}
}
