using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

	public bool isPressed = false;
	public GameObject player;

	void Update(){
		Vector2 pPos = player.transform.position;
		Vector2 sPos = transform.position;

		float sLeft = sPos.x - 0.5f;
		float sRight = sPos.x + 0.5f;

		if(pPos.x < sRight && pPos.x > sLeft && 
		Mathf.Abs(pPos.y) - Mathf.Abs(sPos.y) < 0.5f && 
		player.GetComponent<PlayerJumpController>().isGrounded){
			isPressed = true;
		} else {
			isPressed = false;
		}

		updateSwitchDisplayState();
	}

	void updateSwitchDisplayState(){
		hideSwitch(isPressed);
	}

	void hideSwitch(bool b){
		// do something else, i cant reactivate myself if i've disabled myself
		GetComponent<Renderer>().enabled = !b;
	}
}
