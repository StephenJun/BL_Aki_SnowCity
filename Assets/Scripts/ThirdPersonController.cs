using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class ThirdPersonController : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;
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
        Vector3 moveDir = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed;

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        CameraManager.singleton.FixedTick(Time.fixedDeltaTime);

        transform.rotation = Quaternion.LookRotation(CameraManager.singleton.transform.forward, Vector3.up);


        //TODO:动画状态的切换

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //交互
        }
    }


    //只有玩家处在地面上时才能够跳跃。

    //只有玩家周围有能够交互的物体或者npc时才能够使用交互。
}
