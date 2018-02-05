using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubuActionGram : MonoBehaviour,HologramObject {
    bool Anim = false;
    public void ChangeColor(int ObjectNumber)
    {
        
    }

    public void PlayAnimation()
    {
        Anim = true;
    }

    public void StopAnimation()
    {
        Anim = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Anim) {
            transform.Rotate(Vector3.right * Time.deltaTime);
        }
        
    }
}
