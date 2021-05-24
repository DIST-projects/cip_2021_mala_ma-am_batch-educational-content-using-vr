using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public GameObject completeLevelUI;

    public void CompleteLevel(){
    	Debug.Log("here");
    	completeLevelUI.SetActive(true);
    	Time.timeScale = 0;
    }
    public void UnpauseGame(){
        completeLevelUI.SetActive(false);
        Time.timeScale = 1;
    }
}
