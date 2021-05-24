using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound1 : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    public bool firstTime = false;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter()
    {
        if(!alreadyPlayed && firstTime){
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
            Invoke("DoSomething", 10);
        }
        if(!firstTime){
            Invoke("wakeUp", 6);
        }
    }

    void DoSomething(){
        audio.Stop();
    }
    void wakeUp(){
        firstTime = true;
    }
}
