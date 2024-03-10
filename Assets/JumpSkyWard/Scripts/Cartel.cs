using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartel : MonoBehaviour
{
    [SerializeField] private GameObject cartel1;
    [SerializeField] private GameObject cartel2;

    void Start()
    {
        cartel1.SetActive(true);
        cartel2.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            cartel2.SetActive(true);
            cartel1.SetActive(false);
        }
    }
}
