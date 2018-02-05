using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpatialSort : MonoBehaviour
{
    public float[] allSpatial;
 
    static SpatialSort myInstance;
    public static SpatialSort Instance { get { return myInstance; } }
    void Start()
    {
        myInstance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > 0 && allSpatial[0] == 0)
        {
            allSpatial = new float[transform.childCount];
            for (int i = 0; i < transform.childCount; ++i)
            {
                allSpatial[i] = transform.GetChild(i).position.y;
 
            }

           Array.Sort(allSpatial);
            
        }
        
    }
}
