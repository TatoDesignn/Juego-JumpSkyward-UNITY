using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Nave : MonoBehaviour
{
    Animator animator;
    [Space]
    [Header("Configuracion Nave: ")]
    public CinemachineVirtualCamera cinemachine;
    public Transform nave;
    public Transform personajeT;
    public GameObject personaje;
    public GameObject particulas;

    void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Nave").GetComponentInParent<Animator>();
    }

    private void Animacion()
    {
        particulas.SetActive(true);
        cinemachine.Follow = nave;
        personaje.SetActive(false);
        animator.SetTrigger("Mover");
        Invoke("Restaurar", 6f);
    }

    public void Restaurar()
    {
        personaje.SetActive(true);
        particulas.SetActive(false);
        personaje.transform.position = new Vector3(-16.03f, 24.193f, 0);
        cinemachine.Follow = personajeT;
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                Animacion();
            }
        }
    }
}
