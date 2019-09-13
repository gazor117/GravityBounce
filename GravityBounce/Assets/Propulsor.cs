using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsor : MonoBehaviour
{
    private Vector3 propulsorDirection;
    public float propulsorForce;
    
    private Rigidbody playerRB;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerRB.AddForce(gameObject.transform.up * propulsorForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}
