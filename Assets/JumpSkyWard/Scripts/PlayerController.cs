using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    [Space]
    [Header("Movimiento jugador: ")]
    public float velocidad;
    public float saltar;

    [Space]
    [Header("Variable globales: ")]
    bool moving;
    bool moving2;
    bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        if(moving = Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(moving2 = Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(Input.GetKey(KeyCode.W) && canJump)
        {
            rb.AddForce(Vector2.up * saltar, ForceMode2D.Impulse);
            canJump = false;
        }
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity;
        newVelocity.x = Input.GetAxisRaw("Horizontal") * velocidad;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Suelo")
        {
            canJump = true;
        }
    }
}
