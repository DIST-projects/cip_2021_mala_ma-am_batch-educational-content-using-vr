using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseApp : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)){
        	if(gamePaused == false){
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            }
            else{
                pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void UnpauseGame(){
        pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
    }
}
