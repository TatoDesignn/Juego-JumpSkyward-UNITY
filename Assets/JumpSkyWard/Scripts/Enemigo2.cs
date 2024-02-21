using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    Animator animator;

    [Space]
    [Header("Control Enemigo: ")]
    public GameObject bala;
    public Transform controladorDisparo;
    public CinemachineVirtualCamera cinemachine;
    public Transform personaje;
    public GameObject punto;

    public float distanciaLinea;
    public LayerMask capaJugador;
    public float tiempoEntreDisparo;

    [Space]
    private bool enRango;
    private bool muerte = false;
    private float tiempoUltimoDisparo;
    private float tiempoEsperaDisparo;
    private float vida = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        enRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);
        
        if (enRango && !muerte)
        {
            if(Time.time > tiempoEntreDisparo + tiempoUltimoDisparo)
            {
                animator.SetTrigger("Disparo");
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        }
    }

    public void Daño(float daño)
    {
        vida -= daño;

        if (vida >= 1)
        {
            animator.SetTrigger("Hit");
        }
        else if (vida == 0)
        {
            muerte = true;
            animator.SetTrigger("Dead");
            Invoke("Destruir", 1f);
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }

    public void Destruir()
    {
        Destroy(punto.gameObject);
        cinemachine.Follow = personaje;
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }
}
