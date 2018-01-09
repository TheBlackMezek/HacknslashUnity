using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed = 10.0f;
    public float fallAccel = 10.0f;
    public float jumpImpulse = 30.0f;
    public float rotationSpeed = 2.0f;
    public LayerMask playerMask;

    private CharacterController controller;
    private Transform camTrans;
    //private float fallSpeed = 0;
    private Vector3 velocity = Vector3.zero;

    public bool test;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
        camTrans = transform.Find("Main Camera");
    }
    
    private void Update () {
        
        transform.Rotate(Quaternion.Euler(0,
                                          Input.GetAxis("Mouse X") * rotationSpeed,
                                          0).eulerAngles);
    }

    private void FixedUpdate()
    {
        velocity.x = 0;
        velocity.z = 0;
        velocity += transform.forward * moveSpeed * Input.GetAxis("Vertical");
        velocity += transform.right   * moveSpeed * Input.GetAxis("Horizontal");

        
        if (!controller.isGrounded)
        {
            velocity.y -= fallAccel * Time.fixedDeltaTime;
        }
        else
        {
            velocity.y = 0;
            velocity.y -= fallAccel * Time.fixedDeltaTime;
        }

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            velocity.y += jumpImpulse;
        }


        controller.Move(velocity * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.normal.y < 0 && velocity.y > 0)
        {
            velocity.y = 0;
        }
    }

}
