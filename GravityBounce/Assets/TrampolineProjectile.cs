using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrampolineProjectile : MonoBehaviour
{
    public float speed;
    public GameObject trampoline;
    public float offsetValue;
    private GameObject AttachedObject;

    private GameObject GM;
    private Corner[] corners = new Corner[4];
    private Vector3 moveDist;
    public RaycastHit hit;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindWithTag("GM");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision col)
    {
        
        /*GameObject tempTramp = Instantiate(trampoline, hit.point + hit.normal.normalized * offsetValue, Quaternion.identity);
        tempTramp.transform.up = hit.normal;
        AttachedObject = col.gameObject;
        //CheckPosition();
        //tempTramp.transform.position += moveDist;
        //col.GetContact(0).point + col.GetContact(0).normal.normalized * offsetValue
       // Debug.Log(hit.point + hit.normal.normalized * offsetValue);
        tempTramp.transform.SetParent(col.gameObject.transform);
        GM.GetComponent<GM>().trampolines.Add(tempTramp);*/
        Destroy(gameObject);
        
    
    }
    
    

    void CheckPosition()
    {
        Vector3 tempMoveDist;
        foreach (Corner c in corners)
        {
            if (AttachedObject.GetComponent<Collider>().bounds.Contains(c.cornerPos) == false)
            {
                if (c.cornerDirection == Corner.CornerDirection.BottomLeft)
                {
                    tempMoveDist = AttachedObject.GetComponent<Collider>().ClosestPointOnBounds(c.cornerPos) - c.cornerPos;
                    
                }
            }

        }
    }

    Corner[] AssignCorners(GameObject trampoline, Vector3 normal)
    {
        Collider trampCollider = trampoline.GetComponent<Collider>();
        Bounds bounds = trampCollider.bounds;

        float minX = trampoline.transform.position.x - trampoline.transform.localScale.x * bounds.size.x * 0.5f;
        float maxX = trampoline.transform.position.x + trampoline.transform.localScale.x * bounds.size.x * 0.5f;
        float minY = trampoline.transform.position.y - trampoline.transform.localScale.x * bounds.size.y * 0.5f;
        float maxY = trampoline.transform.position.y + trampoline.transform.localScale.x * bounds.size.y * 0.5f;
        
        Vector3 TR = new Vector3(maxX,maxY,trampoline.transform.position.z);
        Vector3 TL = new Vector3(minX, maxY, trampoline.transform.position.z);
        
        Corner topRight = new Corner(TR, Corner.CornerDirection.TopRight);
        return new Corner[2];

    }

    struct Corner
    {
        public Vector3 cornerPos;
        public CornerDirection cornerDirection;


        public enum CornerDirection
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight
        };

        public Corner(Vector3 cornerPos, CornerDirection cornerDirection)
        {
            this.cornerPos = cornerPos;
            this.cornerDirection = cornerDirection;
            
        }
        
        
    }
}
