using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel1 : MonoBehaviour
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
            SceneManager.LoadScene("Fase 3");
            MusicManager.mManager.PlaySound(3);
        }   
    }
}
