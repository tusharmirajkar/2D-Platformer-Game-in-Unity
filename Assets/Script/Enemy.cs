using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    public float walkSpeed = 1.5f;
    public Transform groundCheck;
    public float distance = 0.3f;
    public LayerMask WhatisGround ;
    private bool facingleft;
    public float attackRange = 5f;
    public LayerMask WhatIsPlayer;
    public Transform player;
    public float chaseSpeed = 2f;
    public float retriveDistance = 3f;
    private Animator animator;
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        facingleft = true;
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
        boxCollider = this.gameObject.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (maxHealth <= 0)
        {
            Die();
        }

        Collider2D collinfo = Physics2D.OverlapCircle(transform.position, attackRange, WhatIsPlayer);
        if (collinfo)
        {
            if (player.position.x > transform.position.x && facingleft)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                facingleft = false;
            }
            else if (player.position.x < transform.position.x && !facingleft)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                facingleft = true;
            }
            Vector2 target = new Vector2(player.position.x, transform.position.y);

            if (Vector2.Distance(transform.position, target) > retriveDistance)
            {
                animator.SetBool("Attack", false);
                transform.position = Vector2.MoveTowards(transform.position, target, chaseSpeed * Time.deltaTime);
                
            }
            else
            {
                animator.SetBool("Attack", true);
            }
            
        }
        else
        {
            petrol();
        }
    }
    void petrol()
    {
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);

        RaycastHit2D hitInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance, WhatisGround);

        if (hitInfo == false)
        {
            if (facingleft)
            {
                transform.eulerAngles = new Vector3(0f, -180f, 0f);
                facingleft = false; 
            }
            else
            {
                 transform.eulerAngles = new Vector3(0f, 0f, 0f);
                 facingleft = true; 
            }
        }
    }
    public void TakeDamage(int damageAmmount)
    {
        if (maxHealth <= 0)
        {
            return;
        }
        maxHealth -= damageAmmount;
        animator.SetTrigger("Hit");
        CamShake.instance.Shake(2.5f, .15f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        if (groundCheck == null)
        {
            return;
        } 
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(groundCheck.position, Vector2.down * distance);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }
    }
    public void ShakeCam()
    {
        CamShake.instance.Shake(4f, .18f);
    }
    void Die()
    {
        animator.SetBool("Dead", true);
        rb.gravityScale = 0f;
        boxCollider.enabled = false;
        Destroy(this.gameObject, 5f);
    }
}
