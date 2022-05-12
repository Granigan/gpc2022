using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseMenuScript : MonoBehaviour
{
  private TextMeshProUGUI pauseMenuText;
  private GameObject gameManager;

  // Start is called before the first frame update
  void Start()
  {
    pauseMenuText = GetComponent<TextMeshProUGUI>();
    this.InitGame();
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

}
