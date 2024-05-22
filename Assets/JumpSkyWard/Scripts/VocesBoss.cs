using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class VocesBoss : MonoBehaviour
{
    AudioSource audio;
    Jefefinal jefe;
    

    [Space]
    [Header("Configuracion voces:")]
    [SerializeField] private AudioClip[] voces;
    [SerializeField] private AtaqueBoss2 jefeAtaque;

    private bool reproducir = true;
    int numeroPrevio = -1;

    void Start()
    {
        audio = GetComponent<AudioSource>();
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
            audio.PlayOneShot(voces[0]);
            audio.volume = 0.3f;
        }
        else if (numero == 1)
        {
            audio.PlayOneShot(voces[1]);
            audio.volume = 0.4f;
        }
        else if(numero == 2)
        {
            audio.PlayOneShot(voces[2]);
            audio.volume = 0.4f;
        }
        else if (numero == 3)
        {
            audio.PlayOneShot(voces[3]);
            audio.volume = 0.4f;
        }

        Invoke("Restart", 7f); 

    }

    private void Restart()
    {
        reproducir = true;
    }
}
