using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    Puerta puerta;
    
    void Start()
    {
        puerta = GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            puerta = GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>();
            SoundManager.Instance.llave();
            puerta.llave = true;
            gameObject.SetActive(false);
        }
    }
}
