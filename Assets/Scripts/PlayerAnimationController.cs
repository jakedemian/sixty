using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {
	

	private Animator anim;
	public string lastTrigger = "";

	void Start(){
		anim = GetComponent<Animator>();
	}

	public void setState(int state){
		anim.SetInteger("state", state);
	}

	public void trigger(string triggerName){
		anim.SetTrigger(triggerName);
		lastTrigger = triggerName;
	}

	public void run(bool isRunning){
		anim.SetBool("isRunning", isRunning);
	}
}

