using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public int maxJumpValue = 2;
    public float speed = 5f;
    public float jumpPower = 10f;
    public bool isDucking;
    public float downForce;
    private int timesJumped = 0;

    

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;

    // Update is called once per frame
    void Update()
    {
        
        if (IsGrounded()) 
        {
            timesJumped = 0;
        }

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && timesJumped < 2)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            timesJumped++;
        }
        
       /* if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector
       2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }
       */
        if (horizontal != 0)
        {
            animator.SetBool("isHussing", true);
        }
        else
        {
            animator.SetBool("isHussing", false);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, downForce);
        }
        else 
        {
            transform.localScale = Vector3.one;
        }
        
       
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

 
}
