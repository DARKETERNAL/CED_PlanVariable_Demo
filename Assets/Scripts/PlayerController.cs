using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float movSpeed = 10F;

    [Header("Jump")]
    [SerializeField]
    private float jumpScale = 5F;

    [Header("Shoot")]
    [SerializeField]
    private Rigidbody bulletGO;

    [SerializeField]
    private float shootForce;

    [SerializeField]
    private Transform spawnPosition;

    [SerializeField]
    private AudioSource jumpAudioSource;

    [SerializeField]
    private ParticleSystem groundedPS;

    private float movDirection;
    private Rigidbody rb;

    private bool isGrounded = true;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        movDirection = Input.GetAxis("Vertical");

        if (movDirection != 0F)
        {
            transform.Translate(transform.forward * movDirection * movSpeed * Time.deltaTime, Space.World);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            if (jumpAudioSource != null)
            {
                jumpAudioSource.Play();
            }

            rb.AddForce(Vector3.up * jumpScale, ForceMode.Impulse);
            isGrounded = false;
        }

        if (Input.GetButtonUp("Fire1") && bulletGO != null && spawnPosition != null)
        {
            Rigidbody bulletClone = Instantiate<Rigidbody>(bulletGO, spawnPosition.position, spawnPosition.rotation);
            bulletClone.AddForce(bulletClone.transform.forward * shootForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            if (groundedPS != null)
            {
                groundedPS.Play();
            }

            isGrounded = true;
        }
    }
}