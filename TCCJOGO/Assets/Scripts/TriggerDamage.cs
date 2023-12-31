using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;
    public Player player;

    private void OnCollisionEnter2D (Collision2D collision) 
    {
        if (collision.gameObject.tag == "Player")
        {
            player.KbCount = player.kBTime;
            if(collision.transform.position.x <= transform.position.x)
            {
                player.isKnockRight = true;
            }
            if(collision.transform.position.x > transform.position.x)
            {
                player.isKnockRight = false;
            }
            heart.vida--;
        }   
    }
    
}
