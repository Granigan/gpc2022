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
        gameIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || 
      Input.GetKeyDown(KeyCode.Return)) {
        if(!gameIsRunning)
        {
          this.StartGame();
        }
      }
    }

    public void EndGame()
    {
      if(gameIsRunning)
      {
          gameIsRunning = false;
          player.GetComponent<PlayerScript>().EndGame();
          timer.GetComponent<TMPTimerScript>().EndGame();
      }
    }

    public void StartGame()
    {
      if(!gameIsRunning)
      {
        gameIsRunning = true;
        player.GetComponent<PlayerScript>().StartGame();
        timer.GetComponent<TMPTimerScript>().StartGame();
      }
    }
}
