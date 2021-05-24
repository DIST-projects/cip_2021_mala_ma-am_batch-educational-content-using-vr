using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PauseGame3 : MonoBehaviour
{
	bool gamePaused = false;
    public GameObject player;
    public GameObject pausePos;
    bool flag = false;

    AudioSource audio;
    public AudioClip SoundToPlay;
    public AudioMixer mixer;

    Vector3 currentPos;
 
    // Start is called before the first frame update
    void Start()
    {
    	audio = GetComponent<AudioSource>();
        audio.PlayOneShot(SoundToPlay, 1);
        audio.pitch = 1;
        mixer.SetFloat("SpeedParam", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag){
        if (Input.GetKeyDown(KeyCode.Mouse0)){
        	if(gamePaused == false){
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                currentPos = player.transform.localPosition;
                player.transform.localPosition = pausePos.transform.localPosition;
                audio.Pause();
                flag = true;
            }
            Debug.Log("Update");
            /*else{
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 2;
                player.transform.localPosition = currentPos;
            }*/
        }
    }
    }

    public void UnpauseGame(){
        Cursor.visible = false;
        gamePaused = false;
        Time.timeScale = 1;
        player.transform.localPosition = currentPos;
        audio.UnPause();
        Invoke("SetFlag",1);
        Debug.Log("unpause");
    }


    public void Quit(){
    	 Debug.Log("quit");
    	#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
     	#endif
    }

    void SetFlag(){
        flag = false;
    }
}
