using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdversaryMovement : MonoBehaviour {

    // how long the boys look one way
    public float counter;
    public float count;

    // which way the boy is facing
    // do i need him
    public bool isFacingRight;

    private SpriteRenderer sr;

    void Start()
    {
        counter = count;
        isFacingRight = false;

        sr = GetComponent<SpriteRenderer>();
    }

    // flips the adversay sprite when they turn
    void Flip()
    {
     //   Debug.Log("hello");

        isFacingRight = !isFacingRight;

        if (sr != null && isFacingRight)
        {
           // Debug.Log("Are you doing it");
            sr.flipX = true;
        } else
        {
            sr.flipX = false;
        }

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
