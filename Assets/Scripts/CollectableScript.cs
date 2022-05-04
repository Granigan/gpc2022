using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
  private GameObject timer;
  private GameObject score;
  private float bonusTime;
  private int pointValue;

  private SpriteRenderer spriteRenderer;
  public Sprite[] sprites;
  
  // Start is called before the first frame update

  void Start()
  {
    timer = GameObject.Find("TMP Timer");
    score = GameObject.Find("TMP Score");
    pointValue = Random.Range(1, 5);
    spriteRenderer = GetComponent<SpriteRenderer>();
    bonusTime = 3.0f;
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("2d collision");
    if(other.transform.tag == "Player")
    {
      score.GetComponent<ScoreScript>().addScore(pointValue);
      timer.GetComponent<TMPTimerScript>().AddBonusTime(bonusTime);
    }
    // spriteRenderer.sprite = sprites[0];
    // remove this object
    Destroy(gameObject);
  }
}
