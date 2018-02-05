using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTutorialFollow : MonoBehaviour {
    public Transform target,model;
    public float angleDistanceFromCamera;
    public Vector3 angleCam;
    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        transform.LookAt(target);
        angleCam = transform.eulerAngles;
          angleDistanceFromCamera = angleCam.y - Camera.main.transform.eulerAngles.y;
        if (angleDistanceFromCamera < 0) {
            angleDistanceFromCamera *= -1;
        }
        if (angleDistanceFromCamera < 11)
        {
            model.gameObject.active = false;
        }
        else {
            model.gameObject.active = true;
        }
    }
}
