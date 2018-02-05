using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public float size = .02f;
    bool drawGizmo = true;
    void Start()
    {
        drawGizmo = false;
    }
    void OnDrawGizmosSelected()
    {
        if (drawGizmo)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, size);

        }
    }
}