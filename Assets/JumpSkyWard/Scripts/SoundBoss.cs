using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    AudioSource audioSource;

    [Space]
    [Header("Configuracion de sonidos: ")]
    [SerializeField] private AudioClip[] audios;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void hitChiquito() { audioSource.volume = 0.2f; audioSource.pitch = 1.5f; audioSource.PlayOneShot(audios[0]); }
    public void Transformacion() { audioSource.volume = 0.4f; audioSource.pitch = 0.6f; audioSource.PlayOneShot(audios[1]); }
    public void hitGrande() { audioSource.volume = 0.2f; audioSource.pitch = 1f; audioSource.PlayOneShot(audios[2]); }
    public void ataque1() { audioSource.volume = 0.2f; audioSource.pitch = 1f; audioSource.PlayOneShot(audios[3]); }
    public void ataque2() { audioSource.volume = 0.2f; audioSource.pitch = 1f; audioSource.PlayOneShot(audios[4]); }
    public void ataque3() { audioSource.volume = 0.2f; audioSource.pitch = 1f; audioSource.PlayOneShot(audios[5]); }
    public void muerte() { audioSource.volume = 0.2f; audioSource.pitch = 1f; audioSource.PlayOneShot(audios[6]); }
}
