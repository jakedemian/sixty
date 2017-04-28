using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpController : MonoBehaviour {

	public Transform blockPrefab;

	private float JUMP_SPEED = 12f;
	private float DOUBLE_JUMP_SPEED = 8f;
	private float JUMP_COOLDOWN_TIME = 0.1f;
	private float MAX_FALL_SPEED_FOR_DOUBLE_JUMP = -7f;

	private int jumpsLeft = 2;
	private float jumpTimer = 0f;

	private Animator anim;

	// TODO FIXME move this logic to a separate static class
	public int wallCollisionDir = 0;
	public bool isGrounded = true;

	private const int BLOCK_LAYER = 1 << 8;


	void Start(){
		anim = GetComponent<Animator>();
	}

	/**
	* UPDATE
	*/
	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		this.updateCollisionState();

		if(!isGrounded && wallCollisionDir != 0) {
			anim.SetBool("IsOnWall", true);			
		} else if(!isGrounded && wallCollisionDir == 0){
			anim.SetBool("IsOnWall", false);
		} else if(isGrounded){
			anim.SetBool("IsOnWall", false);
			anim.SetBool("IsJumping", false);
			anim.SetBool("IsDoubleJumping", false);
		}

		// if the user has pressed down the Jump button this frame
		if(Input.GetButtonDown("Jump")){
			if(!isGrounded && wallCollisionDir != 0){
				if(wallCollisionDir == 1){
					rb.velocity = new Vector2(-JUMP_SPEED * 2f,JUMP_SPEED);
					jumpsLeft = 1;
				} else if (wallCollisionDir == -1){
					rb.velocity = new Vector2(JUMP_SPEED * 2f,JUMP_SPEED);
					jumpsLeft = 1;
				}
			} else if(jumpsLeft > 0) {
				if(jumpsLeft == 2 && isGrounded){
					anim.SetBool("IsJumping", true);
					jumpsLeft--;
					rb.velocity = new Vector2(rb.velocity.x,JUMP_SPEED);
				} else if (jumpsLeft == 1 && !isGrounded
				&& Mathf.Abs(rb.velocity.y) < Mathf.Abs(MAX_FALL_SPEED_FOR_DOUBLE_JUMP)){
					anim.SetBool("IsDoubleJumping", true);
					rb.velocity = new Vector2(rb.velocity.x,DOUBLE_JUMP_SPEED);
					jumpsLeft--;
				}
			}
		}
	}

	/**
	 * ON COLLISION ENTER 2D
	 */
	void OnCollisionEnter2D(Collision2D c) {
		Vector2 hit = c.contacts[0].normal;

		// http://answers.unity3d.com/comments/474489/view.html
		// if the collision contact point is on the bottom of my player..
		if(Vector2.Dot(hit,Vector2.up) > 0){
			anim.SetBool("IsDoubleJumping", false);
			anim.SetBool("IsJumping", false);
			jumpsLeft = 2;
		}


	}

	void OnCollisionExit2D(Collision2D c){
		// if you leave a collision without jumping, and you're falling...
		if(jumpsLeft == 2 && GetComponent<Rigidbody2D>().velocity.y != 0f) {
			jumpsLeft = 0;
			anim.SetBool("IsJumping", true);
		}
	}

	// TODO FIXME move this logic to a separate static class
	void updateCollisionState(){
		Rigidbody2D rb = GetComponent<Rigidbody2D>();

		// check for ground
		RaycastHit2D downHit = Physics2D.Raycast(
			new Vector2(rb.position.x, rb.position.y - 0.5f),
			Vector2.down, 
			0.1f,
			BLOCK_LAYER);
		isGrounded = downHit ? true : false;
		//Debug.Log(isGrounded);

		// check left side wall collision
		RaycastHit2D leftHit = Physics2D.Raycast(
			new Vector2(rb.position.x - 0.32f, rb.position.y),
			Vector2.left, 
			0.1f,
			BLOCK_LAYER);

		// check left side wall collision
		RaycastHit2D rightHit = Physics2D.Raycast(
			new Vector2(rb.position.x + 0.32f, rb.position.y),
			Vector2.right, 
			0.1f,
			BLOCK_LAYER);

		if(leftHit && !rightHit){
			wallCollisionDir = -1;
		} else if (!leftHit && rightHit){
			wallCollisionDir = 1;
		} else {
			wallCollisionDir = 0;
		}
	}
}
