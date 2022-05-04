using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScript : MonoBehaviour
{

  private TextMeshProUGUI menuText;
  private GameObject gameManager;

  // Start is called before the first frame update
  void Start()
  {
    menuText = GetComponent<TextMeshProUGUI>();
    // menuText.text = "Press Enter\nto Play";
    this.InitGame();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void InitGame()
  {
    menuText.text = "Press Enter\nto Play";
  }

  public void WinGame()
  {
    menuText.text = "Awesome!\nYou survived!";
  }

  public void LoseGame()
  {
    menuText.text = "Game Over!";
  }
}
