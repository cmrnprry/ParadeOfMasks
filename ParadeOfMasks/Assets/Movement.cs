using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool facingRight = true;

    public float moveForce = 365f;
    // the highest speed the player can get to (
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    // when you jump, this wil check if the ground is below you
    public Transform groundCheck;
    //Makes the sprite visible
    private SpriteRenderer sr;

    public LayerMask groundLayer;

    public bool seenByEnemy = true;
    public bool maskOn = false;



    private bool grounded = true;
    //private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
/*    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            Debug.Log("bgkfj");
            return true;
        }
        return false;
    }

    */
    void Awake()
    {
        // anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

 

   
    // do physics in FixedUpdate
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < maxSpeed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        // checks if you are going too fast
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

        if (h > 0 && facingRight)
        {
            Flip();

        }
        else if (h < 0 && !facingRight)
        {
            Flip();
        }

        if (jump)
        {
            Debug.Log("helo");
            //anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        bool space = Input.GetKeyDown("space");
        bool up = Input.GetKeyDown("up");

        int yMovement = (int)Input.GetAxisRaw("Horizontal");

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

       
            Debug.Log("help");
            if ((space || up) && grounded)
            {
                jump = true;
            }
  
    }

    // Changes the way the character is facing by negating X

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "Adversary")
        {
            Vector2 dir = transform.position - coll.transform.position;
            dir.Normalize();

            Rigidbody2D rbOther = coll.gameObject.GetComponent<Rigidbody2D>();
            rbOther.AddForce(dir * 2000 * Time.deltaTime);
            Debug.Log(rbOther);

        }
    }
}



