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
            SoundManager.Instance.Niveles();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SoundManager.Instance.Niveles();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SoundManager.Instance.Niveles();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SoundManager.Instance.Niveles();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            SoundManager.Instance.Jefe();
        }
    }

}
