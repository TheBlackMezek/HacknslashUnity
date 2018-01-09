using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed = 10.0f;
    public float fallAccel = 10.0f;
    public float rotationSpeed = 2.0f;
    public LayerMask playerMask;

    private CharacterController controller;
    private Transform camTrans;
    private float fallSpeed = 0;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        camTrans = transform.Find("Main Camera");
    }

    // Update is called once per frame
    private void Update () {

        Vector3 moveVec = transform.forward * Input.GetAxis("Vertical");
        moveVec += transform.right * Input.GetAxis("Horizontal");
        moveVec *= moveSpeed * Time.deltaTime;

        controller.Move(moveVec);

        
        transform.Rotate(Quaternion.Euler(0,
                                          Input.GetAxis("Mouse X") * rotationSpeed,
                                          0).eulerAngles);
    }

    private void FixedUpdate()
    {
        //RaycastHit hit;
        //
        //if(Physics.Raycast(transform.position, -transform.up, out hit, playerMask))
        //{
        //    transform.position = hit.point;
        //}
        if(!controller.isGrounded)
        {
            fallSpeed += fallAccel * Time.deltaTime;
            Vector3 fallVec = -Vector3.up * fallSpeed * Time.deltaTime;
            controller.Move(fallVec);
        }
        else
        {
            fallSpeed = 0;
        }
    }
}
