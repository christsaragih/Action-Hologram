using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleAnimation : MonoBehaviour
{
    public Animation animation;
    public string Doing;
    public int Play, Stop;
    // Use this for initialization
    void Start()
    {

        animation.Play(ClipIndexToName(0));
        randomTime = r.Next(4, 24);
    }
    System.Random r = new System.Random();
    int randomTime = 0;
    public float time = 0;
    float Sec = 0;
    public float speed;//speed run
    bool PlayAnims=false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayAnim();
        }

    }
    public void PlayAnim()
    {
        if (PlayAnims)
        {
            PlayAnims = false;
            animation.Play(ClipIndexToName(Stop));
        }
        else {
            PlayAnims = true;
            animation.Play(ClipIndexToName(Play));
        }
       
    }
    string ClipIndexToName(int index)
    {
        AnimationClip clip = GetClipByIndex(index);
        if (clip == null)
            return null;
        

        Doing = clip.name;
        return clip.name;
    }
    AnimationClip GetClipByIndex(int index)
    {
        int i = 0;
        foreach (AnimationState animationState in animation)
        {
            Debug.Log(animationState.name);
            if (i == index)
                return animationState.clip;
            i++;
        }
        return null;
    }
}
