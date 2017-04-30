using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag.Equals("Player")){
			c.gameObject.GetComponent<PlayerController>().killPlayer();
		}
		Destroy(gameObject);
	}
}
