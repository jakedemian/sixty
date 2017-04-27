using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private const float TIMER_AMOUNT_IN_SECONDS = 3f;
	private float timer = TIMER_AMOUNT_IN_SECONDS;

	public GameObject player;

	void Update(){
		if(timer <= 0f){
			player.GetComponent<PlayerController>().resetPlayer();
			timer = TIMER_AMOUNT_IN_SECONDS;
		}
	}

	void FixedUpdate(){
		timer -= Time.deltaTime;
	}	
}
