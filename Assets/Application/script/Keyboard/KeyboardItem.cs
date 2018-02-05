using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardItem : MonoBehaviour
{
    TextMesh text;
    public KeyboardControl keyboardControl;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Input()
    {
        keyboardControl.InputWords(text.text);
    }
}
