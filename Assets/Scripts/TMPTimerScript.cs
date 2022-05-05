using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPTimerScript : MonoBehaviour
{
  private TextMeshProUGUI timer;

  private void Start()
  {
    // Starts the timer automatically
    timer = GetComponent<TextMeshProUGUI>();
  }
  
  void Update()
  {
    // Nothing to update here
  }
  
  public void DisplayTime(float timeToDisplay)
  {
    timeToDisplay += 1;
    float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
    float seconds = Mathf.FloorToInt(timeToDisplay % 60);
    timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
  }

}

