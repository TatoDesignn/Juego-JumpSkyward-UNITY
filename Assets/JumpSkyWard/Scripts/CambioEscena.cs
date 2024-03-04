using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            panel.SetActive(true);
            Invoke("Cambiar", 2f);
        }
    }

    private void Cambiar()
    {
        SceneManager.LoadScene(2);
    }
}
