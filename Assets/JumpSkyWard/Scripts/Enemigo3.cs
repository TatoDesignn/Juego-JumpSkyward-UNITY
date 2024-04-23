using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    Animator animator;

    [Space]
    [Header("Configuracion enemigo 3")]
    [SerializeField] private float vida;
    [SerializeField] private Transform controladorEnemigo;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private LayerMask capaJugador;
    [SerializeField] private float distanciaLinea;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float radioGolpe;
    [SerializeField] private Vector2 size;
    [SerializeField] private float angulo;

    private bool enRango;
    private float tiempoUltimoAtaque;
    private float tiempoEsperaAtaque;

    void Start()
    {
        animator = GetComponent<Animator>();  
    }


    void Update()
    {
        enRango = Physics2D.Raycast(controladorEnemigo.position, transform.right, distanciaLinea, capaJugador);

        if(enRango )
        {
            if (Time.time > tiempoEntreAtaque + tiempoUltimoAtaque)
            {
                tiempoUltimoAtaque = Time.time;
                Invoke(nameof(Ataque), tiempoEsperaAtaque);
            }
        }
    }

    private void Ataque()
    {
        SoundManager.Instance.AtaqueSnake();
        animator.SetTrigger("Atacar");
        Collider2D[] objetos = Physics2D.OverlapBoxAll(controladorGolpe.position, size, angulo);

        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Personaje"))
            {
                collisionador.transform.GetComponent<PlayerController>().Vida(1);
            }
        }
    }

    public void Daño(float daño)
    {
        vida -= daño;
        SoundManager.Instance.HitSnake();
        if (vida >= 1)
        {
            animator.SetTrigger("hit");
            SoundManager.Instance.HitSnake();
        }
        else if (vida <= 0)
        {
            animator.SetTrigger("hit");
            SoundManager.Instance.MuerteSnake();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            animator.SetTrigger("Aparecer");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorEnemigo.position, controladorEnemigo.position + transform.right * distanciaLinea);
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
