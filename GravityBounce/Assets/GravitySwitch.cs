using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{
    private GravityGun GG;

    public float gravityForce;

    private string gravityDirection;
    [Range(0.0f,1.0f)]
    public float gravityModifier;

    private bool insideCollider;
    // Start is called before the first frame update
    void Start()
    {
        GG = GameObject.FindWithTag("Player").GetComponent<GravityGun>();
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider col)
    {
        //CheckColliderBounds(col.gameObject);
        if (col.CompareTag("GravityEffected"))
        {
            gravityDirection = GG.gravityDirection;
            Rigidbody rb = col.GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.velocity = gravityForce * GravityChange(gravityDirection, col.gameObject) * 1000/rb.mass * gravityModifier;
//            Debug.Log(gravityForce);

        }
    }
    
    
    Vector3 GravityChange(string Direction, GameObject col)
    {
        Vector3 direction = Vector3.zero;
        if (Direction == "Up")
        {
            direction = col.transform.up;
        }

        if (Direction == "Down")
        {
            direction = -col.transform.up;
        }

        if (Direction == "Left")
        {
            direction = -col.transform.right;
        }

        if (Direction == "Right")
        {
            direction = col.transform.right;
        }

        return direction;
    }

    void CheckColliderBounds(GameObject col)
    {
        Collider collider = GetComponent<Collider>();
        Bounds bounds = collider.bounds;

        if (bounds.Contains(col.transform.position) == false)
        {
            insideCollider = false;
        }
        else
        {
            insideCollider = true;
        }
        
        
    }
}
