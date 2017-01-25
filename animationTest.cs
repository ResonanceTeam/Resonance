using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationTest : MonoBehaviour
{

    Animator anim;

	// Use this for initialization
	void Start ()
    {

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        anim.SetBool("isMoving", Input.GetKey("w"));
        anim.SetBool("isAttacking", Input.GetKey("q"));
        anim.SetBool("isDying", Input.GetKey("e"));
    }
}
