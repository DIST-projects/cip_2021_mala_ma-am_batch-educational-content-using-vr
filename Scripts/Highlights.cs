using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlights : MonoBehaviour
{
	public GameObject[] panel;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("func1",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void func1(){
    	panel[0].SetActive(true);
    	Invoke("func2",1);
    }
    void func2(){
    	panel[0].SetActive(false);
    	panel[1].SetActive(true);
    	Invoke("func3",6);
    }
    void func3(){
    	panel[1].SetActive(false);
    	panel[2].SetActive(true);
    	Invoke("func4",11);
    }
    void func4(){
    	panel[2].SetActive(false);
    	panel[3].SetActive(true);
    	Invoke("func5",6);
    }
    void func5(){
    	panel[3].SetActive(false);
    	panel[4].SetActive(true);
    	Invoke("func6",7);
    }
    void func6(){
    	panel[4].SetActive(false);
    	panel[5].SetActive(true);
    	Invoke("func7",8);
    }
    void func7(){
    	panel[5].SetActive(false);
    	panel[6].SetActive(true);
    	Invoke("func8",4);
    }
    void func8(){
    	panel[6].SetActive(false);
    	panel[7].SetActive(true);
    	Invoke("func9",4);
    }
    void func9(){
    	panel[7].SetActive(false);
    	panel[8].SetActive(true);
    	Invoke("quit",4);
    }
    void quit(){
    	#if UNITY_EDITOR
         	UnityEditor.EditorApplication.isPlaying = false;
     	#else
         	Application.Quit();
     	#endif
    }
}
