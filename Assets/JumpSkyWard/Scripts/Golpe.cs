using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    [Space]
    [Header("Control Ataque")]
    public int daño;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;

    [Space]
    [Header("Variables globales")]
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && tiempoSiguienteAtaque <= 0)
        {
            tiempoSiguienteAtaque = tiempoEntreAtaque;
            Ataque();
        }
    }

    private void Ataque()
    {
        animator.SetTrigger("Golpe");
    }
}
