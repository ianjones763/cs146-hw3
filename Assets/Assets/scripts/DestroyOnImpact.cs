using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Knife")
        {
            Timer.timeAdd = true;
            Destroy(gameObject);
        }
    }
}
