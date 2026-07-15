using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb;
    public float JumpHight =  7f;
    public float moveSpeed = 5f;
    private float movement;
    private bool IsGround;
    private bool facingRight;
    public Transform groundCheck;
    public float checkRadius = .2f;
    public LayerMask groundLayer;
    public GameObject arrowPrefab;
    public Transform spawnPosition;
    public float arrowSpeed = 20f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsGround = true;
        facingRight = true;
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Collider2D callinfo = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        if (callinfo)
        {
            IsGround = true;
        }
        flip();
        PlayerRunAnimation();

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Fire");
        }
    }
    private void FixedUpdate()
    {
    rb.linearVelocity = new Vector2(movement * moveSpeed, rb.linearVelocity.y);
    }
    public void FireArrow()
    {
        GameObject tempArrowPrefab = Instantiate(arrowPrefab, spawnPosition.position, spawnPosition.rotation);
        tempArrowPrefab.GetComponent<Rigidbody2D>().linearVelocity = spawnPosition.right * arrowSpeed;
    }
    void PlayerRunAnimation()
    {
        if(Mathf.Abs(movement) > 0f)
        {
            animator.SetFloat("Run", 1f);
        }
        else if(movement < 0.1f)
        {
            animator.SetFloat("Run", 0f);
        }
    }
    void flip()
    {
        if (movement < 0 && facingRight == true)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }
        else if (movement > 0 && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }
    }
    void Jump()
    {
        if (IsGround == true)
        {Vector2 velocity = rb.linearVelocity;
        velocity.y = JumpHight;
        rb.linearVelocity = velocity;
        IsGround = false;
        animator.SetBool("Jump", true);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            animator.SetBool("Jump", false);
        }
    }
}
