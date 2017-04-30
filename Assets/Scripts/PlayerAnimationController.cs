using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {
	

	private Animator anim;
	public string lastTrigger = "";
	private bool preventFutureTriggers = false;

	void Start(){
		anim = GetComponent<Animator>();
	}

	public void setState(int state){
		anim.SetInteger("state", state);
	}

	public void trigger(string triggerName, bool preventFuture = false){
		if(!preventFutureTriggers){
			anim.SetTrigger(triggerName);
			lastTrigger = triggerName;

			if(preventFuture){
				preventFutureTriggers = true;
			}
		}
	}

	public void run(bool isRunning){
		anim.SetBool("isRunning", isRunning);
	}
}

