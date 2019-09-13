using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineGun : MonoBehaviour
{
    public GameObject projectileTrampoline;
    public GameObject trampoline;
    public float offsetValue;
    public GameObject gunBarrel;
    
    public float delay = 2f;

    private bool isShooting;

    private GameObject player;
    private GameObject GM;

    private RaycastHit hit;
    private int layerMask;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        GM = GameObject.FindWithTag("GM");
        cam = GetComponentInChildren<Camera>();
        layerMask = 1 << 10;
    }

    // Update is called once per frame
    void Update()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        if (Input.GetKeyDown(KeyCode.Mouse0) && isShooting == false)
        {
            //Physics.Raycast(ray, out hit, 5000, layerMask);
           // Debug.Log(hit.point);
            StartCoroutine(ShootTrampoline());
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            List<GameObject> trampolinesRef = GM.GetComponent<GM>().trampolines;
            if (trampolinesRef.Count > 0)
            {
                Destroy(trampolinesRef[trampolinesRef.Count - 1]);
                GM.GetComponent<GM>().trampolines.Remove(trampolinesRef[trampolinesRef.Count - 1]);
                
            }
        }
    }

    IEnumerator ShootTrampoline()
    {
        yield return new WaitForSeconds(0.2f);                                //Shoot delay
        isShooting = true;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));            //Shoots a ray from the middle of the screen into the world
        Physics.Raycast(ray, out hit, 5000, layerMask);                            // Checks if ray hit anything
        GameObject tempTramp = Instantiate(trampoline, hit.point + hit.normal.normalized * offsetValue, Quaternion.identity);  //Spawns trampoline on object ray hit
        tempTramp.transform.up = hit.normal;                 //Sets trampoline up vector = to the hit objects normal
        
        //AttachedObject = col.gameObject;
        //CheckPosition();
        //tempTramp.transform.position += moveDist;
        //col.GetContact(0).point + col.GetContact(0).normal.normalized * offsetValue
        // Debug.Log(hit.point + hit.normal.normalized * offsetValue);
        
        tempTramp.transform.SetParent(hit.transform);                    // Set the object the trampoline spawned on as the parent
        GM.GetComponent<GM>().trampolines.Add(tempTramp);                // Adds trampoline to game manager array of trampolines
        
        //Destroy(gameObject);
        //GameObject temp = Instantiate(projectileTrampoline, gunBarrel.transform.position, player.GetComponentInChildren<CameraController>().transform.rotation);
       //GM.GetComponent<GM>().trampolines.Add(temp);
        //temp.GetComponent<TrampolineProjectile>().hit = hit;
        
        yield return new WaitForSeconds(delay);                        //Shoot delay
        isShooting = false;


    }
}
