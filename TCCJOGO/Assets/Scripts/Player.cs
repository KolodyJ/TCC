using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int coins;
    public float speed = 3f;
    private BoxCollider2D colliderAtkPlayer;
    public static float horizontalMoviment;
    public Animator playerAnim;
    private Rigidbody2D rigidbody2d;
    private Manager1 mg;
    public float velocidadeMovimento;
    private SpriteRenderer spriteRenderer;
    public float jumpForce;
    public bool inFloor = true;
    [SerializeField] private DectorColision dectorColision;
    [SerializeField] private bool attackBool;
    public float kBForce;
    public float KbCount;
    public float kBTime;
    public bool isKnockRight;
    public static bool isSword;
    public Transform attackCheck;
    public float radiusAttack;
    public LayerMask layerEnemy;
    float timeNextAttack;
    Skeleton Skeleton;

    // Start is called before the first frame update
    void Start()
    {
        mg = Manager1.mg;
        mg.coins = 0;
        colliderAtkPlayer = GetComponent<BoxCollider2D>();
        playerAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();

        isSword = false;
    }

    private void FixedUpdate()
    {
       
        KnockLogic();
        
    }
    
    void KnockLogic()
    {
        if(KbCount < 0)
        {
            MovePlayer();
        }
        else
        {
            if(isKnockRight == true)
            {
                rigidbody2d.velocity = new Vector2(-kBForce, kBForce);
            }
            if (isKnockRight == false)
            {
                rigidbody2d.velocity = new Vector2(kBForce, kBForce);
            }
        }
        KbCount -= Time.deltaTime;
    }
    void Update()
    {
        if (Input.GetButtonDown ("Fire3")){
            attackBool = true;
            playerAnim.SetBool("Attack", true);
        }

        if (timeNextAttack <= 0f)
        {
            if (Input.GetButtonDown("Fire3") && rigidbody2d.velocity == new Vector2 (0,0 ))
            {
                playerAnim.SetBool ("Attack", true);
                timeNextAttack = 0.2f;
                
            } else {
                timeNextAttack -= Time.deltaTime;
            }
        }

        PlayerAnimation();
        playerAnim.SetBool("Sword", isSword);
        Jump();
       
    }

    public void MovePlayer ()
    {
        float horizontalMoviment = Input.GetAxis("Horizontal");

        bool podeMover = true;
        
        if (podeMover){
         rigidbody2d.velocity = new Vector2 (horizontalMoviment * speed, rigidbody2d.velocity.y);
        if((horizontalMoviment > 0 && spriteRenderer.flipX == true) || (horizontalMoviment < 0 && spriteRenderer.flipX == false))
        {
            Flip();
        }

        }

        
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            playerAnim.SetBool("Jump", true);
            rigidbody2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            inFloor = false;        
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
        else if (collision.gameObject.name == "Platform")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
        else if (collision.gameObject.name == "Barrel")
        {
            playerAnim.SetBool("Jump", false);
            inFloor = true;
        }
    }

    void PlayerAnimation()
    {
        if (rigidbody2d.velocity.x == 0 && rigidbody2d.velocity.y == 0)
        {
            playerAnim.SetBool ("Walk", false);
        }else if (rigidbody2d.velocity.x != 0 && rigidbody2d.velocity.y == 0)
        {
            playerAnim.SetBool ("Walk", true);
        }
    }

    void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
        attackCheck.localPosition = new Vector2(-attackCheck.localPosition.x, attackCheck.localPosition.y);
    }

    void EndAttack ()
    {
        attackBool = false;
        playerAnim.SetBool ("Attack", false);
    }

    void PlayerAttack(){
        Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll (attackCheck.position, radiusAttack, layerEnemy);
        for (int i = 0; i < enemiesAttack.Length; i++)
        {
            Debug.Log("Enemy");
        }
    }

     void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttack);
    }

     private void OnTriggerEnter2D(Collider2D collision) 
     {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            mg.coins++;
            mg.coinsText.text = mg.coins.ToString();
        }   
     } 
        
    
}
