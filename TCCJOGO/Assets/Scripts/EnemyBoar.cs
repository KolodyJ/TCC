using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoar : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D collision) 
    {
      if(collision.gameObject.tag == "Waek Point")
      {
        Destroy(collision.gameObject);
      }   
    }
}
