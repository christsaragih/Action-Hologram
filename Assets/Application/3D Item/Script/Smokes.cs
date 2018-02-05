using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Smokes : MonoBehaviour
{
    float time = 7;
    bool isOnTheAir;
    public void OnTheAir(Vector3 v) {
        this.transform.position = v;
        isOnTheAir = true;
        Debug.Log("Smoke On The Air");
    }
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0&&isOnTheAir)
        {
            Destroy(this.gameObject);
        }
    }

} 
