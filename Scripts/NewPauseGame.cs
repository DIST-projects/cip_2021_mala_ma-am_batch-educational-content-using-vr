using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    
    void onTriggerEnter()
    {
        
        
                Time.timeScale = 0;
                gamePaused = true;
                Cursor.visible = true;
                pauseMenu.SetActive(true);
            
        
        
    }

    public void UnpauseGame(){
        pauseMenu.SetActive(false);
                Cursor.visible = false;
                gamePaused = false;
                Time.timeScale = 1;
    }
}
