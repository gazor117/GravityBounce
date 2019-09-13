using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public List<GameObject> trampolines = new List<GameObject>();

    public int maxTrampolines;

    public static bool trampolineLimitHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trampolines.Count > maxTrampolines)
        {
            trampolineLimitHit = true;
        }
        else
        {
            trampolineLimitHit = false;
        }

        if (trampolineLimitHit)
        {
            CheckTrampolineLimit();
        }
    }

    void CheckTrampolineLimit()
    {
        Destroy(trampolines[0]);
        trampolines.Remove(trampolines[0]);
//        Destroy(trampolines[0]);
        trampolineLimitHit = false;
    }
}
