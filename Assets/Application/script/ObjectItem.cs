using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectItem : MonoBehaviour {
    public GameObject Items;
  public  Vector3 myTrans;
   public int timeToSelect = 0;
	// Use this for initialization
	void Awake () {
        myTrans = this.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        timeToSelect--;
        if (timeToSelect < 0)
        {
            this.transform.localScale = new Vector3(myTrans.x , myTrans.y,myTrans.z );
        }
    }
    public void GenerateObject() {
        Instantiate(Items, this.transform.position,Quaternion.identity);
    }
    public void Select() {
 
        this.transform.localScale = new Vector3(myTrans.x+(myTrans.x/5), myTrans.y+ (myTrans.y / 5), myTrans.z+ (myTrans.z / 5));
    }
}
