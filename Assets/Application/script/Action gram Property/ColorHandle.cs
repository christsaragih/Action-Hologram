using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Property of action gram
public class ColorHandle : MonoBehaviour, PropertyActionGram
{
    //color

    public Transform ColorItem;
    public Transform pColor;

    public void ColorItemVisible(bool visible) {
        ColorItem.gameObject.active = visible;
    }
    public void pColorVisible(bool visible)
    {
        pColor.gameObject.active = visible;
    }

    public void ShowCommandCondition(Condition condition)
    {
        pColorVisible(true);
        switch (condition)
        {
            case Condition.Color:
                pColorVisible(false);
                ColorItemVisible(true);
                break;
            case Condition.None:
                pColorVisible(false);
                ColorItemVisible(false);
                break;
             
        }
    }



    // Use this for initialization
    void Start () {
        pColorVisible(false);
        ColorItemVisible(false);
        if (pColor == null)
        {
            pColor = new GameObject().transform;
            Debug.LogError(this.gameObject.name + " Not Have PColor");
        }
        if (ColorItem == null)
        {
            ColorItem = new GameObject().transform;
            Debug.LogError(ColorItem.name + " Not Have ColorItem");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
