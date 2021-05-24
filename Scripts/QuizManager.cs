using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip correct_s;
    public AudioClip incorrect_s;

    // public Color myColor;
    // public Color myColor1;
    // public GameObject submit1,submit2,submit3,submit4;
    public GameObject title;

    public GameObject NextRoundObj;
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions=0;
    public int score=0;

    public GameObject Quizpanel;
    public GameObject Gopanel;

    // public void changeColor(){
    //     submit1.GetComponent<Renderer> ().material.color = myColor;
    // }
    // public void changeBack(){
    //     submit1.GetComponent<Renderer> ().material.color = myColor1;
    // }
    // public void changeColor1(){
    //     submit2.GetComponent<Renderer> ().material.color = myColor;
    // }
    // public void changeBack1(){
    //     submit2.GetComponent<Renderer> ().material.color = myColor1;
    // }
    // public void changeColor2(){
    //     submit3.GetComponent<Renderer> ().material.color = myColor;
    // }
    // public void changeBack2(){
    //     submit3.GetComponent<Renderer> ().material.color = myColor1;
    // }
    // public void changeColor3(){
    //     submit4.GetComponent<Renderer> ().material.color = myColor;
    // }
    // public void changeBack3(){
    //     submit4.GetComponent<Renderer> ().material.color = myColor1;
    // }

    private void Start()
    {
        Invoke("RemoveObject",2);
        totalQuestions=QnA.Count;
        Gopanel.SetActive(false);
        generateQuestion();
    }

    void RemoveObject(){
        title.SetActive(false);
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        Gopanel.SetActive(true);
        ScoreTxt.text=(score)+" / "+(totalQuestions);
        Invoke("NextRound",0);
    }

    public void correct()
    {
        source.clip=correct_s;
        source.Play();
        score=score+1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        source.clip=incorrect_s;
        source.Play();
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void setAnswers()
    {
        for(int i=0;i<options.Length;i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect=false;
            options[i].transform.GetChild(0).GetComponent<Text>().text=QnA[currentQuestion].answers[i];
            if(QnA[currentQuestion].correct==i+1)
            {
               options[i].GetComponent<AnswerScript>().isCorrect=true; 
            }
        }
    }

    void generateQuestion()
    {
        if(QnA.Count>0)
        {
        currentQuestion=Random.Range(0,QnA.Count);
        QuestionTxt.text=QnA[currentQuestion].question;
        setAnswers();
        }
        else
        {
            Debug.Log("Out of questions");
            GameOver();
        }
    }
    void NextRound(){
        NextRoundObj.SetActive(true);
    }
    public void ClickForNextRound(){
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
        Application.Quit();

    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif
    }
}
