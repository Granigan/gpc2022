using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartHelpScript : MonoBehaviour
{
  private TextMeshProUGUI helpText;
  private GameObject gameManager;

  // Start is called before the first frame update
  void Start()
  {
    helpText = GetComponent<TextMeshProUGUI>();
    helpText.text =
      "Collect items and exit before dungeon collapses.\n\u25C4\u25B2\u25BC\u25BA to Move\n[P] to Pause";
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Hide()
  {
    helpText.enabled = false;
  }

  public void Show()
  {
    helpText.enabled = true;
  }

}
