using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    Transition trans;

    public GameObject panel;
    public GameObject[] botones;

    private void Start()
    {
        trans = panel.GetComponent<Transition>();

    }

    public void Jugar()
    {
        SoundManager.Instance.MouseHover();
        botones[0].SetActive(false);
        botones[1].SetActive(true);
    }

    public void Facil()
    {
        ModoJuego.Instance.vidaPersonaje = 5;
        ModoJuego.Instance.AtaqueEnemigos = 1;
        ModoJuego.Instance.espada = 2;
        ModoJuego.Instance.martillo = 3;
        panel.SetActive(true);
        trans.Transicion();
        SoundManager.Instance.MouseHover();
        Invoke("Jugar2", 1);
    }

    public void Medio()
    {
        ModoJuego.Instance.vidaPersonaje = 3;
        ModoJuego.Instance.AtaqueEnemigos = 1;
        ModoJuego.Instance.espada = 1;
        ModoJuego.Instance.martillo = 2;
        panel.SetActive(true);
        trans.Transicion();
        SoundManager.Instance.MouseHover();
        Invoke("Jugar2", 1);
    }

    public void Dificil()
    {
        ModoJuego.Instance.vidaPersonaje = 1;
        ModoJuego.Instance.AtaqueEnemigos = 1;
        ModoJuego.Instance.espada = 1;
        ModoJuego.Instance.martillo = 2;
        panel.SetActive(true);
        trans.Transicion();
        SoundManager.Instance.MouseHover();
        Invoke("Jugar2", 1);
    }

    private void Jugar2()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
