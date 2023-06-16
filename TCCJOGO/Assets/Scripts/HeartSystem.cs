using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    Player isPlayer;
    public bool isDead;
    public int vida;
    public int vidaMaxima;
    public Animator playerAnim;
    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    public GameObject gameOver; 
    // Start is called before the first frame update
    public void Start()
    {   
        isPlayer = GetComponent<Player>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        HealtLogic();
        DeadState();
    }

    public void HealtLogic()
    {
        for (int i = 0; i < coracao.Length; i++)
        {
            if(vida > vidaMaxima)
            {
                vida = vidaMaxima;
            }
            if(i < vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }
            if (i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else {
                coracao[i].enabled = false;
            }
        }
    }


    public void DeadState()
    {
        if(vida <=0)
        {
            isDead = true;
            playerAnim.SetTrigger("Dead");
            GetComponent<Player>().enabled = false;
            Destroy(gameObject, 1.0f);   
            Time.timeScale = 0f;
            gameOver.SetActive(true);
            
        }
    
    }
    
   
}
