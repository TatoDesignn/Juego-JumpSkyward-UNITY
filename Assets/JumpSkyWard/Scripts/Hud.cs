using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hud : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void VidaDos()
    {
        animator.SetTrigger("V2");
    }

    public void VidaUno()
    {
        animator.SetTrigger("V1");
    }

    public void VidaCero() 
    {
        animator.SetTrigger("V0");
    }

}
