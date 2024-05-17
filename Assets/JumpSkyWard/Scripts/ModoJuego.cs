using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoJuego : MonoBehaviour
{
    public static ModoJuego Instance;

    public float espada;
    public float martillo;
    public float AtaqueEnemigos;
    public int vidaPersonaje;

    private void Awake()
    {
        if (ModoJuego.Instance == null)
        {
            ModoJuego.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
