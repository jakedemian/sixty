using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D c){
		if(c.gameObject.tag.Equals("Player")){
			Debug.Log("killing player...");
			c.gameObject.GetComponent<PlayerController>().killPlayer();
			Debug.Log("afterKilledplayer");
		}
		Destroy(gameObject);
	}
}
