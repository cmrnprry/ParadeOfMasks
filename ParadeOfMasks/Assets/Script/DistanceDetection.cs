using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDetect : MonoBehaviour
{
    public Movement movement;
    public GameObject Player;
    public GameObject Enemy;
    private Rigidbody2D rgdb;
    private float dist;
    public float distance = 0f; //detection distance

    // Use this for initialization
    void Start()
    {
        rgdb = GetComponent<Rigidbody2D>();
        movement = Player.GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*     dist = Vector3.Distance(Enemy.transform.position, Player.transform.position);
             if (dist < distance && movement.IsMasked == false)
             {
                 movement.maxSpeed = 2;
             }
             else if (dist < distance && movement.IsMasked == true)
             {
                 movement.maxSpeed = 4;
             }
             else {
                 movement.maxSpeed = 5;
             }*/
    }
}

