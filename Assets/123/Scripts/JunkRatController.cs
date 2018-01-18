using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRatController : MonoBehaviour
{

    [SerializeField] float WalkVelocity;
    [SerializeField] float AirControl;
    [SerializeField] float JumpSpeed;

    Rigidbody RB;
    CharacterController CC;
    Camera camera;
    [SerializeField]bool IsGrounded;

    // Use this for initialization
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        camera = GetComponentInChildren<Camera>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HeadTurn();
    }
    void FixedUpdate()
    {
        Walk();
        Jump();
    }
    void Walk()
    {
        if (IsGrounded)
        {
            RB.velocity = transform.forward * Input.GetAxis("Vertical") * WalkVelocity + transform.right * Input.GetAxis("Horizontal") * WalkVelocity + new Vector3(0, RB.velocity.y, 0);
        }
        else
        {
            RB.velocity = transform.forward * Input.GetAxis("Vertical") * AirControl + transform.right * Input.GetAxis("Horizontal") * AirControl + new Vector3(0, RB.velocity.y, 0);
        }
    }
    void HeadTurn()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));
        camera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"),0 , 0));
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump") && IsGrounded)
        {
            RB.velocity += transform.up * JumpSpeed;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            print(other.gameObject.name);
            IsGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            IsGrounded = false;
        }
    }
}

