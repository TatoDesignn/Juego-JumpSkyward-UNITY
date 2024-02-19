using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{
    public float velocidad;

    public int daño;
    void Update()
    {
        transform.Translate(Time.deltaTime * velocidad * Vector2.right);
        Invoke("Destruir", 10f);
    }

    private void Destruir()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PlayerController player))
        {
            player.salud -= 1;
            player.Vida();
            Destroy(gameObject);
        }
    }
}
