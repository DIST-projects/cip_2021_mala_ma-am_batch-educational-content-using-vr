using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab3 : MonoBehaviour
{

	public GameObject myHand;
	public GameObject Cube1;
	public GameObject Cube2;
	public GameObject Cube3;
	public GameObject Pos;
	public GameObject Canvas;

	Vector3 posOfCube1;
    Vector3 posOfCube2;
    Vector3 posOfCube3;

    bool placed1 = false;
    bool placed2 = false;
    bool placed3 = false;

    int cubeInHand = -1;
    int boxInPos = -1;

    
    void Start()
    {
        posOfCube1 = Cube1.transform.localPosition;
        posOfCube2 = Cube2.transform.localPosition;
        posOfCube3 = Cube3.transform.localPosition;
    }

    
    void Update()
    {
        
    }

    public void pickCube1(){
        if(Cube1.transform.position != posOfCube1){
            Cube1.transform.SetParent(Canvas.transform);
            Cube1.transform.localPosition =  posOfCube1;
            Cube1.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else{
            Cube1.transform.localPosition =  Pos.transform.localPosition;
            Cube1.transform.rotation = new Quaternion(0, 0, 0, 0);
            Cube2.transform.localPosition = posOfCube2;
            Cube3.transform.localPosition = posOfCube3;
        }
        
    }
    public void pickCube2(){
        if(Cube2.transform.position != posOfCube2){
            Cube2.transform.SetParent(Canvas.transform);
            Cube2.transform.localPosition =  posOfCube2;
            Cube2.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else{
            Cube2.transform.localPosition =  Pos.transform.localPosition;
            Cube2.transform.rotation = new Quaternion(0, 0, 0, 0);
            Cube1.transform.localPosition = posOfCube1;
            Cube3.transform.localPosition = posOfCube3;
        }
        
    }
    public void pickCube3(){
        if(Cube3.transform.position != posOfCube3){
            Cube3.transform.SetParent(Canvas.transform);
            Cube3.transform.localPosition = posOfCube3;
            Cube3.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else{
        	Cube3.transform.localPosition =  Pos.transform.localPosition;
            Cube3.transform.rotation = new Quaternion(0, 0, 0, 0);
            Cube2.transform.localPosition =  posOfCube2;
            Cube1.transform.localPosition =  posOfCube1;
        }
        
    }

}
