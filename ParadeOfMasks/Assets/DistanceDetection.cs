using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetect : MonoBehaviour
{
    public Movement movement;
    public GameObject Player;
    public GameObject Enemy;
    private Rigidbody2D rgdb;

    public float counter;
    public float count;

    // Use this for initialization
    void Start()
    {
        counter = count;
        rgdb = GetComponent<Rigidbody2D>();
        movement = Player.GetComponent<Movement>();
    }

    public void isMaskUp()
    {
        if (movement.speed > 1)
        {
            if (movement.isMask && counter < 0)
            {
                counter = count;
                movement.speed -= 1;
            }
        }

        if (movement.speed < movement.maxSpeed)
        {
            if (!movement.isMask && counter < 0)
            {
                counter = count;
                movement.speed += 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        counter -= Time.deltaTime;
    }
}

