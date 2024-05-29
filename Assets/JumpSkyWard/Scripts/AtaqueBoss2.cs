using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueBoss2 : MonoBehaviour
{
    PlayerController player;
    Jefefinal jefe;
    Animator animator;

    [Space]
    [Header("Configuracion ataque jefe:")]
    [SerializeField] private float distanciaLinea;
    [SerializeField] private LayerMask capaJugador;
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private GameObject ataqueEspecial;
    [SerializeField] private Transform[] zonas;

    private bool enRango;
    private bool esperarAtaque = true;
    private bool esperarAtaqueEspecial = true;
    private int contandor = 0;
    private int contandorTerminar = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
        animator = GetComponentInParent<Animator>();
        jefe = GetComponentInParent<Jefefinal>();
    }

    private void Update()
    {
        if (jefe.transformacion && !jefe.enojado)
        {
            enRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);

            if (enRango && esperarAtaque)
            {
                esperarAtaque = false;
                Invoke("Ataque", 2.5f);
            }
        }
        else if (jefe.enojado && esperarAtaqueEspecial)
        {
            esperarAtaqueEspecial = false;
            animator.SetTrigger("Enojado");
            Invoke("AtaqueEspecial", 1f);
        }
    }

    private void AtaqueEspecial()
    {
        contandorTerminar += 1;

        if (contandor == 0)
        {
            Instantiate(ataqueEspecial, zonas[0].position, zonas[0].rotation);
        }
        else if(contandor == 1)
        {
            Instantiate(ataqueEspecial, zonas[2].position, zonas[2].rotation);
        }
        else if (contandor == 2)
        {
            Instantiate(ataqueEspecial, zonas[1].position, zonas[1].rotation);
        }
        else if (contandor == 3)
        {
            Instantiate(ataqueEspecial, zonas[3].position, zonas[3].rotation);
            contandor = -1;
        }

        contandor += 1;
        esperarAtaqueEspecial = true;

        if (contandorTerminar > 17)
        {
            jefe.enojado = false;
            animator.SetTrigger("Normalidad");
            esperarAtaqueEspecial = false;
            esperarAtaque = true;
        }
    }

    private void Ataque()
    {
        if (!jefe.enojado && !jefe.muerto)
        {
            jefe.DesactivarBox();
            int seleccion = Random.Range(0, 4);

            Debug.Log(seleccion);

            if (seleccion == 0)
            {
                animator.SetTrigger("Ataque1");
            }
            else if (seleccion == 2)
            {
                animator.SetTrigger("Ataque2");
            }
            else if (seleccion == 3)
            {
                animator.SetTrigger("Ataque3");
            }

            esperarAtaque = true;
            jefe.ActivarBox();
        }  
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            esperarAtaque = true;
            player.Vida(1);
        }
    }
}
