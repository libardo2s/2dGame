using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(Plat))]
public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;
    public Transform groundCheck;
    public LayerMask whatIsGround;
    public float jumpForce = 400f;

    bool facingRight = true;
    bool grounded = false;
    bool doubleJump = false;
    bool jump;
    float groundRadius = 0.2f;
    private Rigidbody2D playerRigidbody2D;
    private Animator animator;

	// Use this for initialization
	void Start () {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}

    void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            //jump = true;
            animator.SetBool("Ground", false);
            playerRigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        animator.SetBool("Ground", grounded);

        animator.SetFloat("vSpeed", playerRigidbody2D.velocity.y);

        //if (!grounded) return;

        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        playerRigidbody2D.velocity = new Vector2(move * maxSpeed, playerRigidbody2D.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        /*
        if ((grounded || !doubleJump) && jump)
        {
            animator.SetBool("Ground", false);
            playerRigidbody2D.velocity = new Vector2(playerRigidbody2D.velocity.x,0);
            playerRigidbody2D.AddForce(new Vector2(0f, jumpForce));
            if (!grounded)
                doubleJump = true;
        }
        */

	}

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
