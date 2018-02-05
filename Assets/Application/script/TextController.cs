using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TextController : MonoBehaviour {
    float time,timeForIntervalWords;
    public float timeInterval;
    public string textWrite;
    public int EnterEveryWords;
    int StringCount;
    public bool isWriting;
    TextMesh textMesh;
    List<string> PartWords;
    public float timeIntervalWords=0;
    [HideInInspector]
    public int countSentence=0;

    // Use this for initialization
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        PartWords = new List<string>();
    }

    int loopChar;
    int textCount;
    // Update is called once per frame
    void Update()
    {

        time += Time.deltaTime;
        if (time > timeInterval|| timeForIntervalWords<timeForIntervalWords)
        {


            if (loopChar < PartWords.Count)
            {
                time = 0;
                if (PartWords[loopChar] == "")
                {
                    PartWords[loopChar] = " ";
                }
                textMesh.text += PartWords[loopChar];
                loopChar++;
                isWriting = true;
            }
            else {
                timeForIntervalWords += Time.deltaTime;
                if (time >= timeIntervalWords) {
                    isWriting = false;
                }
                
            }
        }
        

    }
    public void Settext(string words,int fontSize=32,float timer=0)
    {
        countSentence++;
        if (timer > 0) {
            timeIntervalWords = timer;
        }
//        Debug.Log("Set Text from Game Object " + this.name + " " + words);
        textWrite = words;
       
        isWriting = true;
        if (PartWords.Count > 0) {
            PartWords.Clear();
        }
        
        string[] tempWords = words.Split(' ');
        string[] tempPartWords = null;
        int lengths = 0;
        for (int i = 0; i < tempWords.Length; i++)
        {

            tempPartWords = new string[Regex.Split(tempWords[i], string.Empty).Length];

            tempPartWords = Regex.Split(tempWords[i], string.Empty);
            for (int isd = 0; isd < tempPartWords.Length; isd++)
            {
                lengths++;
               
                PartWords.Add(tempPartWords[isd]);
                 
            }
            if (lengths > EnterEveryWords&&EnterEveryWords>0)
            {
                PartWords.Add("\n");
     
                lengths = 0;
            }
           
        }
        textMesh.text = "";
        loopChar = 0;
       
        {
            textMesh.fontSize = fontSize;
        }
    }
    

}
