﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float movementSpeedFactor = 40f;
	private float maxSpeed = 12f;
	private float switchDirectionSpeedBoostFactor = 1.5f;
	private float inAirMoveAdjustmentFactor = 0.5f;
	private PlayerAnimationController animCtrl;

	void Start(){
		animCtrl = GetComponent<PlayerAnimationController>();
	}

	void Update () {
		float move = Input.GetAxisRaw("Horizontal");
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		bool isGrounded = GetComponent<PlayerJumpController>().isGrounded;
		if(move != 0f && isGrounded){
			animCtrl.trigger("triggerRun");

			// accelerate
			rb.AddForce(new Vector2(move * movementSpeedFactor
			 * switchDirectionSpeedBoostFactor, 0f));
		} else if(move != 0f && !isGrounded){
			rb.AddForce(new Vector2(move * movementSpeedFactor * inAirMoveAdjustmentFactor, 0f)); 
		} else if(move == 0f && isGrounded){
			animCtrl.trigger("triggerIdle");

			// decelerate
			if(rb.velocity.x > 0f){
				rb.velocity = new Vector2(rb.velocity.x - 0.5f, rb.velocity.y);

				if(rb.velocity.x < 0f){
					rb.velocity = new Vector2(0f, rb.velocity.y);
				}
			} else if(rb.velocity.x < 0f){
				rb.velocity = new Vector2(rb.velocity.x + 0.5f, rb.velocity.y);

				if(rb.velocity.x > 0f){
					rb.velocity = new Vector2(0f, rb.velocity.y);
				}
			}
		}

		// clamp the horizontal speed to the max speed
		if(rb.velocity.x > maxSpeed){
			rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
		} if(rb.velocity.x < -maxSpeed){
			rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
		}

		if(rb.velocity.x > 0){
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (rb.velocity.x < 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}	
}
