using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour

{
   [SerializeField] private bool attackBool;

    public Animator anim;
    public SpriteRenderer sprite;
    public GameObject endGame;

    public int life;
    public float moveSpeed;
    private float ultimaPosicaoX;

    public Transform[] pointsToMove;
    public int startingPoint;

    public BoxCollider2D colliderAtk;
    public BoxCollider2D colliderCheckAtk;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        transform.position = pointsToMove[startingPoint].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startingPoint == 0.0)
        {
            sprite.flipX = true;
            colliderAtk.offset = new Vector2(-2.99f, -1.35f);
            colliderCheckAtk.offset = new Vector2 (-1.55f, -0.87f);
        }
        else
        {
            sprite.flipX = false;
            colliderAtk.offset = new Vector2(2.99f, -1.55f);
            colliderCheckAtk.offset = new Vector2 (1.55f, -0.87f);
        }

    }
    
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].transform.position, moveSpeed * Time.deltaTime);
        
        if(BossCheckAttack.checkAttack == true)
        {
           
            StartCoroutine("Attack");
        }

        transform.position = Vector2.MoveTowards(transform.position, pointsToMove[startingPoint].position, moveSpeed * Time.deltaTime);

        if (transform.position == pointsToMove[startingPoint].position)
        {
            startingPoint += 1;
            ultimaPosicaoX = transform.localPosition.x;
            
            if (startingPoint >= pointsToMove.Length)
            {
                startingPoint = 0;
            }
        }

        if (moveSpeed != 0)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }

    public void EnemyDead()
    {
        life = 0;
        
        moveSpeed = 0;
        Destroy(transform.gameObject.GetComponent<BoxCollider2D>());
        Destroy(transform.gameObject.GetComponent<Rigidbody2D>());
        Destroy(colliderAtk);
        Destroy(colliderCheckAtk);
        Destroy(this);
        Time.timeScale = 0f;
        endGame.SetActive(true);
    }

    IEnumerator Attack()
    {
        anim.SetBool("Attack", true);
        moveSpeed = 0;
        
        yield return new WaitForSeconds(0.85f);
        anim.SetBool("Attack", false);
        moveSpeed= 2;


        BossCheckAttack.checkAttack = false;
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        
        if (collision.gameObject.layer == 9)
        {
            DamageEnemy();
        }
    }

    public void DamageEnemy ()
    {
        life--;
        
        if (life < 1)
        {
            moveSpeed = 0;
            anim.SetTrigger("Dead");
            StopCoroutine("Attack");
            
            
        }
    }
}


