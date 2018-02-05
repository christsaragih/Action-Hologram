using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pivot : MonoBehaviour {
    public Transform FollowPannel;
   public ManagerActiongram manager;
	// Use this for initialization
	void Start () {
    
        this.name = "Pivot " + transform.parent.name;
    }
	
	// Update is called once per frame
	void Update () {
        if (manager.condition != Condition.Resize) {
            this.transform.position = FollowPannel.position;
        }
        
       
	}
}
