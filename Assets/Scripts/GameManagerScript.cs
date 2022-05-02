using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private GameObject player;
    private GameObject timer;
    private bool gameIsRunning;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("TMP Timer");
        gameIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EndGame()
    {
      if(gameIsRunning)
      {
          player.GetComponent<PlayerScript>().EndGame();
          timer.GetComponent<TMPTimerScript>().EndGame();
      }
    }
}
