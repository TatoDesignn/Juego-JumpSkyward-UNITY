using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    PlayerController controller;
    Tienda tienda;

    [Header("Variables Personajes:")]
    public bool arma;
    public bool arma2;
    public bool escudo;
    public int puntaje;
    public int vida;
    public int saludMaxima;
    public bool murio = false;

    private void Awake()
    {
        saludMaxima = ModoJuego.Instance.vidaPersonaje;
        vida = saludMaxima;

        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    public void ActivaArma()
    {
        controller = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
        if (arma) 
        {
            controller.Arma1();
        }
        else if(arma2)
        {
            controller.Arma2();
        }
    }

    public void ComprarVida()
    {
        controller = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
        tienda = GameObject.FindGameObjectWithTag("Tienda").GetComponent<Tienda>();

        if (controller.salud < 3 && controller.fragmentos >= 150)
        {
            controller.salud += 1;
            controller.fragmentos -= 150;
            controller.VidaActual();
            controller.Puntos();
            tienda.Reanudar();
        }
    }

    public void ComprarEscudo()
    {
        controller = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
        tienda = GameObject.FindGameObjectWithTag("Tienda").GetComponent<Tienda>();

        if(controller.tieneEscudo == false &&  controller.fragmentos >= 150)
        {
            controller.tieneEscudo = true;
            controller.fragmentos -= 150;
            controller.Escudo();
            controller.Puntos();
            tienda.Reanudar();
        }
    }
}
