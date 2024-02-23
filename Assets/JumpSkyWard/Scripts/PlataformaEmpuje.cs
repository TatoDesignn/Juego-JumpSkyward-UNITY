using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaEmpuje : MonoBehaviour
{
    Rigidbody2D rb;
    private Vector2 posicion;

    private void Start()
    {
        posicion = transform.position;
        rb = GetComponent<Rigidbody2D>();    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Restablecer"))
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = posicion;
        }
    }
}
