using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    private GameObject player;
    private GameObject timerDisplay;
    private GameObject scoreDisplay;
    private GameObject startMenu;
    private GameObject startMenuText;
    private bool gameIsRunning;
    private bool gameEnded;

    private float timeRemaining = 30;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        timerDisplay = GameObject.Find("TMP Timer");
        scoreDisplay = GameObject.Find("TMP Score");
        startMenu = GameObject.Find("StartMenu");
        startMenuText = GameObject.Find("StartMenuText");
        startMenu.GetComponent<CanvasGroup>().alpha = 1;
        gameIsRunning = false;
        gameEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
      // Player input
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

      // Timer update
      if (gameIsRunning && timeRemaining > 0)
      {
        timeRemaining -= Time.deltaTime;
        timerDisplay.GetComponent<TMPTimerScript>().DisplayTime(timeRemaining);
      } else
      {
        timeRemaining = 0;
        this.LoseGame();
      }

      // Score update
      if (gameIsRunning)
      {
        scoreDisplay.GetComponent<ScoreScript>().DisplayScore(score);
      }

    }

    public void AddBonusTime(float timeToAdd) 
    {
      timeRemaining += timeToAdd;
    }

    public void addScore(int scoreToAdd) {
      score += scoreToAdd;
    }

    public void EndGame()
    {
      if(gameIsRunning)
      {
          gameIsRunning = false;
          player.GetComponent<PlayerScript>().EndGame();
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
          startMenuText.GetComponent<MenuScript>().LoseGame();
          startMenu.GetComponent<CanvasGroup>().alpha = 1;
      }
    }

    public void StartGame()
    {
      if(!gameIsRunning)
      {
        gameIsRunning = true;
        timeRemaining = 30;
        score = 0;
        player.transform.localPosition = new Vector3(2.5F, 1.0F, 0.0F);
        player.GetComponent<PlayerScript>().StartGame();
        startMenu.GetComponent<CanvasGroup>().alpha = 0;
      }
    }

    public void LoadLowerLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadUpperLevel()
    {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
