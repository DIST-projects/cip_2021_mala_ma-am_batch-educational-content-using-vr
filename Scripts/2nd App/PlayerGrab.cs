using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerGrab : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correct;
    public AudioClip incorrect;

	public GameObject ball;
    public GameObject ball2;
    public GameObject ball3;
    public GameObject ball4;
    public GameObject ball5;
	public GameObject myHand;
	public GameObject Canvas;
	public GameObject pos1;
	public GameObject pos2;
    public GameObject pos3;
    public GameObject pos4;
    public GameObject pos5;
    public GameObject result;
    public GameObject submit;
    public Text textResult;
    public Text textResult2;
    public Image panel;
    public GameObject putAllInPos;
    public Color myColor;
    public Color myColor1;
    public GameObject retryobj;
    public GameObject nextobj;
    public GameObject placePanel1;
    public GameObject placePanel2;


    Vector3 zero;
    Vector3 initialPos1;
    Vector3 initialPos2;
    Vector3 initialPos3;
    Vector3 initialPos4;
    Vector3 initialPos5;

    bool placed1 = false;
    bool placed2 = false;
    bool placed3 = false;
    bool placed4 = false;
    bool placed5 = false;

    bool panelFlag = false;

    int boxInPos1 = -1;
    int boxInPos2 = -1;
    int boxInPos3 = -1;
    int boxInPos4 = -1;
    int boxInPos5 = -1;

    int count = 0;
    bool flag1 = false;

	private bool inHands = false;
    private int cubeInHand;
    
    /*void Start()
    {
        //ball.transform.SetParent(Canvas.transform);
        initialPos1 = ball.transform.position;
        initialPos2 = ball2.transform.position;
        initialPos3 = ball3.transform.position;
        initialPos4 = ball4.transform.position;
        initialPos5 = ball5.transform.position;
        Debug.Log("start");
    }*/

    /*void Update()
    {
    	//Debug.Log("update");
        if(Input.GetButtonDown("Fire1")){
        	if(!inHands){
                pos1.SetActive(true);
                pos2.SetActive(true);
        		ball.transform.SetParent(myHand.transform);
        		ball.transform.localPosition = new Vector3(0f, -1f, 1f);
        		ball.transform.rotation = new Quaternion(0, 0, 0, 0);
        		inHands = true;
        	}
        }
    }*/
    void Update(){
    	if(!panelFlag){
    	if(inHands){
    		placePanel1.SetActive(true);
    		placePanel2.SetActive(false);
    	}
    	else{
    		placePanel1.SetActive(false);
    		placePanel2.SetActive(true);
    	}
    }
    }


    public void changeColor(){
        submit.GetComponent<Renderer> ().material.color = myColor;
    }
    public void changeBack(){
        submit.GetComponent<Renderer> ().material.color = myColor1;
    }
    public void changeColor1(){
        retryobj.GetComponent<Renderer> ().material.color = myColor;
    }
    public void changeBack1(){
        retryobj.GetComponent<Renderer> ().material.color = myColor1;
    }
    public void changeColor2(){
        nextobj.GetComponent<Renderer> ().material.color = myColor;
    }
    public void changeBack2(){
        nextobj.GetComponent<Renderer> ().material.color = myColor1;
    }
    public void retry(){
    	//SceneManager.LoadScene("01");
        submit.SetActive(true);
        result.SetActive(false);
        ball.transform.localPosition =  initialPos1;
        ball.transform.rotation = new Quaternion(0, 0, 0, 0);
        placed1 = false;
            ball2.transform.localPosition =  initialPos2;
            placed2 =false;
            ball3.transform.localPosition =  initialPos3;
            placed3 =false;
            ball4.transform.localPosition =  initialPos4;
            placed4 =false;
            ball5.transform.localPosition =  initialPos5;
            placed5 =false;
        count = 0;
        boxInPos1 = -1;
        boxInPos2 = -1;
        boxInPos3 = -1;
        boxInPos4 = -1;
        boxInPos5 = -1;

    }
    public void nextLevel(){
    	SceneManager.LoadScene("02");
    }

    public void Submit(){
        if(boxInPos1 == -1 || boxInPos2 == -1 || boxInPos3 == -1 || boxInPos4 == -1 || boxInPos5 == -1){
            putAllInPos.SetActive(true);
            placePanel1.SetActive(false);
    		placePanel2.SetActive(false);
    		panelFlag = true;
            Debug.Log(boxInPos1);
            Debug.Log(boxInPos2);
            Debug.Log(boxInPos3);
            Debug.Log(boxInPos4);
            Debug.Log(boxInPos5);
            Invoke("Remove",6);
            return;
        }
    	submit.SetActive(false);
        result.SetActive(true);
        if(boxInPos1 == 2){
        	Debug.Log("1");
            count++;
        }
        if(boxInPos2 == 4){
        	Debug.Log("2");
            count++;
        }
        if(boxInPos3 == 5){
        	Debug.Log("3");
            count++;
        }
        if(boxInPos4 == 3){
        	Debug.Log("4");
            count++;
        }
        if(boxInPos5 == 1){
        	Debug.Log("5");
            count++;
        }
        if(count == 5){
        	textResult2.text = "சரியான பதில்";
        	panel.color = UnityEngine.Color.green;
            source.clip=correct;
            source.Play();
        }
        else{
        	textResult2.text = "தவறான பதில்";
        	panel.color = UnityEngine.Color.red;
            source.clip=incorrect;
            source.Play();
        }
        textResult.text = count.ToString() + "/5";
        
    }

    void Remove(){
        putAllInPos.SetActive(false);
        panelFlag = false;
    }
    void posFunc(){
    	if(!flag1){
    		ball.transform.SetParent(Canvas.transform);
    		ball2.transform.SetParent(Canvas.transform);
    		ball3.transform.SetParent(Canvas.transform);
    		ball4.transform.SetParent(Canvas.transform);
    		ball5.transform.SetParent(Canvas.transform);
    		initialPos1 = ball.transform.localPosition;
        	initialPos2 = ball2.transform.localPosition;
        	initialPos3 = ball3.transform.localPosition;
        	initialPos4 = ball4.transform.localPosition;
        	initialPos5 = ball5.transform.localPosition;
        	flag1 = true;
    	}
    }
    public void pickCube1(){
    	posFunc();
        if(ball.transform.position != zero && placed1){
            //ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  initialPos1;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = false;
            //boxInPos1 = -1;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            pos4.SetActive(true);
            pos5.SetActive(true);
            ball.transform.SetParent(myHand.transform);
            ball.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 1;
            inHands = true;
        }
        
    }
    public void pickCube2(){
    	posFunc();
        if(ball2.transform.position != zero && placed2){
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  initialPos2;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 =false;
            //boxInPos2 = -1;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            pos4.SetActive(true);
            pos5.SetActive(true);
            ball2.transform.SetParent(myHand.transform);
            ball2.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 2;
            inHands = true;
        }
        
    }
    public void pickCube3(){
    	posFunc();
        if(ball3.transform.position != zero && placed3){
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  initialPos3;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 =false;
            //boxInPos3 = -1;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            pos4.SetActive(true);
            pos5.SetActive(true);
            ball3.transform.SetParent(myHand.transform);
            ball3.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 3;
            inHands = true;
        }
        
    }
    public void pickCube4(){
    	posFunc();
        if(ball4.transform.position != zero && placed4){
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  initialPos4;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 =false;
            //boxInPos4 = -1;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            pos4.SetActive(true);
            pos5.SetActive(true);
            ball4.transform.SetParent(myHand.transform);
            ball4.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 4;
            inHands = true;
        }
        
    }
    public void pickCube5(){
    	posFunc();
        if(ball5.transform.position != zero && placed5){
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  initialPos5;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 =false;
            //boxInPos5 = -1;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            pos4.SetActive(true);
            pos5.SetActive(true);
            ball5.transform.SetParent(myHand.transform);
            ball5.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 5;
            inHands = true;
        }
        
    }
    public void placeInPos1(){
    	/*if(inHands){
            //Debug.Log("inpos1");
    		//this.GetComponent<PlayerGrab>().enabled = false; 
            pos1.SetActive(false);
        	ball.transform.SetParent(Canvas.transform);
        	ball.transform.localPosition = 	pos1.transform.localPosition;
        	ball.transform.rotation = new Quaternion(0, 0, 0, 0);
        	inHands = false;
    	}*/
        inHands = false;
        if(cubeInHand == 1){
            pos1.SetActive(false);
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  pos1.transform.localPosition;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = true;
            boxInPos1 = 1;
        }
        else if(cubeInHand == 2){
            pos1.SetActive(false);
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  pos1.transform.localPosition;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 = true;
            boxInPos1 = 2;
        }
        else if(cubeInHand == 3){
            pos1.SetActive(false);
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  pos1.transform.localPosition;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 = true;
            boxInPos1 = 3;
        }
        else if(cubeInHand == 4){
            pos1.SetActive(false);
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  pos1.transform.localPosition;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 = true;
            boxInPos1 = 4;
        }
        else if(cubeInHand == 5){
            pos1.SetActive(false);
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  pos1.transform.localPosition;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 = true;
            boxInPos1 = 5;
        }
    }
    public void placeInPos2(){
        inHands = false;
        if(cubeInHand == 1){
            pos2.SetActive(false);
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  pos2.transform.localPosition;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = true;
            boxInPos2 = 1;
        }
        else if(cubeInHand == 2){
            pos2.SetActive(false);
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  pos2.transform.localPosition;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 = true;
            boxInPos2 = 2;
        }
        else if(cubeInHand == 3){
            pos2.SetActive(false);
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  pos2.transform.localPosition;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 = true;
            boxInPos2 = 3;
        }
        else if(cubeInHand == 4){
            pos2.SetActive(false);
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  pos2.transform.localPosition;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 = true;
            boxInPos2 = 4;
        }
        else if(cubeInHand == 5){
            pos2.SetActive(false);
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  pos2.transform.localPosition;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 = true;
            boxInPos2 = 5;
        }
    }
    public void placeInPos3(){
        inHands = false;
        if(cubeInHand == 1){
            pos3.SetActive(false);
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  pos3.transform.localPosition;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = true;
            boxInPos3 = 1;
        }
        else if(cubeInHand == 2){
            pos3.SetActive(false);
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  pos3.transform.localPosition;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 = true;
            boxInPos3 = 2;
        }
        else if(cubeInHand == 3){
            pos3.SetActive(false);
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  pos3.transform.localPosition;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 = true;
            boxInPos3 = 3;
        }
        else if(cubeInHand == 4){
            pos3.SetActive(false);
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  pos3.transform.localPosition;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 = true;
            boxInPos3 = 4;
        }
        else if(cubeInHand == 5){
            pos3.SetActive(false);
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  pos3.transform.localPosition;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 = true;
            boxInPos3 = 5;
        }
    }
    public void placeInPos4(){
        inHands = false;
        if(cubeInHand == 1){
            pos4.SetActive(false);
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  pos4.transform.localPosition;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = true;
            boxInPos4 = 1;
        }
        else if(cubeInHand == 2){
            pos4.SetActive(false);
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  pos4.transform.localPosition;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 = true;
            boxInPos4 = 2;
        }
        else if(cubeInHand == 3){
            pos4.SetActive(false);
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  pos4.transform.localPosition;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 = true;
            boxInPos4 = 3;
        }
        else if(cubeInHand == 4){
            pos4.SetActive(false);
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  pos4.transform.localPosition;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 = true;
            boxInPos4 = 4;
        }
        else if(cubeInHand == 5){
            pos4.SetActive(false);
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  pos4.transform.localPosition;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 = true;
            boxInPos4 = 5;
        }
    }
    public void placeInPos5(){
        inHands = false;
        if(cubeInHand == 1){
            pos5.SetActive(false);
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  pos5.transform.localPosition;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = true;
            boxInPos5 = 1;
        }
        else if(cubeInHand == 2){
            pos5.SetActive(false);
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  pos5.transform.localPosition;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 = true;
            boxInPos5 = 2;
        }
        else if(cubeInHand == 3){
            pos5.SetActive(false);
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition =  pos5.transform.localPosition;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 = true;
            boxInPos5 = 3;
        }
        else if(cubeInHand == 4){
            pos5.SetActive(false);
            ball4.transform.SetParent(Canvas.transform);
            ball4.transform.localPosition =  pos5.transform.localPosition;
            ball4.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed4 = true;
            boxInPos5 = 4;
        }
        else if(cubeInHand == 5){
            pos5.SetActive(false);
            ball5.transform.SetParent(Canvas.transform);
            ball5.transform.localPosition =  pos5.transform.localPosition;
            ball5.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed5 = true;
            boxInPos5 = 5;
        }
    }
}
