using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    BoxCollider2D box;
    Animator animator;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    public void Inicio()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            SoundManager.Instance.Creditos();
            box.enabled = false;
            animator.SetTrigger("Mover");
        }
    }
}
