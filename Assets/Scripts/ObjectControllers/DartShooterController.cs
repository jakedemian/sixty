using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartShooterController : MonoBehaviour {

	public GameObject dartPrefab;
	public int shootDirection = 0;
	private bool shootDebouncer = false;
	private float dartSpeed = 18f;

	void Update(){
		if(!shootDebouncer && GetComponent<SwitchObjectConnector>().switchIsActive){
			shoot();
			shootDebouncer = true;
		} else if(shootDebouncer && !GetComponent<SwitchObjectConnector>().switchIsActive){
			shootDebouncer = false;
		}
	}

	void shoot(){
		if(shootDirection != 0){
			GameObject go = Instantiate(dartPrefab, 
				new Vector2(transform.position.x - 0.6f, transform.position.y), 
				Quaternion.identity); 
			go.GetComponent<Rigidbody2D>().velocity = new Vector2((float) shootDirection * dartSpeed, 0f);
		} else {
			Debug.LogError("The shoot() method was called but shootDirection was never set.  Nothing was shot.");
		}
	}
}
