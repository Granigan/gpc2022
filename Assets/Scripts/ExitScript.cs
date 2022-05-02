using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private GameObject gameManager;

    // Start is called before the first frame update
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
        Debug.Log("exit collision");
        if(other.transform.tag == "Player")
        {
          gameManager.GetComponent<GameManagerScript>().EndGame();
        }
    }
}
