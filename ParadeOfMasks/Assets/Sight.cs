using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour {

    //is a maybe
    //if in sight and not mask then cone gets bigger/ more visible


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            DistanceDetect.isMaskUp();
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
