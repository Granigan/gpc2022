using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    private TextMeshProUGUI scoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Nothing to update here
    }

    public void DisplayScore(int scoreToDisplay)
    {
        scoreDisplay.text = scoreToDisplay.ToString();
    }


}
