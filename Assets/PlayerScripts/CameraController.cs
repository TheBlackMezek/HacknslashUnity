using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float rotationSpeed = 1.0f;
    public float baseZoom = 10.0f;
    public float zoomSpeed = 10.0f;
    public float verticalLookMin = 10.0f;
    public float verticalLookMax = 60.0f;

    private Transform playerTrans;
    private float mouseYDelta = 0;
    private float zoom;

    // Use this for initialization
    void Start () {
        playerTrans = transform.parent.Find("PlayerBody");
        zoom = baseZoom;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = playerTrans.position;

        transform.Translate(transform.forward * -baseZoom);


        zoom += -Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        mouseYDelta += -Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseYDelta = Mathf.Clamp(mouseYDelta, verticalLookMin, verticalLookMax);

        transform.position = transform.parent.position;
        transform.rotation = Quaternion.Euler(mouseYDelta,
                                              transform.parent.rotation.eulerAngles.y,
                                              transform.parent.rotation.eulerAngles.z);
        transform.position += Vector3.up;
        transform.position += transform.right * (zoom / 10);
        transform.position -= transform.forward * zoom;
    }
}
