using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Personaje")
        {
            Invoke("Caida", 0.5f);
        }
    }

    private void Caida()
    {
        rb.gravityScale = 1f;
        Invoke("Destruir", 1f);
    }

    public void Destruir()
    {
        Destroy(gameObject);
        
    }
}
