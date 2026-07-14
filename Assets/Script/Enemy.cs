using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public Transform groundCheck;
    public float distance = 0.3f;
    public LayerMask WhatisGround ;
    private bool facingleft;
    public float attackRange = 5f;
    public LayerMask WhatIsPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        facingleft = true;
    }

    void Update()
    {
        Collider2D collinfo = Physics2D.OverlapCircle(transform.position, attackRange, WhatIsPlayer);
        if (collinfo)
        {
            
        }
        else
        {
        transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);

        RaycastHit2D hitInfo =Physics2D.Raycast(groundCheck.position, Vector2.down, distance, WhatisGround);

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
    }
    // void petrol()
    // {
    //     transform.Translate(Vector2.left * Time.deltaTime * walkSpeed);

    //     RaycastHit2D hitInfo =Physics2D.Raycast(groundCheck.position, Vector2.down, distance, WhatisGround);

    //     if (hitInfo == false)
    //     {
    //         if (facingleft)
    //         {
    //             transform.eulerAngles = new Vector3(0f, -180f, 0f);
    //             facingleft = false; 
    //         }
    //         else
    //         {
    //              transform.eulerAngles = new Vector3(0f, 0f, 0f);
    //              facingleft = true; 
    //         }
    //     }
    // }
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
}
