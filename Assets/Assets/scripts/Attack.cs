using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class Attack : MonoBehaviour
{


    public GameObject knifePrefab;
    public Transform knifeSpawn;
    public float knifeVelocity = 10f;

    private bool thrown;
    private float ready;
    private float cooldown = 1f;



    private void FixedUpdate()
    {

        if (Input.GetButtonDown("Jump") && !thrown && ready <= Time.time)
        {
            // Haven't fired yet on this key stroke, so fire
            StartCoroutine("Throw");
        }
        else if (Input.GetButtonUp("Jump") && thrown)
        {
            // Already fired, reset fire cooldown on key release
            thrown = false;
        }


    }

    IEnumerator Throw()
    {
        thrown = true;
        yield return new WaitForSeconds(.5f);
        ready = Time.time + cooldown;
        var knife = (GameObject)Instantiate(knifePrefab, knifeSpawn.position, knifeSpawn.rotation);
        knife.GetComponent<Rigidbody>().velocity = (knife.transform.forward + 0.4f * knife.transform.up) * knifeVelocity;
        Destroy(knife, 0.5f);
    }
    
}




/*using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject laserPrefab;
    public Transform laserSpawn;
    public float forwardForce = 2000f;  // Determines forward force of spaceship
    public float sidewaysForce = 500f;  // Determines sideways force of spaceship
    public float laserVelocity = 10f;   // Determines speed of laser when shot

    private bool fired;                 // Determines if laser has been fired on current key stroke

    void FixedUpdate()
    {
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d"))  // If the player is pressing the "d" key
        {
            // Add a force to the right
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))  // If the player is pressing the "a" key
        {
            // Add a force to the left
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -0.5f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (rb.position.x < -7.3f || rb.position.x > 7.3f)
        {
            rb.useGravity = true;
        }

        if (Input.GetButtonDown("Fire1") && !fired)
        {
            // Haven't fired yet on this key stroke, so fire
            Fire();
        }
        else if (Input.GetButtonUp("Fire1") && fired)
        {
            // Already fired, reset fire cooldown on key release
            fired = false;
        }
    }

    // Fires a laser from the spaceship
    // This code was pieced together from a couple tutorials on the Unity website to make projectiles
    void Fire()
    {
        fired = true;
        var laser = (GameObject)Instantiate(laserPrefab, laserSpawn.position, laserSpawn.rotation);
        laser.GetComponent<Rigidbody>().velocity = laser.transform.forward * laserVelocity;
        Destroy(laser, 0.5f);
    }
}*/
