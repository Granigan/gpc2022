using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
  private GameObject score;
  private int pointValue;

  private SpriteRenderer spriteRenderer;
  public Sprite[] sprites;
  
  // Start is called before the first frame update

  void Start()
  {
    score = GameObject.Find("TMP Score");
    pointValue = Random.Range(1, 5);
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.transform.tag == "Player")
    {
      score.GetComponent<ScoreScript>().addScore(pointValue);
    }
    // spriteRenderer.sprite = sprites[0];
    // remove this object
    Destroy(gameObject);
  }
}
