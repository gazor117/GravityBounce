using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGun : MonoBehaviour
{
    public float gravityForce = 9.8f;

    public string gravityDirection;

    private float horizonatalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {
        gravityForce = 9.8f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gravityDirection = "Up";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gravityDirection = "Down";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //gravityDirection = "Left";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            //gravityDirection = "Right";
        }
    }

   
}
