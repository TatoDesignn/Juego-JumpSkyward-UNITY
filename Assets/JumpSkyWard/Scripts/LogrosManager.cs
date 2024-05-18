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
    [SerializeField] private GameObject[] todosLogros;

    [Space]
    [Header("Variables globales logros:")]
    public int fragmentosRecogidos = 0;
    public int contadorDeSaltos = 0;

    [Space]
    [Header("Variables locales logros:")]
    private static bool primerosPasos = false;
    private static bool exploradorSecretos = false;
    private static bool invencible = false;
    private static bool coleccionistaFragmentos = false;
    private static bool temperaturasAltas = false;
    private static bool capitanAlMando = false;
    private static bool astronautaAhorrativo = false;
    private static bool primerFierro = false;
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

        if(fragmentosRecogidos == 88 && !astronautaAhorrativo)
        {
            astronautaAhorrativo = true;
            AstronautaAhorrativo();
        }

        if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.J) && Input.GetKey(KeyCode.E) && !maestro) 
        { 
            maestro = true;
            Maestro();
        }

        if(contadorDeSaltos == 35 && !reySaltarin)
        {
            reySaltarin = true;
            ReySaltarin();
        }
    }

    private void PrimerosPasos()
    {
        imageUI.sprite = logrosImagenes[0];
        todosLogros[0].SetActive(true);
        Mostrar();
    }

    public void ExploradorSecretos()
    {
        exploradorSecretos = true;
        imageUI.sprite = logrosImagenes[1];
        todosLogros[1].SetActive(true);
        Mostrar();
    }

    public void Invencible()
    {
        invencible = true;
        imageUI.sprite = logrosImagenes[2];
        todosLogros[2].SetActive(true);
        Mostrar();
    }

    private void ColeccionistaFragmentos()
    {
        imageUI.sprite = logrosImagenes[3];
        todosLogros[3].SetActive(true);
        Mostrar();
    }

    public void TemperaturasAltas()
    {
        if (!temperaturasAltas)
        {
            temperaturasAltas = true;
            imageUI.sprite = logrosImagenes[4];
            todosLogros[4].SetActive(true);
            Mostrar();
        }
    }

    public void CapitanMando()
    {
        if (!capitanAlMando)
        {
            capitanAlMando = true;
            imageUI.sprite = logrosImagenes[5];
            todosLogros[5].SetActive(true);
            Mostrar();
        }
    }

    private void AstronautaAhorrativo()
    {
        imageUI.sprite = logrosImagenes[6];
        todosLogros[6].SetActive(true);
        Mostrar();
    }

    public void PrimerFierro()
    {
        primerFierro = true;
        imageUI.sprite = logrosImagenes[7];
        todosLogros[7].SetActive(true);
        Mostrar();
    }

   private void ReySaltarin()
    {
        imageUI.sprite = logrosImagenes[8];
        todosLogros[8].SetActive(true);
        Mostrar();
    }

    private void Maestro()
    {
        imageUI.sprite= logrosImagenes[9];
        todosLogros[9].SetActive(true);
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

    public void ActualizarLogros()
    {
        if (primerosPasos) { todosLogros[0].SetActive(true); }

        if(exploradorSecretos) { todosLogros[1].SetActive(true); }

        if (invencible) { todosLogros[2].SetActive(true); }

        if(coleccionistaFragmentos) { todosLogros[3].SetActive(true); }

        if(temperaturasAltas) { todosLogros[4].SetActive(true); }

        if(capitanAlMando) { todosLogros[5].SetActive(true); }

        if(astronautaAhorrativo) { todosLogros[6].SetActive(true); }

        if(primerFierro) { todosLogros[7].SetActive(true); }

        if(reySaltarin) { todosLogros[8].SetActive(true); }

        if(maestro) { todosLogros[9].SetActive(true); }
    }
}
