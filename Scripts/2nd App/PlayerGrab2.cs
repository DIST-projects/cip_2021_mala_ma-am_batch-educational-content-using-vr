using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerGrab2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correct;
    public AudioClip incorrect;

	public GameObject ball;
    public GameObject ball2;
    public GameObject ball3;
	public GameObject myHand;
	public GameObject Canvas;
	public GameObject pos1;
	public GameObject pos2;
    public GameObject pos3;
    public GameObject panel2;
    public Text textResult;
    public Color myColor;
    public Color myColor1;
    public GameObject submit;
    public GameObject retryobj;
    public GameObject nextobj;
    public GameObject placePanel;
    public GameObject placeAll;
    public GameObject pickBoxPanel;

    public TextMeshProUGUI QuesNumber;

    public Image panel;

    public TextMeshProUGUI q1;
    public TextMeshProUGUI q2;
    public TextMeshProUGUI q3;
    public TextMeshProUGUI submitText;

    string[] questionNumber;
    string[] questionList1;
    string[] questionList2;
    string[] questionList3;

    Vector3 zero;
    Vector3 posOfball1;
    Vector3 posOfball2;
    Vector3 posOfball3;

    bool placed1 = false;
    bool placed2 = false;
    bool placed3 = false;

    int boxInPos1 =-1;
    int boxInPos2 =-1;
    int boxInPos3 =-1;

    int count = 0;

	bool inHands = false;
    int cubeInHand;

    int currentQues = 0;
    bool instFlag = true;
    void Start()
    {
        //ball.transform.SetParent(Canvas.transform);
        questionNumber = new string[6] {"1)","2)","3)","4)","5)","6)"}; 
        questionList1 = new string[6] { "பறைவகள்", "அரசன்", "விலங்குகள்", "சாதுவான", "மயில்‌",  "ேதசிய" }; 
        questionList2 = new string[6] { "இைவ", "விலங்குகளின்‌", "இந்த", "மான்‌", "ஒரு", "இது"}; 
        questionList3 = new string[6] {"அழகான", "சிங்கம்", "வனவிலங்குகள்‌", "விலங்கு", "பறைவ", "பறைவ" };
        QuesNumber.text = questionNumber[0]; 
        q1.text = questionList1[0];
        q2.text = questionList2[0];
        q3.text = questionList3[0];
        posOfball1 = ball.transform.localPosition;
        posOfball2 = ball2.transform.localPosition;
        posOfball3 = ball3.transform.localPosition;
    }

    void Update()
    {
    	if(instFlag){
    		if(inHands){
    			placePanel.SetActive(true);
    			pickBoxPanel.SetActive(false);
    		}
    		else{
    			placePanel.SetActive(false);
    			pickBoxPanel.SetActive(true);
    		}
    		submitText.text = "சமர்ப்பிக்கவும்";
    	}
    	else{
    		submitText.text = "";
    		placePanel.SetActive(false);
    		pickBoxPanel.SetActive(false);
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




    public void Submit(){
    	if(boxInPos1 == -1 || boxInPos2 == -1 || boxInPos3 == -1){
    		placeAll.SetActive(true);
    		Invoke("removePanel",3);
    		return;
    	}
    	instFlag = false;
        q1.text = "";
        q2.text = "";
        q3.text = "";
        panel2.SetActive(true);
        if(currentQues == 0){
        	if(boxInPos1 == 2){
            	count++;
        	}
        	if(boxInPos2 == 3){
            	count++;
        	}
        	if(boxInPos3 == 1){
            	count++;
        	}
    	}
    	if(currentQues == 1){
        	if(boxInPos1 == 3){
            	count++;
        	}
        	if(boxInPos2 == 2){
            	count++;
        	}
        	if(boxInPos3 == 1){
            	count++;
        	}
    	}
    	if(currentQues == 2){
        	if(boxInPos1 == 2){
            	count++;
        	}
        	if(boxInPos2 == 1){
            	count++;
        	}
        	if(boxInPos3 == 3){
            	count++;
        	}
    	}
    	if(currentQues == 3){
        	if(boxInPos1 == 2){
            	count++;
        	}
        	if(boxInPos2 == 1){
            	count++;
        	}
        	if(boxInPos3 == 3){
            	count++;
        	}
    	}
    	if(currentQues == 4){
        	if(boxInPos1 == 1){
            	count++;
        	}
        	if(boxInPos2 == 2){
            	count++;
        	}
        	if(boxInPos3 == 3){
            	count++;
        	}
    	}
    	if(currentQues == 5){
        	if(boxInPos1 == 2){
            	count++;
        	}
        	if(boxInPos2 == 1){
            	count++;
        	}
        	if(boxInPos3 == 3){
            	count++;
        	}
    	}

        if(count == 3){
            textResult.text = "சரியான பதில்";
            panel.color = UnityEngine.Color.green;
            source.clip=correct;
            source.Play();
        }
        else{
            textResult.text = "தவறான பதில்";
            panel.color = UnityEngine.Color.red;
            source.clip=incorrect;
            source.Play();
        }
    }

    void removePanel(){
    	placeAll.SetActive(false);
    }

    public void NextQues(){
    	instFlag = true;
    	panel2.SetActive(false);

    	if(currentQues<5){
    		count=0;
    		currentQues++;
    		ball.transform.localPosition =  posOfball1;
    		ball2.transform.localPosition =  posOfball2;
    		ball3.transform.localPosition =  posOfball3;
    		QuesNumber.text = questionNumber[currentQues];
    	    q1.text = questionList1[currentQues];
    	    q2.text = questionList2[currentQues];
    	    q3.text = questionList3[currentQues];
    	}
    	else{
    		SceneManager.LoadScene("03");
    	}
    	boxInPos1 = -1;
        boxInPos2 = -1;
        boxInPos3 = -1;
        placed1 = false;
        placed2 = false;
        placed3 = false;
    }


    public void retryQues(){
    	instFlag = true;
        currentQues--;
        boxInPos1 = -1;
        boxInPos2 = -1;
        boxInPos3 = -1;
        NextQues();
    }


    public void pickCube1(){
        if(ball.transform.position != posOfball1 && placed1){
            ball.transform.SetParent(Canvas.transform);
            ball.transform.localPosition =  posOfball1;
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed1 = false;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            ball.transform.SetParent(myHand.transform);
            ball.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 1;
            inHands = true;
        }
        
    }
    public void pickCube2(){
        if(ball2.transform.position != posOfball2 && placed2){
            ball2.transform.SetParent(Canvas.transform);
            ball2.transform.localPosition =  posOfball2;
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed2 =false;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            ball2.transform.SetParent(myHand.transform);
            ball2.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball2.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 2;
            inHands = true;
        }
        
    }
    public void pickCube3(){
        if(ball3.transform.position != posOfball3 && placed3){
            ball3.transform.SetParent(Canvas.transform);
            ball3.transform.localPosition = posOfball3;
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            placed3 =false;
        }
        else if(!inHands){
            pos1.SetActive(true);
            pos2.SetActive(true);
            pos3.SetActive(true);
            ball3.transform.SetParent(myHand.transform);
            ball3.transform.localPosition = new Vector3(0f, -1f, 1f);
            ball3.transform.rotation = new Quaternion(0, 0, 0, 0);
            cubeInHand = 3;
            inHands = true;
        }
        
    }
    
    public void placeInPos1(){
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
        
    }
    
}
