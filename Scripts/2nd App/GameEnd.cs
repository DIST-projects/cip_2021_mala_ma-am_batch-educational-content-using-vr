
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    public Text textGameOver;
    void Start()
    {
        int score = PlayerPrefs.GetInt("Mark", 0);
        textGameOver.text = " உங்கள் மதிப்ெபண்:" + score;

    }

    public void PlayAgain()
    {

        SceneManager.LoadScene("Scene01");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }



}
