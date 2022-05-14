using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
  private TextMeshProUGUI pauseMenuText;
  private Image[] images;
  private TextMeshProUGUI[] pointTexts;
  private GameObject gameManager;
  private int pointMultiplier = 2;
  private int baseValue = 5;

  // Start is called before the first frame update
  void Start()
  {
    // pauseMenuText = GetComponent<TextMeshProUGUI>();
    pauseMenuText =GameObject.Find("PauseMenuText").GetComponent<TextMeshProUGUI>();
    this.InitGame();
    this.ShowCollectables();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void InitGame()
  {
    pauseMenuText.transform.localPosition = new Vector3(0.0F, 125.0F, 0.0F);
    pauseMenuText.text = "Game is Paused";
  }

  public void ShowCollectables()
  {
    float topY = 0.0F;
    float stepY = 25.0F;
    images = GetComponentsInChildren<Image>();
    pointTexts = GetComponentsInChildren<TextMeshProUGUI>();
    foreach (Image img in images)
    {
      if (img.name.StartsWith("Collect"))
      // Show only the collectable images
      {
        int typ = int.Parse(img.name[img.name.Length - 1].ToString());
        img.transform.localPosition = new Vector3(-40.0F, topY - (typ * stepY), 0.0F);
        img.transform.localScale = new Vector3(0.25F, 0.25F, 1.0F);
      }
    }
    foreach (TextMeshProUGUI txt in pointTexts)
    {
      if (txt.name == "ColItems")
      {
        // Display column header for collectable images
        txt.transform.localPosition = new Vector3(-40.0F, topY + stepY, 0.0F);
        txt.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
        txt.text = "Item";
      }
      if (txt.name == "ColPoints")
      {
        // Display column header for collectable points
        txt.transform.localPosition = new Vector3(40.0F, topY + stepY, 0.0F);
        txt.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
        txt.text = "Points";
      }
      if (txt.name.StartsWith("Points"))
      {
        // Calculate points for each collectable type and display them
        int typ = int.Parse(txt.name[txt.name.Length - 1].ToString());
        txt.transform.localPosition = new Vector3(40.0F, topY - (typ * stepY), 0.0F);
        txt.transform.localScale = new Vector3(1.0F, 1.0F, 1.0F);
        int pointValue = typ * pointMultiplier + baseValue;
        txt.text = pointValue.ToString();
      }
    }
  }

}
