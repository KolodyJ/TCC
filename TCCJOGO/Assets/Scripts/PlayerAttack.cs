using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Skeleton Skeleton;

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.layer == 8)
        {
            Skeleton.DamageEnemy();
        }
    }
}
