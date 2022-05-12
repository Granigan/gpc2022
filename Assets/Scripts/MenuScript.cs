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
    this.InitGame();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void InitGame()
  {
    menuText.transform.localPosition = new Vector3(0.0F, 50.0F, 0.0F);
    menuText.text = "Press Enter\nto Play";
  }

  public void WinGame()
  {
    menuText.transform.localPosition = new Vector3(0.0F, 0.0F, 0.0F);
    menuText.text = "Awesome!\nYou survived!";
  }

  public void LoseGame()
  {
    menuText.transform.localPosition = new Vector3(0.0F, 0.0F, 0.0F);
    menuText.text = "Game Over!";
  }
}
