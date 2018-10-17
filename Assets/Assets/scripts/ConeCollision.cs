using UnityEngine;

public class ConeCollision : MonoBehaviour
{

    void onCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Cone")
        {
            Debug.Log("hitting cone");
            Destroy(gameObject);
        }
    }
}
