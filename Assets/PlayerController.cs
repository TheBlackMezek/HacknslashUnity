using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public float moveSpeed = 10.0f;
    public float rotationSpeed = 2.0f;
    public LayerMask playerMask;

    private CharacterController controller;
    private Transform camTrans;



    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        camTrans = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update () {

        Vector3 moveVec = transform.forward * Input.GetAxis("Vertical");
        moveVec += transform.right * Input.GetAxis("Horizontal");
        moveVec *= moveSpeed * Time.deltaTime;

        controller.Move(moveVec);

        
        transform.Rotate(Quaternion.Euler(0, Input.GetAxis("Mouse X") * rotationSpeed, 0).eulerAngles);
    }
}
