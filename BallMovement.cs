using UnityEngine;

public class CombinedScript : MonoBehaviour
{
    public float playerSpeed = 15.0f;
    public float jumpForce = 10.0f;
    public float collectableSpeed = 10.0f;
    public GameObject player;
    private Rigidbody rb;

    private bool isCollectable = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (gameObject.tag == "Collectable")
        {
            isCollectable = true;
        }

        if (isCollectable && player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        // Player logic
        if (!isCollectable)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            transform.Translate(new Vector3(horizontal, 0.0f, vertical) * playerSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
        // Collectable logic
        else if (player != null)
        {
            Vector3 awayFromPlayer = transform.position - player.transform.position;
            rb.MovePosition(transform.position + awayFromPlayer.normalized * collectableSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isCollectable && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}


