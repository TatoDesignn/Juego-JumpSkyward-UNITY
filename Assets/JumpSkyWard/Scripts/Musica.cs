using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musica : MonoBehaviour
{
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SoundManager.Instance.Menu();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SoundManager.Instance.Tutorial();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SoundManager.Instance.Nivel1();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SoundManager.Instance.Nivel2();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SoundManager.Instance.Nivel3();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SoundManager.Instance.Jefe();
        }
    }

}
