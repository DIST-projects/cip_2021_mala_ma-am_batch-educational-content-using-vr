using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public LevelControlScript quizManager;

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.RightAnswer();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.WrongAnswer();
        }
    }

}
