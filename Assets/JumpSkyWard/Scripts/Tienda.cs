using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class Tienda : MonoBehaviour
{
    public GameObject tienda;
    private bool activa;

    private void Start()
    {
        tienda.SetActive(false);
        activa = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Analizar();
        }
    }

    private void Analizar()
    {
        if(!tienda.activeInHierarchy)
        {
            Pausar();
        }
        else if(tienda.activeInHierarchy)
        {
            Reanudar();
        }
    }

    public void Pausar()
    {
        SoundManager.Instance.Tienda();
        tienda.SetActive(true);
        Time.timeScale = 0;
    }

    public void Reanudar()
    {
        tienda.SetActive(false);
        Time.timeScale = 1;
    }
    public void PausarYReanudar()
    {
        SoundManager.Instance.Tienda();
        tienda.SetActive(!tienda.activeSelf);
        Time.timeScale = tienda.activeSelf ? 0 : 1;
    }
}
