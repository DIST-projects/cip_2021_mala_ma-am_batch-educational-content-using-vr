using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySound3 : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;
    public bool alreadyPlayed = false;
    private bool firstTime = false;
    private int times = 0;
    public GameObject pauseMenu;
    public AudioMixer mixer;
    public PauseApp Pause;


    void Start(){
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

    void OnTriggerEnter(){
        if(!alreadyPlayed && firstTime){
            audio.PlayOneShot(SoundToPlay, Volume);
            audio.pitch = Pause.speed;
            mixer.SetFloat("SpeedParam", 1/Pause.speed);
            alreadyPlayed = true;
            Invoke("DoSomething", 6);
        }
        if(times<2){
            Invoke("Increment",10);
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
