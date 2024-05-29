using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VocesBoss : MonoBehaviour
{
    AudioSource audioS;
    Jefefinal jefe;
    

    [Space]
    [Header("Configuracion voces:")]
    [SerializeField] private AudioClip[] voces;
    [SerializeField] private AtaqueBoss2 jefeAtaque;

    private bool reproducir = true;
    int numeroPrevio = -1;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
        jefe = GetComponentInParent<Jefefinal>();
    }

    void Update()
    {
        if (jefe.transformacion && reproducir)
        {
            ReproducirAleatorio();
        }
    }

    private void ReproducirAleatorio()
    {
        reproducir = false;

        int numero;
        do
        {
            numero = Random.Range(0, 4);

        } while (numero == numeroPrevio);
        numeroPrevio = numero;


        if (numero == 0)
        {
            audioS.PlayOneShot(voces[0]);
            audioS.volume = 0.3f;
        }
        else if (numero == 1)
        {
            audioS.PlayOneShot(voces[1]);
            audioS.volume = 0.4f;
        }
        else if(numero == 2)
        {
            audioS.PlayOneShot(voces[2]);
            audioS.volume = 0.4f;
        }
        else if (numero == 3)
        {
            audioS.PlayOneShot(voces[3]);
            audioS.volume = 0.4f;
        }

        Invoke("Restart", 7f); 

    }

    private void Restart()
    {
        reproducir = true;
    }
}
