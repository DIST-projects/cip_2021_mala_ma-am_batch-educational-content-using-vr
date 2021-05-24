using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Check : MonoBehaviour
{
    private GameController gameController;
    public GameObject[] cubes;
   
    private void Start()
    {
        gameController = GameObject.FindWithTag("Player").GetComponent<GameController>();
    }
 
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DraggableObject" || other.tag == "DraggableObject_1" || other.tag == "DraggableObject_2")
        {
            gameController.AddScore(100, this.gameObject);
        }
    }
}
