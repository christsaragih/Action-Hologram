using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndoorHoop : MonoBehaviour {
    // Update is called once per frame
	void Update () {
        if (CommonStatic.WasUpdate) {
            this.transform.position = new Vector3(this.transform.position.x, CommonStatic.floorYPosition, this.transform.position.z);
            GameObject G = GameObject.Find("spatial");
            if (G != null) {
                Destroy(G);
            }
        }
        
	}
}
