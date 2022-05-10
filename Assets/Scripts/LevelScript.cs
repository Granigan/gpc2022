using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelScript : MonoBehaviour
{
  private TextMeshProUGUI levelDisplay;

  // Start is called before the first frame update
  void Start()
  {
      levelDisplay = GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  void Update()
  {
      // Nothing to update here
  }

  public void DisplayLevel(int levelToDisplay)
  {
      levelDisplay.text = levelToDisplay.ToString();
  }
}
