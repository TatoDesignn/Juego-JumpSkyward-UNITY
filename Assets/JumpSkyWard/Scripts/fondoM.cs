using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoM : MonoBehaviour
{
    Rigidbody2D rb;
    public float velocidad;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocidad;
    }
}
