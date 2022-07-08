using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float dashSpeed;
    [SerializeField]
    float jumpForce = 1000;

	public float JumpForce
	{
		set
		{
			jumpForce = value;
		}

		get
		{
			return jumpForce;
		}
	}

    private Rigidbody2D rb;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // GetAxisRawを使用。入力が 0, 1, -1 のいずれかになる
        float moveInput = Input.GetAxisRaw("Horizontal");
        float xSpeed = 0.0f;
        float dSpeed = 0.0f;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            dSpeed = dashSpeed;
        }
        else
        {
            dSpeed = 1.0f;
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed * dSpeed;
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            xSpeed = -speed * dSpeed;
        }
        else
        {
            xSpeed = 0.0f;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;
        Debug.DrawRay(position, direction, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    void Jump()
    {
        if (!IsGrounded())
        {
            return;
        }
        else
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
