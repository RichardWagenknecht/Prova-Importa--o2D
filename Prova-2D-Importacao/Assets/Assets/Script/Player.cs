using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    public float Speed;
    Rigidbody2D rb;
    float horizontal;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1;
            spriteRenderer.flipX = false;
            animator.SetTrigger("Correr");
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
            spriteRenderer.flipX = true;
            animator.SetTrigger("Correr");
        }
        else 
        {
            horizontal = 0;
            animator.SetTrigger("Idle");
        }

        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Diamante"))
        {
          Destroy(collision.gameObject);
            Debug.Log("Coletou");
        }
    }
}
