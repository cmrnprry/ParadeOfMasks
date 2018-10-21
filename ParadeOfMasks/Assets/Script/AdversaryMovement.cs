using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryMovement : MonoBehaviour
{

    // how long the boys look one way
    private float counter;
    public float count;

    // which way the boy is facing
    // do i need him
    public bool isFacingRight;

    void Start()
    {
        counter = count;
        isFacingRight = false;

    }

    // flips the adversay sprite when they turn
    void Flip()
    {

        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Update()
    {

        counter -= Time.deltaTime;
        if (counter < 0)
        {
            Flip();

            counter = count;
        }
    }
}
