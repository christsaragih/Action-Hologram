using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PannelButton : MonoBehaviour
{

    public ManagerActiongram manager;

    // Use this for initialization
   
    // Update is called once per frame
    void Update()
    {
        HoldSizeLogic();
    }

    #region Logic Single Touch
    //temp method
    public void Touch(string name)
    {
        print("Pannel Button With name ( " + name + " ) Touched");
        switch (name)//sesuaikan dengan nama objek
        {
            case "P move":
                MoveStart();
                break;
            case "plus":
                SizeUp();
                break;
            case "minus":
                SizeDown();
                break;
            case "P resize":
                ShowResize();
                break;
            case "color":
                manager.ShowChangeColor();
                break;
            case "right":

                break;
            case "left":

                break;
            case "P play":
                manager.PlayAnim();
                break;
            case "P Stop":
                manager.StopAnim();
                break;
            case "color1":
                manager.ChangeColor(0);
                break;

            case "color2":
                manager.ChangeColor(1);
                break;

        }
    }

    //Starting logic
    void MoveStart()
    {
        manager.Move();
    }
    void SizeUp()
    {
        manager.SizeUp(false);
    }
    void SizeDown()
    {
        manager.SizeDown(false);
    }
    void ShowResize()
    {
        manager.ShowResize();
    }

    #endregion
    
    #region HoldTouch
    [HideInInspector]
    public bool holdSizeUp, holdSizeDown, holdRight, holdLeft;

    void HoldSizeLogic()
    {//dipanggil di method update
        if (holdSizeDown)
        {
            manager.SizeDown(holdSizeDown);//Selama di hold maka akan mengecilkan benda tersebut
        }
        if (holdSizeUp)
        {
            manager.SizeUp(holdSizeUp);//Selama di hold maka akan mengecilkan benda tersebut
        }
      
    }

    public void HoldStart(string name)
    {

        switch (name)
        {
            case "plus":
                holdSizeUp = true;
                break;
            case "minus":
                holdSizeDown = true;
                break;
            case "right":
                holdRight = true;
                break;
            case "left":
                holdLeft = true;
                break;
        }
    }

    public void HoldEnd(string name)
    {
        switch (name)
        {
            case "plus":
                holdSizeUp = false;
                break;
            case "minus":
                holdSizeDown = false;
                break;
            case "right":
                holdRight = false;
                break;
            case "left":
                holdLeft = false;
                break;
        }
    }

    #endregion

}
