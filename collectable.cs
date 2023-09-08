using UnityEngine;

public class CollectableMovement : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;  // increased speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 awayFromPlayer = transform.position - player.transform.position;
            Vector3 newPosition = transform.position + (awayFromPlayer.normalized * speed * Time.deltaTime);
            
            // Immediately update the position
            transform.position = newPosition;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
 
