using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

    public GameObject thingsToFollow;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - thingsToFollow.transform.position;
        
    }
	

	void LateUpdate () {
        transform.position = thingsToFollow.transform.position + offset;

    }
}
