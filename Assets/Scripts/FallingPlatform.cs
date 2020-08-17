using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField]
    private float timeToFall = 2F;

    [SerializeField]
    private Rigidbody rb;

    private void Start()
    {
        if (rb != null)
        {
            rb.useGravity = false;
            rb.isKinematic = true; 
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Fall", timeToFall);
        }
    }

    private void Fall()
    {
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}