using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    public float groundYPosition = -4.3f;
    private bool isGrounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckIfGrounded();

        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity = Vector2.up * jumpForce;
            }
        }
    }

    private void CheckIfGrounded()
    {
        isGrounded = transform.position.y <= groundYPosition + 0.05f;
        rb.gravityScale = isGrounded ? 0 : 1.5f;

        if (transform.position.y < groundYPosition)
        {
            transform.position = new Vector2(transform.position.x, groundYPosition);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); 
        }
    }
}
