using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(camera.GetComponent<CameraController>().currentXRotation, camera.GetComponent<CameraController>().currentYRotation ,0);
    }
}
