using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    float speed = 4f;
    float horizontal;
    float forcaPulo = 9f;
    bool noChao;
    public Transform[] pontosSpawn = new Transform[5];
    public GameObject Diamante;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Spawnar();
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
        if (Input.GetKey(KeyCode.UpArrow) && noChao)
        {
            rb.velocity = new Vector2(rb.velocity.x, forcaPulo);
            animator.SetTrigger("Pular");
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Diamante"))
        {
          Destroy(collision.gameObject);
          Spawnar();
        }
        else if (collision.gameObject.CompareTag("Chão"))
        {
            noChao = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chão"))
        {
            noChao = false;
        }
    }
    private void Spawnar()
    {
        Instantiate(Diamante, pontosSpawn[Random.Range(1,5)].position,Quaternion.identity);
    }
}
