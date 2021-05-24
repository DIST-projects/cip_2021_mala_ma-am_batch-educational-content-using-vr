using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound4 : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    private bool firstTime = false;
    private int times = 0;
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
            Invoke("DoSomething", 3);
        }
        if(times<4){
        	Invoke("Increment",3);
        }
        else{
        	Invoke("wakeUp", 4);
        }
    }
    void Increment(){
    	times++;
    }
    void DoSomething(){
        audio.Stop();
    }
    void wakeUp(){
        firstTime = true;
    }
}
