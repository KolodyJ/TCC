using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVigilant : MonoBehaviour
{
    [SerializeField] private Transform[] pontosDoCaminho;
    [SerializeField] private float velocidadeDeMovimento;

    PolygonCollider2D colliderBoar;
    Rigidbody2D rbBoar;
    Animator animBoar;

    private int pontoAtual;
    private float ultimaPosicaoX;

    private void Awake () {
        rbBoar = GetComponent<Rigidbody2D>();
        animBoar = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        MovimentarInimigo();
        EspelharNaHorizontal();
    }

    private void MovimentarInimigo ()
    {
        transform.position = Vector2.MoveTowards(transform.position, pontosDoCaminho[pontoAtual].position, velocidadeDeMovimento * Time.deltaTime);

        if (transform.position == pontosDoCaminho[pontoAtual].position)
        {
            pontoAtual += 1;
            ultimaPosicaoX = transform.localPosition.x;
            
            if (pontoAtual >= pontosDoCaminho.Length)
            {
                pontoAtual = 0;
            }
        }
    }

    private void EspelharNaHorizontal() 
    {
        if (transform.localPosition.x > ultimaPosicaoX) 
        {
            transform.localScale = new Vector3 (1f, 1f, 1f);    
        }
        if (transform.localPosition.x < ultimaPosicaoX) 
        {
            transform.localScale = new Vector3 (-1f, 1f, 1f);    
        }
    }
}
