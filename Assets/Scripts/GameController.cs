using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	// Use this for initialization
	bool gameover_status;
	public Text gameover_text;
	public Button retry_btn;
	bool restart = false;

	void Start () {
		this.gameover_status = false;
	}

	public void setGameOver(bool status){
		this.gameover_status = status;
	}
	
	// Update is called once per frame
	void Update () {

		if (this.gameover_status) {
			this.gameover_text.gameObject.SetActive (true);
			this.retry_btn.gameObject.SetActive (true);
		} 
		else {
			this.gameover_text.gameObject.SetActive (false);
			this.retry_btn.gameObject.SetActive (false);
		}

		this.retry_btn.onClick.AddListener(retryOnClick);

		if (restart) {
			SceneManager.LoadScene("GamePlay");
			restart = false;
		}

	}

	void retryOnClick(){
		restart = true;
	//	this.gameover_text.gameObject.SetActive (false);
	//	this.retry_btn.gameObject.SetActive (false);
	//	this.gameover_status = false;
	}
}
