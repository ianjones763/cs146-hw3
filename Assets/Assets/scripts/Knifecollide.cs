using UnityEngine;

public class Knifecollide : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
