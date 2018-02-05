using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTheCamera : MonoBehaviour
{
    public Transform itemFollow;
    public float distance;
    public float speed;
    bool follow = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(itemFollow.position, transform.position);
        if (distance > this.distance)
        {
            follow = true;

        }
        if (follow)
        {
            transform.position = Vector3.MoveTowards(transform.position, itemFollow.transform.position, speed * distance);
            transform.rotation = itemFollow.rotation;
        }
        if (distance < 0.2f)
        {
            follow = false;

        }

    }
}
