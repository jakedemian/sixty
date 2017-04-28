using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {
	

	private Animator anim;

	void Start(){
		anim = GetComponent<Animator>();
	}

	public void setState(int state){
		anim.SetInteger("state", state);
	}
}

