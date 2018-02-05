using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.name = "Panel " + transform.parent.name;
    }
	
	 
    public void StayALone() {
        transform.parent = null;
    }
}
