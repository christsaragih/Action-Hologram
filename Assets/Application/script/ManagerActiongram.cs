using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Condition
{
    None, ShowCommand, Move, Resize, Play, Color
}
public class ManagerActiongram : MonoBehaviour
{
    //Item Button
    private ButtonHandle buttonProperty;
    private ColorHandle collorProperty;
    public HologramObject hologramObject;
    #region Object Animation
    [Header("Object Animation")]
    public GameObject itemObjectImplementHologramObject;
    public bool placing = false;//For Movement Object
    public bool DrawMeshFirst;
    public Condition condition;
    #endregion

    #region setup arah buttonProperty.Panel
    public Transform kiri, kanan, depan, belakang;
    float[] distanceArahFromCamera = new float[4];//nilai yangsudah di sorting
    float[] distanceTemp = new float[4];//tempat menyimpan nilai yang belum disorting
    #endregion

    #region resize
    public float minX, maxX, percent, distance = 30;
    float originalX;

    #endregion

    public ObjectAnimation[] objectAnimation;

    void Start()
    {
        if (itemObjectImplementHologramObject.GetComponent<HologramObject>() != null)
        {
            hologramObject = itemObjectImplementHologramObject.GetComponent<HologramObject>();
            Debug.Log("Ready To Play " + hologramObject);
        }
        else {
            Debug.Log("Item ini tidak memiliki " + hologramObject);
        }
        
        collorProperty = this.GetComponent<ColorHandle>();
        buttonProperty = this.GetComponent<ButtonHandle>();
        placing = true;
        condition = Condition.Move;
        SpatialMapping.Instance.DrawVisualMeshes = DrawMeshFirst;
        this.name = "Command " + transform.parent.name;
        distance = (maxX - minX);

    }


    public void PlayAnim()
    {
        if (hologramObject != null)
        {
            if (condition != Condition.Play)
            {
                condition = Condition.Play;

            }
            hologramObject.PlayAnimation();


        }
        else
        {
            Debug.Log("Benda ini tidak ada animation");
        }

    }

    public void StopAnim()
    {
        if (hologramObject != null)
        {

            hologramObject.StopAnimation();
            condition = Condition.ShowCommand;
        }
        else
        {
            Debug.Log("Benda ini tidak ada animation");
        }
    }

    //Memunculkan command box atau logic ketika benda ditekan
    public void ClickObject()
    {

        switch (condition)
        {
            case Condition.None:
                condition = Condition.ShowCommand;
                break;
            case Condition.Move:
                condition = Condition.None;
                break;
            case Condition.ShowCommand:
                condition = Condition.None;
                break;
            case Condition.Resize:
                condition = Condition.ShowCommand;
                break;

            case Condition.Play:
                PlayAnim();
                Debug.Log("Start animation...  ");
                condition = Condition.None;
                break;
        }

        if (placing)
        {
            Move();
        }


    }

    //Set kondisi menu
    void ShowCommandCondition()
    {
        if (buttonProperty != null)
        {
            buttonProperty.ShowCommandCondition(condition);
        }

        if (collorProperty != null)
        {
            collorProperty.ShowCommandCondition(condition);
        }


    }

    #region MethodLogic

    public void ShowChangeColor()
    {
        condition = Condition.Color;
    }

    public void ChangeColor(int number)
    {
        hologramObject.ChangeColor(number);
    }

