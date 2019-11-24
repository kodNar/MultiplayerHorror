using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private float rotX;
    private float RotSpeed = 6f;
    private float rotY;

    private Camera myCamera;

    public CameraController(Camera myCamera)
    {
        this.myCamera = myCamera;
    }

    // Start is called before the first frame update
    void Start()
    {
        myCamera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse X")*RotSpeed;
        rotY += Input.GetAxis("Mouse Y") * RotSpeed;
        rotY = Mathf.Clamp(rotY, -90f, 90f);
        myCamera.transform.localRotation = Quaternion.Euler(-rotY, 0f, 0f);
        
    }
}
