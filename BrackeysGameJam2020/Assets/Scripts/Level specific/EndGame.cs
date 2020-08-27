using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject[] GOAL = new GameObject[4];
    public bool endGame = false;
    public GameObject endGamePlatform;
    public GameObject platformSpawner;
    public GameObject endGameCanvas;
    void Start()
    {
    }
    
    void Update()
    {
        if(GOAL[0].activeInHierarchy && GOAL[1].activeInHierarchy && GOAL[2].activeInHierarchy && GOAL[3].activeInHierarchy)
        {
            endGame = true;
            endGamePlatform.SetActive(true);
            platformSpawner.SetActive(false);
            endGameCanvas.SetActive(true);
        }
    }
}
