using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarResize : MonoBehaviour
{

    public ManagerActiongram manager;
    public Transform bar, barMax, barMin;
    float distanceMinMax;//jarak anatara 2 bar
    Vector3 barpos;
    public float BarPercent;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        BarPercent = manager.percent;
        distanceMinMax = barMax.transform.position.x - barMin.transform.position.x;
       // barpos = bar.transform.position;
       // bar.transform.position = new Vector3((BarPercent* distanceMinMax) + barMin.transform.position.x, bar.transform.position.y, bar.transform.position.z);
    }
}