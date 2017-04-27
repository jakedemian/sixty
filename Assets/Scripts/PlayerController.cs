using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float movementSpeedFactor = 40f;
	private float maxSpeed = 12f;
	private float switchDirectionSpeedBoostFactor = 1.5f;

	void FixedUpdate () {
		float move = Input.GetAxisRaw("Horizontal");
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if((move > 0f && rb.velocity.x < 0f) 
		|| (move < 0f && rb.velocity.y > 0f)){
			rb.AddForce(new Vector2(move * movementSpeedFactor
			 * switchDirectionSpeedBoostFactor, 0f));
		} else {
			rb.AddForce(new Vector2(move * movementSpeedFactor, 0f));
		}

		// clamp the horizontal speed to the max speed
		if(rb.velocity.x > maxSpeed){
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
		} if(rb.velocity.x < -maxSpeed){
			rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
		}
	}

	
}
