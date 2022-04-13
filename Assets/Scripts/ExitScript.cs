using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScript : MonoBehaviour
{
    private GameObject timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        timer = GameObject.Find("TMP Timer");
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
          timer.GetComponent<TMPTimerScript>().EndGame();
          player = GameObject.Find("Player");
          player.GetComponent<PlayerScript>().EndGame();
        }
    }
}
