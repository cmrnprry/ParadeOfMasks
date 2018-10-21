using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryMovement : MonoBehaviour
{

    // how long the boys look one way
    private float counter;
    public float count;

    //Where I want them to move
    public Transform goToLeft;
    public Transform goToRight;
    public float speed;
    private float step;

    public bool colliding = false;

    // which way the boy is facing
    // do i need him
    // yes???
    public bool isFacingRight;

    void Start()
    {
        counter = count;
        isFacingRight = false;

    }

    // flips the adversay sprite when they turn
    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void ChangeDirection()
    {
        // makes them turn left and right evey X amount of seconds
        counter -= Time.deltaTime;
        if (counter < 0)
        {
            Flip();

            counter = count;
        }
    }

    void Update()
    {
        step = speed * Time.deltaTime;

        if (!isFacingRight)
        {
            
            transform.Translate(Vector2.left * step);

            //transform.position = Vector2.MoveTowards(transform.position, goToLeft.position, step);
        } else
        {
           
            transform.Translate(Vector2.right * step);

            //transform.position = Vector2.MoveTowards(transform.position, goToRight.position, step);
        }

        if (transform.position.x <= goToLeft.position.x)
        {
            Flip();
            isFacingRight = true;
        }

        if (transform.position.x >= goToRight.position.x)
        {
            Flip();
            isFacingRight = false;
        }

    }
}
