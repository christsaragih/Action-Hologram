using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentText : MonoBehaviour
{
    private Comment comment;
    public float timeComment=0;
    public TextMesh text;
    public int badWords,goodWords;
    public float AnimationTextTime;
    public Sprite[] spriteFeedback;
    public GameObject bgFeedback;

    public string[] GoodComment = new string[]
       {
        "Nice Shoot","Amazing Dude","Realy Dope!!!","Stay Awesome","You're My Man!!","Crazy Shoot"
       };
    public string[] BadComment = new string[]
      {
        "Try Later","Keep The Spirit","Maybe Next Time","Go Away B*tc*","Loooser!! ","Stupid!!"
      };
    // Use this for initialization
    void Start()
    {
        text = GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeComment > AnimationTextTime)
        {
            text.text = "";
            bgFeedback.GetComponent<SpriteRenderer>().sprite = null;
        }
        else {
            timeComment += Time.deltaTime;
        }
    }
    public void SetComment(int shoot)
    {
        timeComment = 0;
        System.Random R = new System.Random();
        if (shoot > 0)
        {
            
            text.text =  GoodComment[goodWords];
            text.color = Color.white;
            if (goodWords < GoodComment.Length) {
                goodWords++;
                badWords = 0;
                bgFeedback.GetComponent<SpriteRenderer>().sprite = spriteFeedback[1];
            }
        }
        else
        {
            bgFeedback.GetComponent<SpriteRenderer>().sprite = spriteFeedback[0];
            text.text =  BadComment[badWords];
            text.color = Color.black;
            if (badWords < BadComment.Length)
            {
                goodWords = 0;
                badWords++;
            }
        }
        


       
    }
}