    // MovementLogic
    public void Move()
    {


        // On each Select gesture, toggle whether the user is in placing mode.
        placing = !placing;

        // If the user is in placing mode, display the spatial mapping mesh.
        if (placing)
        {
            condition = Condition.Move;
            buttonProperty.Panel.transform.parent = this.transform;
            SpatialMapping.Instance.DrawVisualMeshes = true;

        }
        // If the user is not in placing mode, hide the spatial mapping mesh.
        else
        {

            condition = Condition.None;
            buttonProperty.Panel.StayALone();
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }
    public void ShowResize()
    {
        condition = Condition.Resize;
    }
    //rotation Logic
    public void Rotate(string rotate, float speed)
    {

        speed = (speed * 14) + 1;
        if (rotate == "left")
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 15 * speed, Space.World);
        }
        else
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 15 * speed, Space.World);
        }
    }

    void PlacingLogic()
    {

        // If the user is in placing mode,
        // update the placement to match the user's gaze.

        if (placing)
        {
            // Do a raycast into the world that will only hit the Spatial Mapping mesh.
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo,
                30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                // Move this object's parent object to
                // where the raycast hit the Spatial Mapping mesh.

                this.transform.position = hitInfo.point;

                // Rotate this object's parent object to face the user.
                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;

            }
        }
    }

    //Size Logic
    float onHoldReduce;//Variabel untuk mengurangi disrance
    public bool SizeUp(bool isHold, float resize = 1)
    {
        Debug.Log("SIZE UP");
        setFullSize = true;
        if (MinSize == 0)
        {
            MinSize = buttonProperty.pivot.transform.localScale.x;
        }
        Vector3 SizeThis = buttonProperty.pivot.transform.localScale;
        onHoldReduce = 40;
        if (isHold)
        {
            onHoldReduce = 40;

        }
        else
        {
            onHoldReduce = 1;
        }

        buttonProperty.pivot.transform.localScale = new Vector3(SizeThis.x + (SizeThis.x *= 0.001f), SizeThis.y + (SizeThis.y *= 0.001f), SizeThis.z + (SizeThis.z *= 0.001f));


        bool xBool = false;
        if (buttonProperty.pivot.transform.localScale.x < MaxSize && buttonProperty.pivot.transform.localScale.x > MinSize)
        {
            //buttonProperty.pivot.transform.localScale = new Vector3(SizeThis.x *= 0.1f, SizeThis.y *= 0.1f, SizeThis.z *= 0.1f);
            xBool = true;
        }
        else
        {

            xBool = false;
        }

        return xBool;
    }
    public void SizeDown(bool isHold)
    {
        if (isHold)
        {

            onHoldReduce = 40;

        }
        else
        {

            onHoldReduce = 1;
        }

        Vector3 SizeThis = buttonProperty.pivot.transform.localScale;
        buttonProperty.pivot.transform.localScale = new Vector3(SizeThis.x - (SizeThis.x *= 0.001f), SizeThis.y - (SizeThis.y *= 0.001f), SizeThis.z - (SizeThis.z *= 0.001f));

    }
    void SizeLogic()
    {
        percent = (buttonProperty.pivot.transform.lossyScale.x - minX) / distance;
    }

    private Vector3 sumbuRotate;
    private string ArahX;

    //Setup buttonProperty.Panel
    void HitungArah()
    {
        distanceArahFromCamera[0] = Vector3.Distance(Camera.main.transform.position, kiri.transform.position);
        distanceArahFromCamera[1] = Vector3.Distance(Camera.main.transform.position, kanan.transform.position);
        distanceArahFromCamera[2] = Vector3.Distance(Camera.main.transform.position, depan.transform.position);
        distanceArahFromCamera[3] = Vector3.Distance(Camera.main.transform.position, belakang.transform.position);

        distanceTemp[0] = Vector3.Distance(Camera.main.transform.position, kiri.transform.position);
        distanceTemp[1] = Vector3.Distance(Camera.main.transform.position, kanan.transform.position);
        distanceTemp[2] = Vector3.Distance(Camera.main.transform.position, depan.transform.position);
        distanceTemp[3] = Vector3.Distance(Camera.main.transform.position, belakang.transform.position);


        Array.Sort(distanceArahFromCamera);


        if (distanceArahFromCamera[0] + "" == distanceTemp[0] + "")
        {
            //kiri
            buttonProperty.Panel.transform.position = kiri.transform.position;
            buttonProperty.Panel.transform.eulerAngles = kiri.transform.eulerAngles;


        }
        else if (distanceArahFromCamera[0] + "" == distanceTemp[1] + "")
        {

            buttonProperty.Panel.transform.position = kanan.transform.position;
            buttonProperty.Panel.transform.eulerAngles = kanan.transform.eulerAngles;
            //kanan

        }
        else if (distanceArahFromCamera[0] + "" == distanceTemp[2] + "")
        {

            //depan
            buttonProperty.Panel.transform.position = depan.transform.position;
            buttonProperty.Panel.transform.eulerAngles = depan.transform.eulerAngles;
        }
        else if (distanceArahFromCamera[0] + "" == distanceTemp[3] + "")
        {

            //belakang
            buttonProperty.Panel.transform.position = belakang.transform.position;
            buttonProperty.Panel.transform.eulerAngles = belakang.transform.eulerAngles;
        }

    }
    #endregion

    #region Speech Command
    bool setFullSize, setHalfSize;
    public void FullSize()
    {
        if (condition != Condition.None)
        {
            setFullSize = true;
            setHalfSize = false;
        }

    }
    public void HalfSize()
    {
        if (condition != Condition.None)
        {
            setFullSize = false;
            setHalfSize = true;
        }
    }

    public void HideCommand()
    {
        condition = Condition.None;
    }
    public void ShowCommand()
    {
        condition = Condition.ShowCommand;
    }
    #endregion
    //
    public float MaxSize;
    public float MinSize;
    // Update is called once per frame

    void Update()
    {
        ShowCommandCondition();
        PlacingLogic();
        SizeLogic();
        HitungArah();
        if (setFullSize)
        {
            condition = Condition.Resize;
            if (!SizeUp(true, 8f))
            {
                setFullSize = false;


            }
            else
            {
                buttonProperty.pivot.transform.position = Vector3.MoveTowards(buttonProperty.pivot.transform.position, new Vector3(buttonProperty.pivot.transform.position.x, Camera.main.transform.position.y + 0.14f, buttonProperty.pivot.transform.position.z), Time.deltaTime * 1f); // atur ketinggian benda
            }

        }
        if (setHalfSize)
        {

            condition = Condition.Resize;
            if (!SizeUp(true, -8f))
            {
                setHalfSize = false;


            }

        }
        if (Input.GetKey(KeyCode.E))
        {
            HalfSize();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            FullSize();
        }
        if (Input.GetKey(KeyCode.W))
        {
            condition = Condition.Resize;
            SizeUp(true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            condition = Condition.Resize;
            SizeDown(true);
        }


        if (HandsTrackingManager.Instance.FocusedGameObject == this.gameObject)
        {
            if (sumbuRotate.Equals(new Vector3(0, 0, 0)))
            {
                sumbuRotate = HandsTrackingManager.Instance.pos;
                ArahX = HandsTrackingManager.Instance.GetDirectionRotate(true, sumbuRotate.x, sumbuRotate.y, sumbuRotate.z)[0];
            }

            if (Vector3.Distance(sumbuRotate, HandsTrackingManager.Instance.pos) > 0.08f)//jika ada jarak perpinda
            {
                if ((HandsTrackingManager.Instance.GetDirectionRotate(false)[0] == "kanan" || HandsTrackingManager.Instance.GetDirectionRotate(false)[1] == "kanan") && ArahX == "kanan")
                {
                    Rotate("right", Vector3.Distance(sumbuRotate, HandsTrackingManager.Instance.pos));
                }
                else if ((HandsTrackingManager.Instance.GetDirectionRotate(false)[0] == "kiri" || HandsTrackingManager.Instance.GetDirectionRotate(false)[1] == "kiri") && ArahX == "kiri")
                {
                    Rotate("left", Vector3.Distance(sumbuRotate, HandsTrackingManager.Instance.pos));
                }
                else
                {
                    ArahX = HandsTrackingManager.Instance.GetDirectionRotate(false)[0];
                }
            }

        }
        else
        {
            sumbuRotate = new Vector3(0, 0, 0);
            ArahX = "";

        }
    }
}
