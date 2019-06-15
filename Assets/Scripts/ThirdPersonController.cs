using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DM;

public class ThirdPersonController : MonoBehaviour {

    public float moveSpeed = 10;
    public float sprintSpeed = 12;
    public float jumpForce = 6;
    public float rotateSpeed = 5;
    public GameObject activeModel;
    internal Rigidbody rb;
    private Animator anim;
    internal bool onGround;
    internal bool canMove;
    private bool sprint;

    private List<InteractableObj> _InterObjs = new List<InteractableObj>();


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        SetupAnimator();
        CameraManager.singleton.Init(this.transform);
    }

    void SetupAnimator()
    {
        if (activeModel == null)
        {
            anim = GetComponentInChildren<Animator>();
            if (anim == null)
            {
                Debug.Log("No model");
            }
            else
            {
                activeModel = anim.gameObject;
            }
        }

        if (anim == null)
            anim = activeModel.GetComponent<Animator>();

        if (anim == null)
            anim = activeModel.AddComponent<Animator>();
    }

    private void Update()
    {
        onGround = OnGround();
        canMove = CanControl();
    }

    // Update is called once per frame
    void FixedUpdate () {

        CameraManager.singleton.FixedTick(Time.fixedDeltaTime);
        //TODO:动画状态的切换
        anim.SetBool("onGround", onGround);
        if (!canMove)
            return;


        sprint = Input.GetKey(KeyCode.LeftShift);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float realSpeed = sprint ? sprintSpeed : moveSpeed;
        Vector3 moveDir = (transform.forward * verticalInput + transform.right * horizontalInput).normalized * realSpeed;

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);
        float moveAmount = Mathf.Clamp01(rb.velocity.magnitude);
        Quaternion targetRotation = Quaternion.LookRotation(CameraManager.singleton.transform.forward, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime * moveAmount * rotateSpeed);
        anim.SetFloat("vertical", moveAmount, 0.2f, Time.fixedDeltaTime);
        anim.SetBool("sprint", sprint);

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            anim.CrossFade("falling", 0.1f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Q) && onGround)
        {
            anim.SetTrigger("roll");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //交互
            if(_InterObjs.Count != 0)
            {
                Debug.Log("Hi，NPC！");
                UIManager.Instance.Push<UIScreenDialogue>(false, 1001);
            }
        }
    }

    private bool CanControl()
    {
        if (!onGround)
            return false;
        if (!anim.GetBool("canMove"))
            return false;
        return true;
    }

    //只有玩家处在地面上时才能够跳跃。
    private bool OnGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, 0.2f, 1 << 11))
        {
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                return true;
            }
        }
        return false;


    }



    //只有玩家周围有能够交互的物体或者npc时才能够使用交互。
    private void OnTriggerEnter(Collider other)
    {
        InteractableObj otherInter = other.gameObject.GetComponent<InteractableObj>();
        if (otherInter != null)
        {
            _InterObjs.Add(otherInter);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractableObj otherInter = other.gameObject.GetComponent<InteractableObj>();
        if (otherInter != null)
        {
            if(_InterObjs.Contains(otherInter))
                _InterObjs.Remove(otherInter);
            else
            {
                Debug.LogWarning("意料之外的问题！");
            }
        }
    }
}
