using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    //public float rotSpeed;
    public float jumpForce;
    //public float trampolineForce;
    public bool isGrounded;
    private float force;
    private float ySpeed;
    private Vector3 playerVelocity;
    private Vector3 trampolineDirection;
    private Vector3 lookSpeed;
    private float maxSpeed;
    [Range(0.0f,1.0f)]
    public float airDamping;

    public GameObject groundCheckObject;
    public float groundCheckLength;

    public GameObject camera;

  

    

    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //lookSpeed = new Vector3(rotSpeed,rotSpeed,rotSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        var z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (!isGrounded)
        {
            x = x * airDamping;
            z = z * airDamping;
        }
        
        transform.Translate(x, 0, z);

        transform.rotation = Quaternion.Euler(0, camera.GetComponent<CameraController>().currentYRotation ,0);
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(0, jumpForce, 0);
            isGrounded = false;
//            Debug.Log("Jump registered");
        }

        if (Mathf.Abs(rb.velocity.y) <= 0.1f)
        {
            //force = 0.8f;
        }

        if (Mathf.Abs(rb.velocity.y) >= 0.1f)
        {
            //force = 1.2f;
        }
        RaycastHit hit;
        Debug.DrawRay(groundCheckObject.transform.position, groundCheckObject.transform.TransformDirection(-Vector3.up) * groundCheckLength);
        if (Physics.Raycast(groundCheckObject.transform.position,
            groundCheckObject.transform.TransformDirection(-Vector3.up), out hit, groundCheckLength))
        {
            
            if (hit.transform.tag == "Ground" || hit.transform.tag == "GravityEffected" && hit.transform.tag != "Player")
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }
        else
        {
            isGrounded = false;
        }
        //Debug.Log(Mathf.Abs(rb.velocity.y));
    }

    private void OnTriggerEnter(Collider col)
    {
        //trampolineDirection = col.gameObject.transform.up.normalized;
        //Debug.Log(trampolineDirection * Mathf.Abs(rb.velocity.y) * trampolineForce);
//        ySpeed = Mathf.Abs(rb.velocity.y);
        playerVelocity = rb.velocity;
    }

    private void OnCollisionStay(Collision col)
    {
        
        
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("GravityEffected"))
        {
            ContactPoint contact = col.GetContact(0);            //get one point of contact of collision
            if (contact.normal == col.gameObject.transform.up)        //if the normal of the point is equal to the objects up vector
            {                                                        // this ensures player cant jump while stuck on the side of the wall
                //isGrounded = true;
            }
            // isGrounded = true;


            /*Vector3 temp = Vector3.Scale(trampolineDirection, - playerVelocity);
           //trampolineDirection = col.gameObject.transform.up.normalized;
            rb.AddForce(trampolineDirection* playerVelocity.magnitude * trampolineForce);
            Debug.Log(trampolineDirection* playerVelocity.magnitude * trampolineForce);*/
            
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("GravityEffected"))
        {
            //isGrounded = false;
            // IF STUFF BREAKS WITH TRAMPOLINE COULD BE TO DO WITH THIS!!
            /*ContactPoint contact = col.GetContact(0);            //get one point of contact of collision
            if (contact.normal == col.gameObject.transform.up)        //if the normal of the point is equal to the objects up vector
            {                                                        // this ensures player cant jump while stuck on the side of the wall
                isGrounded = false;
            }*/
        }
    }
}
