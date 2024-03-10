using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    public bool llave = false;
    public GameObject letrero;
    public GameObject letrero2;
    public GameObject panel;

    private void Start()
    {
        letrero.SetActive(false);
        letrero2.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            if (!llave)
            {
                letrero.SetActive(true);
                letrero2.SetActive(false);
            }
            else if(llave)
            {
                letrero2.SetActive(true);
                letrero.SetActive(false);

                if (Input.GetKey(KeyCode.E))
                {
                    panel.SetActive(true);
                    Invoke("Cambiar", 2f);
                }
            }
        }
    }

    private void Cambiar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            letrero.SetActive(false);
            letrero2.SetActive(false);
        }
    }*/


}
