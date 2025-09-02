using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private InputAction jumpAction;
    [SerializeField]
    public bool isGrounded = false;
    [SerializeField]
    private PointingSystemScript pointingSystemScript;
    [SerializeField]
    private GameObject gameOverUI;

    private void OnEnable()
    {
        jumpAction.Enable();
    }
    private void OnDisable()
    {
        jumpAction.Disable();
    }

    private void Update()
    {
        if (jumpAction.triggered)
        {
            Jump();
        }
        CheckVelocity();
    }

    void Jump()
    {
        if (rb != null && !isGrounded)
        {
            //should Rotate the player a bit when jumping
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }

    private void CheckVelocity()
    {
        if (rb != null)
        {
            float angle = rb.linearVelocity.y > 0 ? 20f : -20f;
            rb.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            gameOverUI.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            pointingSystemScript.AddPoint();
        }
    }

}
