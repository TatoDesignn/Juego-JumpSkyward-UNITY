using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance;
    PlayerController controller;

    [Header("Variables Personajes:")]
    public bool arma;
    public bool arma2;

    private void Awake()
    {
        if(GameManager.Instance == null)
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
}
