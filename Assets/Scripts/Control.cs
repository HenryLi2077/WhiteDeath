using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {

    private Animator anim;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 input = new Vector2(horizontal, vertical).normalized;

        Vector3 _rot = transform.right * horizontal * 100;
        Vector3 _move = transform.forward * vertical;

        if(input != Vector2.zero)
        {
            rb.MovePosition(rb.position + _move * Time.deltaTime);
        }

        if (_rot != Vector3.zero)
        {
            gameObject.transform.Rotate(0, horizontal * Time.deltaTime * 100, 0);
        }

        anim.SetFloat("Horizontal", input.x, 0.25f, Time.deltaTime);
        anim.SetFloat("Vertical", input.y, 0.25f, Time.deltaTime);
    }
}
