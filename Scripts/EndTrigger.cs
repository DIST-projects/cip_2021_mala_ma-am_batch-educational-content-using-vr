using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameObject NextRound0;
    public GameObject NextRound1;
    public GameObject NextRound2;
    public GameObject NextRound3;
    public GameObject NextRound4;
    
    public int times = 0;
    private bool flag = false;

    
    void OnTriggerEnter(){
        if(times<5 && !flag){
            Invoke("Increment",2);
            flag=true;
            //Debug.Log(times);
        }
        if(times == 0){
        	NextRound0.SetActive(true);
        	Invoke("RemoveObject0",3);
        }
        else if(times == 1){
            NextRound1.SetActive(true);
            Invoke("RemoveObject1",3);
        }
        else if(times == 2){
            NextRound2.SetActive(true);
            Invoke("RemoveObject2",3);
        }
        else if(times == 3){
            NextRound3.SetActive(true);
            Invoke("RemoveObject3",3);
        }
        else if(times == 4){
            NextRound4.SetActive(true);
            Invoke("RemoveObject4",3);
        }
    	
        /*if(times>=1 && times!=5){
            roundComplete.SetActive(true);
            Invoke("RemoveObject",1);
        }*/
    }

    void Increment(){
    	times++;
        if(times == 1){
            times++;
        }
        flag = false;
    }
    void RemoveObject0(){
        NextRound0.SetActive(false);
    }
    void RemoveObject1(){
        NextRound1.SetActive(false);
    }
    void RemoveObject2(){
        NextRound2.SetActive(false);
    }
    void RemoveObject3(){
        NextRound3.SetActive(false);
    }
    void RemoveObject4(){
        NextRound4.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("03");
    }
}
