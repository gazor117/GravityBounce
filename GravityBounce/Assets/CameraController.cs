using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lookSensitivity = 5f;
    private float xRotation;
    private float yRotation;
    [HideInInspector] 
    public float currentXRotation;
    [HideInInspector] 
    public float currentYRotation;
    private float xRotationV;
    private float yRotationV;
    public float lookSmoothDamp = 0.1f;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedY * Input.GetAxis("Mouse Y");
        
        //transform.eulerAngles = new Vector3(pitch, yaw, 0);

        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        yRotation += Input.GetAxis("Mouse X") * lookSensitivity;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, lookSmoothDamp);
        currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, lookSmoothDamp);
        
        transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
        
    }
}
