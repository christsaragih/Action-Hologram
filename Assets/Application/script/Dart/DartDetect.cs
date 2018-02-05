using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartDetect : MonoBehaviour
{
    int nilai;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log(coll.name + "");
        if (nilai == 0) {
            nilai = int.Parse(coll.name);
           
        }
        
    }
}
