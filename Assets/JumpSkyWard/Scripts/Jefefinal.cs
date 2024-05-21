using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Jefefinal : MonoBehaviour
{
    Animator animator;
    BoxCollider2D boxCollider;
    [Space]
    [Header("Configuracion de jefe:")]
    [SerializeField] private float vidaMini;
    [SerializeField] private float vidaGigante;
    [SerializeField] private BarraVidaJefe barraVida;
    [SerializeField] private GameObject canvas;

    public bool transformacion = false;
    public bool enojado = false;
    public bool yaSeEnojo = false;
    public bool muerto = false;


    void Start()
    {
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        canvas.SetActive(false);

    }

    public void Daño(float daño)
    {

        if(vidaGigante < 15 && vidaGigante > 10 && !yaSeEnojo)
        {
            enojado = true;
            yaSeEnojo = true;
        }

        if(!transformacion)
        { 
            if(vidaMini > 0)
            {
                animator.SetTrigger("hitMini");
                vidaMini -= daño;
            }
            else
            {
                animator.SetTrigger("transformar");
                Invoke("ActivarTransformacion", 2.5f);
            }
        }
        else if  (transformacion && !enojado)
        {
            vidaGigante -= daño;
            barraVida.CambiarVidaActual(vidaGigante);

            if(vidaGigante > 0)
            {
                animator.SetTrigger("hitGrande");
            }
            else
            {
                muerto = true;
                canvas.SetActive(false);
                animator.SetTrigger("Muerte");
                Invoke("Muerte", 2);
            }
        }
    }

    public void ActivarBox()
    {
        boxCollider.enabled = true;
    }

    public void DesactivarBox()
    {
        boxCollider.enabled = false;
    }

    public void Muerte()
    {
        Destroy(gameObject);
    }

    private void ActivarTransformacion()
    {
        transformacion = true;
        canvas.SetActive(true);
        barraVida.InicializarBarraVida(vidaGigante);
    }
}
