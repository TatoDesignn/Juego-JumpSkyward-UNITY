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
    public float distanciaLinea;
    public LayerMask capaJugador;
    public float tiempoEntreDisparo;

    [Space]
    private bool enRango;
    private float tiempoUltimoDisparo;
    private float tiempoEsperaDisparo;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        enRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);
        
        if (enRango)
        {
            if(Time.time > tiempoEntreDisparo + tiempoUltimoDisparo)
            {
                animator.SetTrigger("Disparo");
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }
        }
    }

    private void Disparar()
    {
        Instantiate(bala, controladorDisparo.position, controladorDisparo.rotation);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }
}
