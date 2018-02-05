using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHandle : MonoBehaviour, PropertyActionGram
{
    public Transform LogoKotak;
    public Transform pSizebar;
    public Transform pPlay;
    public Transform pStop;
    public PanelArea Panel;
    public Pivot pivot;
    public PannelButton pMove;
    public PannelButton pResize;

    public void ShowCommandCondition(Condition condition)
    {
        switch (condition)
        {

            case Condition.None:
                pMove.gameObject.active = false;
                pStop.gameObject.active = false;
                pPlay.gameObject.active = false;
                pSizebar.gameObject.active = false;
                pResize.gameObject.active = false;
                LogoKotak.gameObject.active = false;

              

                this.transform.parent = null;
                break;
            case Condition.ShowCommand:
                pStop.gameObject.active = false;
                pPlay.gameObject.active = true;
                this.transform.parent = null;
                LogoKotak.gameObject.active = true;
                pMove.gameObject.active = true;
                pResize.gameObject.active = true;
                pSizebar.gameObject.active = false;

               
                break;
            case Condition.Move:
                pStop.gameObject.active = false;
                this.transform.parent = null;
                pPlay.gameObject.active = false;
                pMove.gameObject.active = false;
                pSizebar.gameObject.active = false;
                pResize.gameObject.active = false;

              
                break;
            case Condition.Resize:
                pStop.gameObject.active = false;
                pPlay.gameObject.active = true;
                pMove.gameObject.active = true;
                pPlay.gameObject.active = true;
                pResize.gameObject.active = true;
                pSizebar.gameObject.active = true;
                LogoKotak.gameObject.active = true;
                this.transform.parent = pivot.transform;

                
                break;


            case Condition.Play:
                pStop.gameObject.active = true;
                pPlay.gameObject.active = false;
                this.transform.parent = null;
                pMove.gameObject.active = false;
                pResize.gameObject.active = false;
                pSizebar.gameObject.active = false;
                LogoKotak.gameObject.active = false;
               

                break;

            case Condition.Color:
                pStop.gameObject.active = true;
                pPlay.gameObject.active = true;
                this.transform.parent = null;
                pMove.gameObject.active = true;
                pResize.gameObject.active = true;
                pSizebar.gameObject.active = false;
                LogoKotak.gameObject.active = true;
                
                break;
        }
    }

    // Use this for initialization
    void Start () {

        if (pPlay == null)
        {
            pPlay = new GameObject().transform;
            Debug.LogError(this.name + " Not Have pPlay");
        }
        if (pStop == null)
        {
            pStop = new GameObject().transform;
            Debug.LogError(this.name + " Not Have pStop");
        }
        if (pSizebar == null)
        {
            pSizebar = new GameObject().transform;
            Debug.LogError(this.name + " Not Have pStop");
        }
        if (LogoKotak == null)
        {
            LogoKotak = new GameObject().transform;
            Debug.LogError(this.name + " Not Have LogoKotak");
        }
        pivot.transform.localScale = this.transform.localScale;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
