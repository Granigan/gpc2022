using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ModeScript : MonoBehaviour
{
  private TextMeshProUGUI modeText;
  private GameObject gameManager;

  // Start is called before the first frame update
  void Start()
  {
    modeText = GetComponent<TextMeshProUGUI>();
    this.PromptFastmode(false);
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PromptFastmode(bool mode)
  {
    modeText.text = "[F]ast mode is " + (mode ? "on" : "off");
  }

}
