using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource audioSource;

    [Space]
    [Header("Configuracion de sonidos: ")]
    [SerializeField] private AudioClip[] audios;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();  
    }

    public void Correr() { }
    public void AtaqueEspada() { audioSource.PlayOneShot(audios[12]); audioSource.volume = 0.1f; }
    public void AtaqueMartillo() { audioSource.PlayOneShot(audios[13]); audioSource.volume = 0.1f; }
    public void Salto() { audioSource.PlayOneShot(audios[11]); audioSource.volume = 0.15f; }
    public void Fragmentos() { audioSource.PlayOneShot(audios[15]); audioSource.volume = 0.3f; }
    public void Laser() { audioSource.PlayOneShot(audios[5]); audioSource.volume = 0.3f; }
    public void HitPlayer() { audioSource.PlayOneShot(audios[2]); audioSource.volume = 1f; }
    public void MuertePlayer() { audioSource.PlayOneShot(audios[7]); audioSource.volume = 0.4f; }
    public void HitCiber() { audioSource.PlayOneShot(audios[4]); audioSource.volume = 0.1f; }
    public void MuerteCiber() { audioSource.PlayOneShot(audios[10]); audioSource.volume = 0.5f; }
    public void HitCanon() { audioSource.PlayOneShot(audios[17]); audioSource.volume = 0.5f; }
    public void MuerteCanon() { audioSource.PlayOneShot(audios[19]); audioSource.volume = 0.5f; }
    public void DisparoCañon() { audioSource.PlayOneShot(audios[0]); audioSource.volume = 1f; }
    public void Escudo() { audioSource.PlayOneShot(audios[1]); audioSource.volume = 0.3f; }
    public void EscudoRomper() { audioSource.PlayOneShot(audios[16]); audioSource.volume = 0.5f; }
    public void Cohete() { audioSource.PlayOneShot(audios[8]); audioSource.volume = 0.5f; }
    public void Puerta() { audioSource.PlayOneShot(audios[18]); audioSource.volume = 0.05f; }
    public void MouseHover() { }
    public void Logros() { audioSource.PlayOneShot(audios[21]); audioSource.volume = 0.4f; }
    public void llave() { audioSource.PlayOneShot(audios[14]); audioSource.volume = 0.4f; }
    public void Tienda() { audioSource.PlayOneShot(audios[20]); audioSource.volume = 0.2f; }
}
