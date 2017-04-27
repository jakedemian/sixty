using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	private const float TIMER_AMOUNT_IN_SECONDS = 3f;
	private float timer = TIMER_AMOUNT_IN_SECONDS;
	private Vector2 playerStartPosition;

	public GameObject player;

	void Start(){
		playerStartPosition = player.transform.position;
	}

	void Update(){
		// if player falls out of camera view, reset
		if(!player.GetComponent<Renderer>().isVisible){
			resetPlayer();
		}

		// if time runs out, reset the player
		if(timer <= 0f){
			resetPlayer();
		}
	}

	void FixedUpdate(){
		timer -= Time.deltaTime;
	}

	public void resetPlayer(){
		player.transform.position = playerStartPosition;
		player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		timer = TIMER_AMOUNT_IN_SECONDS;
	}
}
