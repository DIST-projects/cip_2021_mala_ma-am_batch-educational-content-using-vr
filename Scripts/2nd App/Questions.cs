
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Questions : MonoBehaviour
{
    #region Variables
    public Image imageQuestions;
    public Text textQuestions;
    public ToggleGroup toggleGroup;
    public GameObject goNextButton;

    public List<Sprite> Spritelists;
    public List<Text> Toggletextlists;

    public AudioClip acCorrect;
    public AudioClip acWrong;

    private string correctAnswer;
    private int CurrentQuestionIndex = -1;

    private List<string> optionAnswer;

    private string textOptionSelected;

    private AudioSource audioSource;

    private int score = 0;

    #endregion

    

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();

        goNextButton.SetActive(false);
        ShowNextQuestion();
    }

    private void ShowNextQuestion()
    {
        ++CurrentQuestionIndex;

        if(CurrentQuestionIndex == Spritelists.Count)
        {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("End");
            return;
        }

        correctAnswer = Spritelists[CurrentQuestionIndex].name;
        imageQuestions.sprite= Spritelists[CurrentQuestionIndex];
        imageQuestions.SetNativeSize();

       optionAnswer = new List<string> ();

        optionAnswer.Add(correctAnswer);
        optionAnswer.Add(Spritelists[GetRandomIndex()].name);

        ShuffleAnswers();




        for (int  i=0;i<optionAnswer.Count;++i)
        {
            Toggletextlists[i].text = optionAnswer[i];
        }
       

    }
    private void ShuffleAnswers()
    {
        string answer = optionAnswer[0];
        int rand = UnityEngine.Random.Range(0, optionAnswer.Count);
        string randString = optionAnswer[rand];
        optionAnswer[rand] = answer;
        optionAnswer[0] = randString;
    }
    private int GetRandomIndex()
    {
        
       int  rand = UnityEngine.Random.Range(0, Spritelists.Count);
        for (int i = 0; i < optionAnswer.Count; ++i)
        {
            if (optionAnswer[i].Equals(Spritelists[rand].name))
                return GetRandomIndex();
        }
        return rand;
    }

    public void OnToggleClick(Text t)
    {
        textOptionSelected=t.text;
        goNextButton.SetActive(true);

    }

    public void onNextButtonClick()
    {
       

       

        if(CheckCorrectAnswers())
        {
           
            audioSource.clip = acCorrect;
            ++score;
        }
        else
        {
            
            audioSource.clip = acWrong;
        }

        audioSource.Play();

        HideQuestion();


        ShowNextQuestion();
        Invoke("ShowQuestion",1.0f);
    }

    private void ShowQuestion()
    {
        imageQuestions.gameObject.SetActive(true);
        textQuestions.gameObject.SetActive(true);
        toggleGroup.gameObject.SetActive(true);
    }

    private void HideQuestion()
    {
        imageQuestions.gameObject.SetActive(false);
        textQuestions.gameObject.SetActive(false);
        toggleGroup.SetAllTogglesOff();
        toggleGroup.gameObject.SetActive(false);
        goNextButton.SetActive(false);

    }

    private bool CheckCorrectAnswers()
    {
        if (textOptionSelected.Equals(correctAnswer))
            return true;
        return false;
    }
}
