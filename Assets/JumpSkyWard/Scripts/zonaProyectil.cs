using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zonaProyectil : MonoBehaviour
{
    AudioSource audioSource;

    public GameObject bala;
    public Transform controlador;

    [SerializeField] private AudioClip audios;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("MostrarBala", 1f);
    }

    private void MostrarBala()
    {
        Instantiate(bala, controlador.position, controlador.rotation);
        audioSource.volume = 0.3f; 
        audioSource.pitch = 1.5f; 
        audioSource.PlayOneShot(audios);
        Destroy(gameObject, 1f);
    }
}
