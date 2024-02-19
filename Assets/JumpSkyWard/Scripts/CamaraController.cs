using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    [Space]
    [Header("Configuracion ")]
    public CinemachineVirtualCamera cinemachine;
    private CinemachineCameraOffset offset;

    public float ortho;
    public float offsetX;
    private float offsetInicio;
    private float orthoInicio;

   

    void Start()
    {
        offset = GetComponent<CinemachineCameraOffset>();
        orthoInicio = cinemachine.m_Lens.OrthographicSize;
        offsetInicio = offset.m_Offset.x;
    }

    public void Alejar()
    {
        cinemachine.m_Lens.OrthographicSize = ortho;
        offset.m_Offset.x = offsetX;
    }   
    
    public void Normal() 
    {
        cinemachine.m_Lens.OrthographicSize = orthoInicio;
        offset.m_Offset.x = offsetInicio;
    }
}
