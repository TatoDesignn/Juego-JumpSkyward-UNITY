using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    AudioSource audioSource;
    AudioSource audioMusic;
    AudioSource audioAmbiente;

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

        audioAmbiente = transform.GetChild(0).GetComponent<AudioSource>();
        audioMusic = transform.GetChild(1).GetComponent<AudioSource>();
    }

    private void Start()
    {
        Menu();
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
    public void HitSnake() { audioSource.PlayOneShot(audios[29]); audioSource.volume = 0.5f; }
    public void MuerteSnake() { audioSource.PlayOneShot(audios[27]); audioSource.volume = 0.5f; }
    public void AtaqueSnake() { audioSource.PlayOneShot(audios[28]); audioSource.volume = 0.5f; }
    public void MuerteCanon() { audioSource.PlayOneShot(audios[19]); audioSource.volume = 0.5f; }
    public void DisparoCañon() { audioSource.PlayOneShot(audios[0]); audioSource.volume = 0.5f; }
    public void Escudo() { audioSource.PlayOneShot(audios[1]); audioSource.volume = 0.3f; }
    public void EscudoRomper() { audioSource.PlayOneShot(audios[16]); audioSource.volume = 0.5f; }
    public void Cohete() { audioSource.PlayOneShot(audios[8]); audioSource.volume = 0.5f; }
    public void Puerta() { audioSource.PlayOneShot(audios[18]); audioSource.volume = 0.05f; }
    public void MouseHover() { audioSource.PlayOneShot(audios[6]); audioSource.volume = 1f; }
    public void Logros() { audioSource.PlayOneShot(audios[21]); audioSource.volume = 0.4f; }
    public void llave() { audioSource.PlayOneShot(audios[14]); audioSource.volume = 0.4f; }
    public void Tienda() { audioSource.PlayOneShot(audios[20]); audioSource.volume = 0.1f; }
    public void Menu() { audioMusic.clip = audios[25]; audioMusic.Play(); audioMusic.loop = true; }
    public void Niveles() { audioMusic.Stop();  audioMusic.clip = audios[24]; audioMusic.Play(); audioAmbiente.clip = audios[22];  audioAmbiente.Play(); audioMusic.loop = true; audioAmbiente.loop = true; }
    public void Jefe() { audioMusic.Stop();  audioMusic.clip = audios[30]; audioMusic.Play(); audioAmbiente.clip = audios[22];  audioAmbiente.Play(); audioMusic.loop = true; audioAmbiente.loop = true; }
    public void Jefe2() { audioMusic.Stop();  audioMusic.clip = audios[31]; audioMusic.Play(); audioAmbiente.clip = audios[22];  audioAmbiente.Play(); audioMusic.loop = true; audioAmbiente.loop = true; }
}
