using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControl : MonoBehaviour {
    public List<string> KeyboardHasil;
    public TextMesh output;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //define all object will show on keyboard
    public void InputWords(string variabel) {
        if (variabel == "Space") {
            variabel = " ";
        }
        KeyboardHasil.Add(variabel);
        output.text = "";
        foreach (var item in KeyboardHasil)
        {
            output.text += item;
        }
    }
}
