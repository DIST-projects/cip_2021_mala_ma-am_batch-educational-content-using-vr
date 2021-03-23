using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform[] patrolPoints;
	private int currentPoint;
	public float moveSpeed;
    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        currentPoint=0;
    }

    // Update is called once per frame
    void Update()
    {
    	
     	if(transform.position == patrolPoints[currentPoint].position){
     		currentPoint++;    
            paused = true; 
            Invoke("DoSomething", 2);   
     	}   
     	if(currentPoint >= patrolPoints.Length){
    		currentPoint=0;
            paused = true;
    	}
        if(paused == false){
     	transform.position = Vector3.MoveTowards(transform.position,patrolPoints[currentPoint].position,moveSpeed * Time.deltaTime);
        }
    }
    void DoSomething(){
        paused = false;
    }
}
