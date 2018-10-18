using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if(rb.velocity.z > 0.01f)
        {
            anim.SetFloat("Vertical", rb.velocity.z, 0.25f, Time.deltaTime);
        }
        //Debug.Log(rb.velocity.z);

    }
}
