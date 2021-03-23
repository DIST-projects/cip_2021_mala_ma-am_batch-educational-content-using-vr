using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions=0;
    public int score=0;

    public GameObject Quizpanel;
    public GameObject Gopanel;

    private void Start()
    {
        totalQuestions=QnA.Count;
        Gopanel.SetActive(false);
        generateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        Gopanel.SetActive(true);
        ScoreTxt.text=score+" / "+totalQuestions;
    }

    public void correct()
    {
        score=score+1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
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
               options[i].GetComponent<AnswerScript>().isCorrect=false; 
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

    
}
