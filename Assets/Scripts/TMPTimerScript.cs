using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPTimerScript : MonoBehaviour
{
  public float timeRemaining = 10;
  private bool gameIsRunning;
  private TextMeshProUGUI timer;
  private GameObject gameManager;

  private void Start()
  {
    // Starts the timer automatically
    gameIsRunning = false;
    timer = GetComponent<TextMeshProUGUI>();
    gameManager = GameObject.Find("GameManager");
  }
  
  void Update()
  {
    if (gameIsRunning && timeRemaining > 0)
    {
      timeRemaining -= Time.deltaTime;
      DisplayTime(timeRemaining);
    } else
    {
      timeRemaining = 0;
      gameIsRunning = false;
      gameManager.GetComponent<GameManagerScript>().LoseGame();
    }
  }
  
  void DisplayTime(float timeToDisplay)
  {
    timeToDisplay += 1;
    float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
  }

  public void AddBonusTime(float timeToAdd) 
  {
    timeRemaining += timeToAdd;
  }

  public void StartGame()
  {
    timeRemaining = 30;
    gameIsRunning = true;
  }

  public void EndGame()
  {
    gameIsRunning = false;
  }
}

