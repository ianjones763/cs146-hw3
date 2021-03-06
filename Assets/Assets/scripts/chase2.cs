﻿using System.Collections;
using UnityEngine;

public class chase2 : MonoBehaviour {
    public Transform player;
    static Animator anim;

	void Start () {
        anim = GetComponent<Animator>();
	}
	

	void Update () 
    {
        Vector3 direction = player.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(player.position, this.transform.position) < 20 && angle < 30)
        {

            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                                       Quaternion.LookRotation(direction), 0.1f);


            anim.SetBool("isIdle", false);
            if (direction.magnitude > 2)
            {
                this.transform.Translate(0, 0, 0.075f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            // Close enough to attack, animate the attack and decrement health
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else 
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }


	}
}
