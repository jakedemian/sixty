using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float movementSpeedFactor = 40f;
	private float maxSpeed = 12f;
	private float switchDirectionSpeedBoostFactor = 1.5f;

	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void FixedUpdate () {
		float move = Input.GetAxisRaw("Horizontal");
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		bool isGrounded = GetComponent<PlayerJumpController>().isGrounded;
		if(move != 0f && isGrounded){
			Debug.Log("here?");
			anim.SetBool("IsRunning", true);

			// accelerate
			rb.AddForce(new Vector2(move * movementSpeedFactor
			 * switchDirectionSpeedBoostFactor, 0f));
		} else if(move != 0f && !isGrounded){
			// TODO make hardcoded float a constant for in air direction change
			rb.AddForce(new Vector2(move * movementSpeedFactor * 0.5f, 0f)); 
		} else if(move == 0f && isGrounded){
			anim.SetBool("IsRunning", false);

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

		
	}

	void Update(){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		if(rb.velocity.x > 0){
			transform.localScale = new Vector3(1f, 1f, 1f);
		} else if (rb.velocity.x < 0){
			transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	
}
