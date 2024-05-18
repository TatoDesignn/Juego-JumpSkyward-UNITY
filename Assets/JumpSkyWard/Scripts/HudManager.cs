using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    public GameObject tienda;
    public GameObject botonTienda;
    public GameObject logros;
    public GameObject botonLogros;
    public GameObject[] logrosIndividuales;

    private bool activa;

    private void Start()
    {
        tienda.SetActive(false);
        activa = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            AnalizarTienda();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            AnalizarLogros();
        }
    }

    private void AnalizarLogros()
    {
        if (!logros.activeInHierarchy)
        {
            PausarLogros();
        }
        else if (logros.activeInHierarchy)
        {
            ReanudarLogros();
        }
    }

    public void PausarLogros()
    {
        SoundManager.Instance.Tienda();
        logros.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ReanudarLogros()
    {
        SoundManager.Instance.Tienda();
        logros.SetActive(false);
        Time.timeScale = 1;
    }

    private void AnalizarTienda()
    {
        if (!tienda.activeInHierarchy)
        {
            PausarTienda();
        }
        else if (tienda.activeInHierarchy)
        {
            ReanudarTienda();
        }
    }

    public void PausarTienda()
    {
        SoundManager.Instance.Tienda();
        tienda.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReanudarTienda()
    {
        tienda.SetActive(false);
        Time.timeScale = 1;
        SoundManager.Instance.Tienda();
    }
    public void PausarYReanudarTienda()
    {
        SoundManager.Instance.Tienda();
        tienda.SetActive(!tienda.activeSelf);
        Time.timeScale = tienda.activeSelf ? 0 : 1;
    }

    public void PausarYReanudarLogros()
    {
        SoundManager.Instance.Tienda();
        logros.SetActive(!logros.activeSelf);
        Time.timeScale = logros.activeSelf ? 0 : 1;
    }
}
