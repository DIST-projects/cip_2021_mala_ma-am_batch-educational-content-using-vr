using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySound2 : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    public bool firstTime = false;
    public GameObject pauseMenu;
    public AudioMixer mixer;
    public PauseApp Pause;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    
    void Update(){
        if(pauseMenu.active){
            audio.Pause();
        }
        else{
            audio.UnPause();
        }
    }
    void OnTriggerEnter()
    {
        if(!alreadyPlayed && firstTime){
            audio.PlayOneShot(SoundToPlay, Volume);
            audio.pitch = Pause.speed;
            mixer.SetFloat("SpeedParam", 1/Pause.speed);
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
