using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovimiento : MonoBehaviour
{
    [Space]
    [Header("Control Plataforma")]
    [SerializeField] private Transform[] puntosMovimiento;
    [SerializeField] private float velocidad;

    [Space]
    private int siguientePunto = 1;
    private bool ordenPlataforma = true;

    void Update()
    {
        if(ordenPlataforma && siguientePunto + 1 >= puntosMovimiento.Length)
        {
            ordenPlataforma = false;
        }

        if (!ordenPlataforma && siguientePunto <= 0)
        {
            ordenPlataforma = true;
        }

        if(Vector2.Distance(transform.position, puntosMovimiento[siguientePunto].position) < 0.1f)
        {
            if (ordenPlataforma )
            {
                siguientePunto += 1;
            }
            else
            {
                siguientePunto -= 1;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, puntosMovimiento[siguientePunto].position, velocidad * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Personaje"))
        {
            collision.transform.SetParent(null);
        }
    }
}
