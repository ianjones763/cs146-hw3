using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    static Animator anim;
    public float speed = 10f;
    public float rotationSpeed = 100f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // moving/rotating character
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        //space bar is automatically "Jump" but ours is throw
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("isThrowing");
        }

        if (translation != 0) {
            anim.SetBool("isRunning", true);
            anim.SetBool("isIdle", false);
        } else {
            anim.SetBool("isRunning", false);
            anim.SetBool("isIdle", true);
        }
    }
}
