using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilBoss : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    AudioSource audioSource;

    private bool daño = false;
    [SerializeField] private AudioClip audios;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            Destroy(rb);
            animator.SetTrigger("Explosion");
            audioSource.volume = 0.7f;
            audioSource.pitch = 1.5f;
            audioSource.PlayOneShot(audios);
            Destroy(gameObject, 0.4f);

        }
        if (collision.CompareTag("Personaje"))
        {
            Destroy(rb);
            animator.SetTrigger("Explosion");
            if(!daño)
            {
                collision.transform.GetComponent<PlayerController>().Vida(1);
                daño = true;
                audioSource.volume = 0.7f;
                audioSource.pitch = 1.5f;
                audioSource.PlayOneShot(audios);
            }
            Destroy(gameObject, 0.4f);
        }
    }
}
