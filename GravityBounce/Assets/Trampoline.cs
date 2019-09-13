using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Vector3 trampolineDirection;
    public float trampolineForce;
    private Vector3 tempVelocity;
    private float maxSpeed;
    private float lifeTime = 0;

    private Rigidbody playerRB;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime++;
    }
    
    private void OnTriggerEnter(Collider col)
    {
        //playerRB = col.gameObject.GetComponent<Rigidbody>();
        //trampolineDirection = col.gameObject.transform.up.normalized;
        //Debug.Log(trampolineDirection * Mathf.Abs(rb.velocity.y) * trampolineForce);
        //ySpeed = Mathf.Abs(rb.velocity.y);
        //tempVelocity = playerRB.velocity;
//        Debug.Log(tempVelocity);
    }
    
    private void OnCollisionEnter(Collision col)
    {        
//        Debug.Log("hit");
        if (col.gameObject.CompareTag("Player"))
        {
//            Debug.Log("hit");
            playerRB = col.gameObject.GetComponent<Rigidbody>();
            //Vector3 temp = Vector3.Scale(trampolineDirection, - playerVelocity);
            //trampolineDirection = col.gameObject.transform.up.normalized;
            float playerVelocity = Mathf.Clamp(tempVelocity.magnitude,0, maxSpeed);
           playerRB.AddForce(gameObject.transform.up * /*tempVelocity.magnitude*/  trampolineForce * Time.deltaTime, ForceMode.Impulse);
//            Debug.Log(gameObject.transform.up * /*tempVelocity.magnitude*/  trampolineForce);
             
        }
        else if (col.gameObject.CompareTag("Ground") && col.gameObject.GetComponent<Trampoline>() != null)
        {
            Debug.Log("Interacted");
            //Destroy(col.gameObject);
        }
        {
             
        }
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Ground") )
        {
            Debug.Log("Interacted");
            //Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Ground") && col.gameObject.GetComponent<Trampoline>() != null )
        {
            if (this.lifeTime > col.GetComponent<Trampoline>().lifeTime)
            {
                Destroy(col.gameObject);              
            }
            else
            {
                Destroy(gameObject);
            }
            
        }                  
    }
}
