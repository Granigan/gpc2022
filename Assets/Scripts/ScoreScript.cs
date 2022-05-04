using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{

    private int score;
    private TextMeshProUGUI scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
    }

    public void addScore(int scoreToAdd) {
        score += scoreToAdd;
    }

}
