using UnityEngine;

public class ObstacleMovementScript : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    private GameObject player;
    private GameObject gameManager;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerMovementScript>();
        gameManager = GameObject.FindWithTag("GameManager");
        gameManager.GetComponent<PointingSystemScript>();

        speed = gameManager.GetComponent<PointingSystemScript>().speed;
    }
    private void FixedUpdate()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        if (rb != null)
        {
            if (!player.GetComponent<PlayerMovementScript>().isGrounded)
            {
                rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
            }
            else
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Edge"))
        {
            //Destroy it self
            Destroy(gameObject);
        }
    }

}
