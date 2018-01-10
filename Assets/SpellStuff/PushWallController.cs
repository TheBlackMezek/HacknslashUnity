using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushWallController : MonoBehaviour {

    public float moveSpeed = 10.0f;
    public float growSpeed = 1.0f;
    public float pushForce = 10.0f;
    public float pushUpForce = 10.0f;




    // Update is called once per frame
    void FixedUpdate () {
        Debug.DrawLine(transform.position, transform.position + transform.forward * 5);
        Vector3 moveVec = transform.forward * moveSpeed * Time.fixedDeltaTime;
        Vector3 growVec = Vector3.one * growSpeed * Time.fixedDeltaTime;
        growVec.z = 0;
        
        transform.position += moveVec;
        transform.localScale += growVec;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.attachedRigidbody)
        {
            Vector3 pushVec = transform.forward;
            pushVec.x *= pushForce;
            pushVec.z *= pushForce;
            pushVec.y += pushUpForce;

            other.attachedRigidbody.AddForce(pushVec, ForceMode.Impulse);
        }
    }

}
