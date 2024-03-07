using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    Puerta puerta;
    PlataformaTuberia plataforma;
    [SerializeField] private GameObject cartel1;
    [SerializeField] private GameObject cartel2;
    
    void Start()
    {
        puerta = GameObject.FindGameObjectWithTag("Puerta").GetComponent<Puerta>();
        cartel1.SetActive(true);
        cartel2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            puerta.llave = true;
            gameObject.SetActive(false);
            cartel2.SetActive(true);
            cartel1.SetActive(false);
        }
    }
}
