using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour
{
    public string cena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Fase 5 BOSS");
            MusicManager.mManager.PlaySound(5);
        }   
    }
}
