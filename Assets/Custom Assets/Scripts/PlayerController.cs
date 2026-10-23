using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;   

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public int maxJumpValue = 1;
    public float speed = 5f;
    public float jumpPower = 10f;
    public bool isDucking;
    public float downForce;
    public int timesJumped = 0;
    public AudioClip jumpSound;
    private AudioSource playerJumpSound;
    public ScoreManager scoreManager;



    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerJumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsGrounded()) 
        {
            timesJumped = 0;
        }

        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && timesJumped < maxJumpValue)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpPower);
            timesJumped++;
            playerJumpSound.PlayOneShot(jumpSound);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))
        {

            scoreManager.AddScore(5);
            StartCoroutine(TripleJumpTime());
            Destroy(collision.gameObject);
        }
    }

    public IEnumerator TripleJumpTime()
    {
        maxJumpValue = 2;
        yield return new WaitForSeconds(2f);
        maxJumpValue = 1;
        Debug.Log("Powerup expired");

    }


}
