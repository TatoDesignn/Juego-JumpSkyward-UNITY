using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    PlayerController player;
    Animator animator;

    public Rigidbody2D rb;
    public float velocidad;
    public float vida;

    public LayerMask capaAbajo;
    public LayerMask capaEnfrente;

    public float distanciaAbajo;
    public float distanciaEnfrente;

    public Transform controladorAbajo;
    public Transform controladorEnfrente;

    public bool informacionAbajo;
    public bool informacionEnfrente;

    private bool mirandoDerecha = true;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        informacionEnfrente = Physics2D.Raycast(controladorEnfrente.position, transform.right, distanciaEnfrente, capaEnfrente);
        informacionAbajo = Physics2D.Raycast(controladorAbajo.position, transform.up * -1, distanciaAbajo, capaAbajo);

        if(informacionEnfrente || !informacionAbajo)
        {
            Girar(0);
        }

    }

    private void Girar(float correr)
    {

        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y + 180, 0f);

        if (mirandoDerecha)
        {
            velocidad = -2;
        }
        else if (!mirandoDerecha)
        {
            velocidad = 2;
        }

        if (velocidad > 0)
        {
            velocidad = -1 * (velocidad + correr);
        }
        else if (velocidad < 0)
        {
            correr *= -1;
            velocidad = -1 * (velocidad + correr);
        }
    }

    public void Daño(float daño)
    {
        vida -= daño;

        if(vida >=1)
        {
            Girar(4);
            animator.SetTrigger("Hit");
        }
        else if(vida == 0)
        {
            velocidad = 0;
            animator.SetTrigger("Muerte");
        }

        
    }

    public void Muerte()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorAbajo.transform.position, controladorAbajo.transform.position + transform.up * -1 * distanciaAbajo);
        Gizmos.DrawLine(controladorEnfrente.transform.position, controladorEnfrente.transform.position + transform.right * distanciaEnfrente);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Personaje"))
        {
            player.salud -= 1;
            player.Vida();
            Girar(4);
        }
    }
}
