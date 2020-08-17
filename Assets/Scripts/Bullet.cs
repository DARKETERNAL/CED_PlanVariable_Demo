using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float autoDestroyTime = 5F;

    [SerializeField]
    private ParticleSystem hitPS;

    private void Start()
    {
        Destroy(gameObject, autoDestroyTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hitPS != null)
        {
            hitPS.transform.parent = null;
            hitPS.Play();
            Destroy(hitPS.gameObject, hitPS.startLifetime + 0.1F);
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}