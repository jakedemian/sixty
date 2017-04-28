using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private const float TIMER_AMOUNT_IN_SECONDS = 60f;
	private float timer = TIMER_AMOUNT_IN_SECONDS;
	private Vector2 playerStartPosition;

	public GameObject player;
	public Text timerTextUI;

	private Camera mainCamera;
	private Plane[] planes;
	private Collider2D playerCollider;

	void Start(){
		playerStartPosition = player.transform.position;

		mainCamera = Camera.main;
		planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        playerCollider = player.GetComponent<Collider2D>();
	}

	void Update(){
		// if player falls out of camera view, reset
		planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
		if(!GeometryUtility.TestPlanesAABB(planes, playerCollider.bounds)){
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

	void OnGUI(){
		timerTextUI.text = timer.ToString("F2");
	}

	public void resetPlayer(){
		//player.transform.position = playerStartPosition;
		//player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		//timer = TIMER_AMOUNT_IN_SECONDS;
		Application.LoadLevel("game_over");
	}
}
