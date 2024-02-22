using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool llave = false;
    public GameObject letrero;
    public GameObject letrero2;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            if (!llave)
            {
                letrero.SetActive(true);
            }
            else if(llave)
            {
                letrero2.SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            letrero.SetActive(false);
            letrero2.SetActive(false);
        }
    }


}
