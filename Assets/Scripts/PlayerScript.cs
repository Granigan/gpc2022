using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  private float horizontal;
  private float vertical;
  private bool gameIsRunning;
  public float speed = 1.0f;
  Rigidbody2D rb;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
      if(gameIsRunning) {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
      }
    }

    public void EndGame()
    {
      gameIsRunning = false;
      rb.velocity = new Vector2(0, 0);
    }
}
