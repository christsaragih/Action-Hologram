using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UntiTest : MonoBehaviour {
    bool Succes;
    public Transform[] ObjectGenerated;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < ObjectGenerated.Length; i++)
        {
            Instantiate(ObjectGenerated[i]);
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Succes) {
            for (int i = 0; i < ObjectGenerated.Length; i++)
            {
                Destroy(ObjectGenerated[i]);
            }
            Succes = false;
        }
	}
}
