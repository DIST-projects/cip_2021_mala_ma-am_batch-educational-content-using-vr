using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class GameController : MonoBehaviour {
 
    private int score;
    public GameObject[] checkPoints;
    private int nextCheckPoint;
    //public Text winText;
 
    private void Start()
    {
        score = 0;
        nextCheckPoint = 0;
 
    }
 
    public void AddScore(int scoreValue, GameObject checkPoint)
    {
        if (checkPoint == checkPoints[nextCheckPoint])
        {
            score += scoreValue;
            nextCheckPoint++;
            if (nextCheckPoint >= 3)
            {
                Debug.Log("You Win!");
            }
        }
    }
}