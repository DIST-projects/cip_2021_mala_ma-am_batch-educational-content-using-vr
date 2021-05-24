
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlScript : MonoBehaviour {


   



    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Image ImageQuestion;
    public Text ScoreTxt;

    public int totalQuestions = 0;
    public int score = 0;


    public GameObject Quizpanel;
  






    public AudioClip acCorrect;
    public AudioClip acWrong;
 

    private AudioSource audioSource;



    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
        totalQuestions = QnA.Count;
        generateQuestion();


    }
    
    void GameOver()
    {
        Quizpanel.SetActive(false);
        SceneManager.LoadScene("Scene04");
    }




    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
            ImageQuestion.sprite= QnA[currentQuestion].question;
           
            setAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            PlayerPrefs.SetInt("Mark", score);
            GameOver();
        }




    }
    void setAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].answers[i];
            if (QnA[currentQuestion].correct == i +1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    // Method is invoked when correct answer is given
    public void RightAnswer()
	{


        score = score + 1;
        audioSource.clip = acCorrect;
        audioSource.Play();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

   

    
   

    // Method is invoked if incorrect answer is given
    public void WrongAnswer()
	{


        audioSource.clip = acWrong;
        audioSource.Play();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();

    }

    


    
	
	


}
