using UnityEngine;

public class KnifeCollision : MonoBehaviour {

    void onCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
