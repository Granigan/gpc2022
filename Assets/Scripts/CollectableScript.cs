using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
  public GameObject timer;
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
    Debug.Log("2d collision");
    if(other.transform.tag == "Player")
    {
      timer.GetComponent<TMPTimerScript>().AddBonusTime(5);
    }
    // remove this object
    Destroy(gameObject);
  }
}
