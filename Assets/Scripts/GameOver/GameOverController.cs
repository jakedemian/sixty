using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
	public Text gameOverText;

	private float displayTimer = 2f;
	private bool displayActive = false;

	void Start(){
		float width = gameOverText.GetComponent<RectTransform>().rect.width;
		float height = gameOverText.GetComponent<RectTransform>().rect.height;

		Vector2 screenMidPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
		Vector2 centeredTextPos = new Vector2(
			screenMidPoint.x - (width / 2f), 
			screenMidPoint.y - (height / 2f)
		);

		gameOverText.transform.position = centeredTextPos;
		gameOverText.gameObject.SetActive(false);

	}

	void Update(){
		if(Input.GetButtonDown("Jump")){
			if(!displayActive){
				displayActive = true;
				activateDisplay();
			} else {
				Application.LoadLevel("main");
			}
		}
	}

	void FixedUpdate(){
		displayTimer -= Time.deltaTime;

		if(!displayActive && displayTimer <= 0f){
			displayActive = true;
			activateDisplay();
		}
	}

	void activateDisplay(){
		GetComponent<AudioSource>().Play();
		gameOverText.gameObject.SetActive(true);
	}
}
