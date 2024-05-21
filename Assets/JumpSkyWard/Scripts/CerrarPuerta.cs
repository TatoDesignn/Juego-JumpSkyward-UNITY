using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuerta : MonoBehaviour
{
    [SerializeField] private GameObject pared;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            pared.SetActive(true);
        }
    }
}
