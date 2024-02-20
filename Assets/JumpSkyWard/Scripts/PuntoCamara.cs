using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PuntoCamara : MonoBehaviour
{
    [Space]
    [Header("Configuracion ")]
    public CinemachineVirtualCamera cinemachine;
    public Transform zona;
    public Transform Personaje;

    public float ortho;
    private float orthoInicio;

    private void Start()
    {
        orthoInicio = 4.75f;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            cinemachine.m_Lens.OrthographicSize = ortho;
            cinemachine.Follow = zona;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            cinemachine.Follow = Personaje;
            cinemachine.m_Lens.OrthographicSize = orthoInicio;
        }
    }
}
