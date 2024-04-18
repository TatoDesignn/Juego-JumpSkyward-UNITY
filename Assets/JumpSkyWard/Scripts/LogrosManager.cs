using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class LogrosManager : MonoBehaviour
{
    public static LogrosManager Instance;

    [Space]
    [Header("Configuracion de los Logros:")]
    [SerializeField] private Image imageUI;
    [SerializeField] private Sprite[] logrosImagenes;
    [SerializeField] private RectTransform posicionImagen;
    [SerializeField] private float finPosicionY;
    [SerializeField] private float duration;

    [Space]
    [Header("Variables globales logros:")]
    public int fragmentosRecogidos = 0;
    public int contadorDeSaltos = 0;

    [Space]
    [Header("Variables locales logros:")]
    private static bool primerosPasos = false;
    private static bool coleccionistaFragmentos = false;
    private static bool temperaturasAltas = false;
    private static bool capitanAlMando = false;
    private static bool astronautaAhorrativo = false;
    private static bool reySaltarin = false;
    private static bool maestro = false;

    private void Awake()
    {
        if (LogrosManager.Instance == null)
        {
            LogrosManager.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2 && !primerosPasos)
        {
            primerosPasos = true;
            PrimerosPasos();
        }

        if(fragmentosRecogidos == 30 && !coleccionistaFragmentos)
        {
            coleccionistaFragmentos = true;
            ColeccionistaFragmentos();
        }

        if(fragmentosRecogidos == 60 && !astronautaAhorrativo)
        {
            astronautaAhorrativo = true;
            AstronautaAhorrativo();
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.E) && !maestro) 
        { 
            maestro = true;
            Maestro();
        }

        if(contadorDeSaltos == 25 && !reySaltarin)
        {
            reySaltarin = true;
            ReySaltarin();
        }
    }

    private void PrimerosPasos()
    {
        imageUI.sprite = logrosImagenes[0];
        Mostrar();
    }

    public void ExploradorSecretos()
    {
        imageUI.sprite = logrosImagenes[1];
        Mostrar();
    }

    public void Invencible()
    {
        imageUI.sprite = logrosImagenes[2];
        Mostrar();
    }

    private void ColeccionistaFragmentos()
    {
        imageUI.sprite = logrosImagenes[3];
        Mostrar();
    }

    public void TemperaturasAltas()
    {
        if (!temperaturasAltas)
        {
            temperaturasAltas = true;
            imageUI.sprite = logrosImagenes[4];
            Mostrar();
        }
    }

    public void CapitanMando()
    {
        if (!capitanAlMando)
        {
            capitanAlMando = true;
            imageUI.sprite = logrosImagenes[5];
            Mostrar();
        }
    }

    private void AstronautaAhorrativo()
    {
        imageUI.sprite = logrosImagenes[6];
        Mostrar();
    }

    public void PrimerFierro()
    {
        imageUI.sprite = logrosImagenes[7];
        Mostrar();
    }

   private void ReySaltarin()
    {
        imageUI.sprite = logrosImagenes[8];
        Mostrar();
    }

    private void Maestro()
    {
        imageUI.sprite= logrosImagenes[9];
        Mostrar();
    }

    private void Mostrar()
    {
        SoundManager.Instance.Logros();
        posicionImagen.DOMoveY(finPosicionY, duration).SetEase(Ease.OutBounce);
        Invoke("Apagar", 4f);
    }

    private void Apagar()
    {
        posicionImagen.anchoredPosition = new Vector2(58, 755);
    }
}
