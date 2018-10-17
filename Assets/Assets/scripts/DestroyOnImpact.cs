using UnityEngine;

public class DestroyOnImpact : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Knife")
        {
            Debug.Log("hit");
            Destroy(gameObject);
        }
    }
}
