using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    private GameObject player;
    private GameObject timer;
    private GameObject startMenu;
    private GameObject startMenuText;
    private bool gameIsRunning;
    private bool gameEnded;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timer = GameObject.Find("TMP Timer");
        startMenu = GameObject.Find("StartMenu");
        startMenuText = GameObject.Find("StartMenuText");
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        gameIsRunning = false;
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space) || 
      Input.GetKeyDown(KeyCode.Return)) {
        if(gameEnded) {
          startMenuText.GetComponent<MenuScript>().InitGame();
          gameEnded = false;
        }
        else if(!gameIsRunning)
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
          startMenu.GetComponent<CanvasGroup>().alpha = 1;
      }
    }

    public void WinGame()
    {
      if(gameIsRunning)
      {
          gameIsRunning = false;
          gameEnded = true;
          player.GetComponent<PlayerScript>().EndGame();
          timer.GetComponent<TMPTimerScript>().EndGame();
          startMenuText.GetComponent<MenuScript>().WinGame();
          startMenu.GetComponent<CanvasGroup>().alpha = 1;
      }
    }

    public void LoseGame()
    {
      if(gameIsRunning)
      {
          gameIsRunning = false;
          gameEnded = true;
          player.GetComponent<PlayerScript>().EndGame();
          timer.GetComponent<TMPTimerScript>().EndGame();
          startMenuText.GetComponent<MenuScript>().LoseGame();
          startMenu.GetComponent<CanvasGroup>().alpha = 1;
      }
    }

    public void StartGame()
    {
      if(!gameIsRunning)
      {
        gameIsRunning = true;
        player.GetComponent<PlayerScript>().StartGame();
        timer.GetComponent<TMPTimerScript>().StartGame();
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
      }
    }
}
