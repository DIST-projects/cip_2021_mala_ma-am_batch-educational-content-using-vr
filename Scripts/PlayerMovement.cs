using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
	private int currentPoint;
	public float moveSpeed;
    private bool paused = false;
    public EndTrigger End;
    public GameObject[] textObjects;
    private int textObjectPoint = 0;
    private bool flag = false;
    private bool flag2 = false;

    public GameObject t1;
    public GameObject t2;
    public GameObject t3;
    public GameObject t4;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint=0;
        //SceneManager.LoadScene("03");
    }

    // Update is called once per frame
    void Update()
    {
    	
     	if(transform.position == patrolPoints[currentPoint].position){
     		currentPoint++;    
            paused = true; 
            if(currentPoint < 11){
                t1.SetActive(false);
                t2.SetActive(false);
                t3.SetActive(false);
                t4.SetActive(false);
            }
            else if(End.times != 4){
                t1.SetActive(true);
                t2.SetActive(true);
                t3.SetActive(true);
                t4.SetActive(true);
            }

            if(currentPoint == 12){
            	paused = false;
            }
            else{
            	//Debug.Log(End.times);
                if(End.times == 0 && !flag2){
                    Invoke("DoSomething", 3);
                    flag2 = true;
                }
            	else if(End.times == 1 || End.times == 0){
            		Invoke("DoSomething", 5); 
            	}
            	else if(End.times == 2){
            		Invoke("DoSomething", 5);
            	}
            	else if(End.times == 3){
            		Invoke("DoSomething", 10);
            	}
            	else if(End.times == 4){
            		if(!flag){
            			for(int i=0;i<14;i++){
            				textObjects[i].SetActive(false);
            			}
            			flag = true;
            		}
            		Invoke("TextObjectSet",4);
            		Invoke("DoSomething", 6);
            	}
            	else{
            		Time.timeScale = 0;
            	}
            }  
     	}   
     	if(currentPoint >= patrolPoints.Length){
    		currentPoint=0;
            paused = true;
    	}
        if(paused == false){
     	transform.position = Vector3.MoveTowards(transform.position,patrolPoints[currentPoint].position,moveSpeed * Time.deltaTime);
        /*if(currentPoint == 1 || currentPoint == 3 || currentPoint == 5 || currentPoint == 7 || currentPoint == 9){
            transform.Rotate(0,180,0,Space.Self);
        }
        else{
            transform.Rotate(0,180,0,Space.Self);
        }*/
        }
    }
    void DoSomething(){
        paused = false;
    }
    void TextObjectSet(){
    	textObjects[textObjectPoint].SetActive(true);
        if(textObjectPoint<14){
            textObjectPoint++;
        }
    }
}










