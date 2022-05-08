using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
  private float horizontal;
  private float vertical;
  private bool gameIsRunning;
  public float speed = 1.0f;

  private bool fadingIn = true;
  private bool facingLeft = true;

  Rigidbody2D rb;
  SpriteRenderer rend;
  
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      rend = GetComponent<SpriteRenderer>();
      gameIsRunning = false;
    }

    // Update is called once per frame
    void Update()
    {
      if(gameIsRunning) {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(horizontal > 0 && facingLeft)
        {
          this.FaceRight();
        }
        if(horizontal < 0 && !facingLeft)
        {
          this.FaceLeft();
        }
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
      }

      if(gameIsRunning && fadingIn)
      {
        Color playerColor = rend.color;
        float new_a = Math.Min(1.0F, playerColor.a + 0.02F);
        fadingIn = (new_a != 1.0F);
        playerColor.a = new_a;
        rend.color = playerColor;
      }

    }

    public void FaceLeft()
    {
      facingLeft = true;
      rend.flipX = false;
    }
    public void FaceRight()
    {
      facingLeft = false;
      rend.flipX = true;
    }

    public void StartGame()
    {
      gameIsRunning = true;
      fadingIn = true;
      facingLeft = true;
      Color playerColor = rend.color;
      playerColor.a = 0.0F;
      rend.color = playerColor;

    }

    public void EndGame()
    {
      gameIsRunning = false;
      rb.velocity = new Vector2(0, 0);
    }
}
