using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour {

	private float JUMP_SPEED = 9f;
	private float DOUBLE_JUMP_SPEED = 6.5f;
	private float JUMP_COOLDOWN_TIME = 0.1f;
	private float MAX_FALL_SPEED_FOR_DOUBLE_JUMP = -7f;

	private int jumpsLeft = 2;
	private float jumpTimer = 0f;

	/**
	* UPDATE
	*/
	void Update () {
		if(Input.GetButtonDown("Jump") && jumpsLeft > 0){
			Rigidbody2D rb = GetComponent<Rigidbody2D>();

			if(jumpsLeft == 2){
				rb.velocity = new Vector2(rb.velocity.x,JUMP_SPEED);
				jumpsLeft--;
			} else if (jumpsLeft == 1 && rb.velocity.y > MAX_FALL_SPEED_FOR_DOUBLE_JUMP){
				rb.velocity = new Vector2(rb.velocity.x,DOUBLE_JUMP_SPEED);
				jumpsLeft--;
			}
		}
	}

	/**
	 * FIXED UPDATE
	 */
	void FixedUpdate() {
		if(jumpTimer > 0f) {
			jumpTimer -= Time.deltaTime;

			if(jumpTimer <= 0f) {
				jumpTimer = 0f;
				jumpsLeft = 2;
			}
		}
	}

	/**
	 * ON COLLISION ENTER 2D
	 */
	void OnCollisionEnter2D(Collision2D c) {
		if(jumpsLeft < 2 && jumpTimer == 0f) {
			jumpTimer = JUMP_COOLDOWN_TIME;
		}
	}
}
