using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCreate : MonoBehaviour {
    public float timeDie;
	// Update is called once per frame
	void Update () {
        timeDie -= Time.deltaTime;
        if (timeDie <= 0) {
            Destroy(this.gameObject);
        }
	}
}
