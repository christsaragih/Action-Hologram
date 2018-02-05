using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
    public SoundCreate Sfx_drible, Sfx_rim, Sfx_swoosh, sfx_yeayy;

    static SoundManager myins;
    public static SoundManager Instance { get { return myins; } }
    // Use this for initialization
    void Start()
    {
        myins = this;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void PlaySoundsfx_yeayy(Transform parent)
    {
        Instantiate(sfx_yeayy, parent.position, Quaternion.identity);
    }
    public void PlaySoundDrible(Transform parent)
    {
        Instantiate(Sfx_drible, parent.position, Quaternion.identity);
    }
    public void PlaySoundRim(Transform parent)
    {    Instantiate(Sfx_rim, parent.position, Quaternion.identity);
       
    }
    public void PlaySoundSwoosh(Transform parent)
    {
   Instantiate(sfx_yeayy, parent.position, Quaternion.identity);
            Instantiate(Sfx_swoosh, parent.position, Quaternion.identity);
        
    }
}

