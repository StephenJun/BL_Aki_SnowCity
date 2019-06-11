using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class ThirdPersonController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        CameraManager.singleton.Init(this.transform);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        rb.velocity = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed;

        CameraManager.singleton.FixedTick(Time.fixedDeltaTime);
    }
}
