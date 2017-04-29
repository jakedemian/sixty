using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour {

	public GameObject target;
	public Light mainLight;

	void Start () {
		transform.position = new Vector3(
			target.transform.position.x, 
			target.transform.position.y,
			transform.position.z
		);

		mainLight.transform.position = new Vector3(
			target.transform.position.x, 
			target.transform.position.y,
			transform.position.z
		);
	}
	
	void Update () {
		float newY = target.transform.position.y;
		if(newY < 0f){
			newY = 0f;
		}

		transform.position = new Vector3(
			target.transform.position.x, 
			newY,
			transform.position.z
		);

		mainLight.transform.position = new Vector3(
			target.transform.position.x, 
			target.transform.position.y,
			transform.position.z
		);
	}
}
