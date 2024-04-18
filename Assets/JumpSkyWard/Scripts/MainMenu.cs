using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    Transition trans;

    public GameObject panel;

    private void Start()
    {
        trans = panel.GetComponent<Transition>();

    }

    public void Jugar()
    {
        SoundManager.Instance.MouseHover();
        panel.SetActive(true);
        trans.Transicion();
        Invoke("Jugar2", 1);
    }

    private void Jugar2()
    {
        SoundManager.Instance.Niveles();
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }

}
