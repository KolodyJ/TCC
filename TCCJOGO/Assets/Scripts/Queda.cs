using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Queda : MonoBehaviour
{
    public HeartSystem heart;

    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            heart.vida= 0;
        }   
    }
    private void OnCollisionEnter2D (Collision2D other) 
    {
    if (other.gameObject.tag == "Player")
        {
            heart.vida= 0;
        }   
    }
}
