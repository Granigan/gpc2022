using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
  private GameObject gameManager;
  private int collectableType;
  private int pointMultiplier;
  private int baseValue;
  private int pointValue;

  private SpriteRenderer spriteRenderer;
  private Sprite[] sprites;
  
  // Start is called before the first frame update

  void Awake()
  {
    collectableType = Random.Range(0, 7);
    pointMultiplier = 2;
    baseValue = 5;
    pointValue = collectableType * pointMultiplier + baseValue;
    sprites = new Sprite[8];
    spriteRenderer = GetComponent<SpriteRenderer>();
    loadSpritesToArray();
    spriteRenderer.sprite = sprites[collectableType];
  }

  void Start()
  {
    gameManager = GameObject.Find("GameManager");
  }

  // Update is called once per frame
  void Update()
  {

  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if(other.transform.tag == "Player")
    {
      gameManager.GetComponent<GameManagerScript>().addScore(pointValue);
    }
    // remove this object
    Destroy(gameObject);
  }

  private void loadSpritesToArray()
  {
    sprites[0] = Resources.Load<Sprite>("CollectableSprites/icons_8_15");
    sprites[1] = Resources.Load<Sprite>("CollectableSprites/icons_8_42");
    sprites[2] = Resources.Load<Sprite>("CollectableSprites/icons_8_57");
    sprites[3] = Resources.Load<Sprite>("CollectableSprites/icons_8_58");
    sprites[4] = Resources.Load<Sprite>("CollectableSprites/icons_8_77");
    sprites[5] = Resources.Load<Sprite>("CollectableSprites/icons_8_83");
    sprites[6] = Resources.Load<Sprite>("CollectableSprites/icons_8_85");
    sprites[7] = Resources.Load<Sprite>("CollectableSprites/icons_8_99");
  }
}
