using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{

    [HideInInspector] public bool jump = false;
    [HideInInspector] public bool facingRight = true;

    public float moveForce = 365f;
    // the highest speed the player can get to (
    public float maxSpeed = 5f;

    // when you jump, this wil check if the ground is below you
    // public Transform groundCheck;
    //Makes the sprite visible
    private SpriteRenderer sr;
<<<<<<< HEAD

    public Animator anim;
=======
>>>>>>> cam/work

    public float jumpForce = 1000f;
    private bool isGrounded;        //this variable will tell if our player is grounded or not
    public Transform feetPos;       //this variable will store reference to transform from where we will create a circle
    public float circleRadius;      //radius of circle
    public LayerMask whatIsGround;  //layer our ground will have.

    public bool isMask;
    public float speed;

    public float jumpTime;          //time till which we will apply jump force
    private float jumpTimeCounter;  //time to count how long player has pressed jump key

    public float counter;
    public float count;

    public AudioMixerSnapshot slow;
    public AudioMixerSnapshot normal;
    public float transtionToSlow;
    public float transtionToNormal;

    //private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
<<<<<<< HEAD


=======
        speed = maxSpeed;
        counter = count;
        isMask = false;
>>>>>>> cam/work
    }

    public void isMaskUp()
    {
        counter = count;

        if (speed > 1)
        {
            if (isMask && counter < 0)
            {
                Debug.Log("please");
                speed -= 1;
            }
        }

        if (speed < maxSpeed)
        {
            if (!isMask && counter < 0)
            {
                speed += 2;
            }
        }

        counter = count;
    }
    
    // Update is called once per frame
    void Update()
    {

        //here we set the isGrounded
        isGrounded = Physics2D.OverlapCircle(feetPos.position, circleRadius, whatIsGround);
        //we check if isGrounded is true and we pressed Space button
        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))

        {
            jump = true;                           //we set isJumping to true
            jumpTimeCounter = jumpTime;                 //set jumpTimeCounter
            rb2d.velocity = Vector2.up * jumpForce;       //add velocity to player
        }

        //if Space key is pressed and isJumping is true
        if (Input.GetKey(KeyCode.Space) && jump == true)
        {
            if (jumpTimeCounter > 0)                    //we check if jumpTimeCounter is more than 0
            {
                rb2d.velocity = Vector2.up * jumpForce;   //add velocity
                jumpTimeCounter -= Time.deltaTime;      //reduce jumpTimeCounter by Time.deltaTime
            }
            else                                        //if jumpTimeCounter is less than 0
            {
                jump = false;                      //set isJumping to false
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))              //if we unpress the Space key
        {
            jump = false;                          //set isJumping to false
        }

        if (Input.GetKey(KeyCode.X))
        {
            isMask = true;
            slow.TransitionTo(transtionToSlow);
            isMaskUp();
 
        } else
        {
            isMask = false;
            normal.TransitionTo(transtionToNormal);
            isMaskUp();
        }
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);


    }

    // do physics in FixedUpdate
    void FixedUpdate()
    {
            counter -= Time.deltaTime;

        float h = Input.GetAxis("Horizontal");

        //anim.SetFloat("Speed", Mathf.Abs(h));

        if (h * rb2d.velocity.x < speed)
            rb2d.AddForce(Vector2.right * h * moveForce);

        // checks if you are going too fast
        if (Mathf.Abs(rb2d.velocity.x) > speed)
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * speed, rb2d.velocity.y);

        if (h > 0 && facingRight)
        {
            Flip();

        }
        else if (h < 0 && !facingRight)
        {
            Flip();
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
}



