using UnityEngine;
using UnityEngine.VR.WSA.Input;
public enum ButtonPress
{
    none, rotate, upsize, downsize, move
}
public class GazeGestureManager : Singleton<GazeGestureManager>
{
  
    public static GazeGestureManager Instance { get; private set; }

    // Represents the hologram that is currently being gazed at.
    public GameObject FocusedObject;
    Vector3 myRotate;
    GestureRecognizer recognizer;
    [HideInInspector]
    public ButtonPress buttonHolds;
    // Use this for initialization
    bool updateFocusedObject = true;
    void Start()
    {
        FocusedObject = null;
        Instance = this;
        myRotate = this.transform.localRotation.eulerAngles;
        // Set up a GestureRecognizer to detect Select gestures.
        recognizer = new GestureRecognizer();
 
        recognizer.TappedEvent += (source, tapCount, ray) =>
        {
            //print("Touch  " + FocusedObject.name);
            // Send an OnSelect message to the focused object and its ancestors.
            if (FocusedObject != null)
            {
                if (FocusedObject.GetComponent<ManagerActiongram>() != null)
                {

                    FocusedObject.GetComponent<ManagerActiongram>().ClickObject();
                }
                else if (FocusedObject.GetComponent<PannelButton>() != null&& FocusedObject.GetComponent<KeyboardItem>()==null)
                {

                    FocusedObject.GetComponent<PannelButton>().Touch(FocusedObject.name);
                }
                else if (FocusedObject.GetComponent<PannelButton>() != null && FocusedObject.GetComponent<KeyboardItem>() != null)
                {

                    FocusedObject.GetComponent<KeyboardItem>().Input();
                }


            }
        };
        recognizer.HoldStartedEvent += (source, ray) =>
        {
            print("Hold Start " + FocusedObject.name);
            if (FocusedObject != null)
            {
                updateFocusedObject = false;
               
                if (FocusedObject.GetComponent<PannelButton>() != null)
                {

                    FocusedObject.GetComponent<PannelButton>().HoldStart(FocusedObject.name);
                }
                else if (FocusedObject != null)
                {
                    if (FocusedObject.GetComponent<ObjectItem>() != null)
                    {
                        FocusedObject.GetComponent<ObjectItem>().GenerateObject();
                    }

                }
            }
        };
        recognizer.HoldCompletedEvent += (source, ray) =>
        {
             
            print("Hold Completed " + FocusedObject.name);
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                if (FocusedObject.GetComponent<PannelButton>() != null)
                {
                    FocusedObject.GetComponent<PannelButton>().HoldEnd(FocusedObject.name);
                }
            }
        };
        recognizer.HoldCanceledEvent += (source, ray) =>
        {
           
            print("Hold Canceled " + FocusedObject.name);
            if (FocusedObject != null)
            {
                updateFocusedObject = true;
                if (FocusedObject.GetComponent<PannelButton>() != null)
                {
                    FocusedObject.GetComponent<PannelButton>().HoldEnd(FocusedObject.name);
                }
            }
        };
         
        recognizer.StartCapturingGestures();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!updateFocusedObject)
        {
            return;
        }
        else
        {
            if (FocusedObject != null)
            {
                if (FocusedObject.GetComponent<ObjectItem>())
                {
                    FocusedObject.GetComponent<ObjectItem>().Select();

                }

            }
        }
        // Figure out which hologram is focused this frame.
        GameObject oldFocusObject = FocusedObject;

        // Do a raycast into the world based on the user's
        // head position and orientation.
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            // If the raycast hit a hologram, use that as the focused object.
            FocusedObject = hitInfo.collider.gameObject;
        }
        else
        {
            // If the raycast did not hit a hologram, clear the focused object.
            FocusedObject = null;
        }


        // start detecting fresh gestures again.
        if (FocusedObject != oldFocusObject)
        {
            recognizer.CancelGestures();
            recognizer.StartCapturingGestures();
        }
    }
}
