using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchObjectConnector : MonoBehaviour {
	public GameObject pairedSwitch;
	public bool switchIsActive = false;

	void Update(){
		switchIsActive = pairedSwitch.GetComponent<SwitchController>().isPressed;
	}
}
