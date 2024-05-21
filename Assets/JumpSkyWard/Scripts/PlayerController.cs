using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Animator animatorHud;

    [Space]
    [Header("Movimiento jugador: ")]
    public float velocidad;
    public float saltar;

    [Space]
    [Header("Armas: ")]
    public GameObject mano;
    public GameObject espada;
    public GameObject martillo;
    public GameObject mira;
    public GameObject escudo;
    public GameObject activarEscudo;

    [Space]
    [Header("Control Ataque: ")]
    public int daño;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] private Transform controladorGolpe1;
    [SerializeField] private float radioGolpe;
    [SerializeField] private Vector2 size;
    [SerializeField] private float angulo;
    [SerializeField] private float ataqueEspada;
    [SerializeField] private float ataqueMartillo;

    [Space]
    [Header("Control Hud: ")]
    public TextMeshProUGUI texto;

    [Space]
    [Header("Variable Globales: ")]
    public int fragmentos = 0;
    public int salud;
    public bool tieneEscudo = false;
    public bool canMove = true;
    public bool invencible = true;

    [Space]
    [Header("Variable Locales: ")]
    bool moving;
    bool moving2;
    bool enMovimiento;
    bool canJump;
    bool canDown;
    bool arma = false;
    bool arma2 = false;
    bool escala = false;
    bool mover = true;
    float velocidadF;
    string escena;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorHud = GameObject.FindGameObjectWithTag("hudPersonaje").GetComponent<Animator>();
        escena = SceneManager.GetActiveScene().name;
        GameManager.Instance.ActivaArma();
        fragmentos = GameManager.Instance.puntaje;

        if (GameManager.Instance.murio)
        {
            salud = GameManager.Instance.saludMaxima;
            GameManager.Instance.murio = false;
        }
        else
        {
            salud = GameManager.Instance.vida;
        }

        tieneEscudo = GameManager.Instance.escudo;
        ataqueEspada = ModoJuego.Instance.espada;
        ataqueMartillo = ModoJuego.Instance.martillo;
        LogrosManager.Instance.ActualizarLogros();
        Escudo();
        Puntos();
        VidaActual();
        canMove = true;
        velocidadF = velocidad;
        escudo.SetActive(false);
    }

    void Update()
    {
        if (canMove)
        {
            Movimiento();
            Ataque();
        }
    }

    private void Movimiento()
    {

        if (moving = Input.GetAxisRaw("Horizontal") == 1 && mover)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(moving2 = Input.GetAxisRaw("Horizontal") == -1 && mover)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if(moving || moving2)
        {
            enMovimiento = true;
        }
        else
        {
            enMovimiento = false;
        }

        animator.SetBool("Walk", moving);
        animator.SetBool("Walk2", moving2);
        animator.SetBool("Movimiento", enMovimiento);

        if (Input.GetKey(KeyCode.Space) && canJump && !escala)
        {
            rb.AddForce(Vector2.up * saltar, ForceMode2D.Impulse);
            canJump = false;
            animator.SetTrigger("Jump");
            LogrosManager.Instance.contadorDeSaltos += 1;
            SoundManager.Instance.Salto();
        }

        animator.ResetTrigger("Parado");

        if (Input.GetKeyDown(KeyCode.S) && canDown)
        {
            animator.SetTrigger("agachadoI");

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                animator.SetTrigger("agachadoR");
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetTrigger("Parado");
        }

        if(Input.GetKey(KeyCode.C) && tieneEscudo)
        {
            escudo.SetActive(true); 
            tieneEscudo = false;
            SoundManager.Instance.Escudo();
            Escudo();
        }
    }

    private void Ataque()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && tiempoSiguienteAtaque <= 0 && (arma || arma2))
        {
            tiempoSiguienteAtaque = tiempoEntreAtaque;

            if (arma)
            {
                SoundManager.Instance.AtaqueEspada();
            }
            else if (arma2)
            {
                SoundManager.Instance.AtaqueMartillo();
            }

            Daño();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Vector2 newVelocity;
            newVelocity.x = Input.GetAxisRaw("Horizontal") * velocidad;
            newVelocity.y = rb.velocity.y;
            if (escala)
            {
                newVelocity.y = Input.GetAxisRaw("Vertical") * 3;
            }


            rb.velocity = newVelocity;
        }
    }

    private void Daño()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapBoxAll(controladorGolpe1.position, size, angulo);

        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                if(arma)
                {
                    collisionador.transform.GetComponent<Enemigo1>().Daño(ataqueEspada);
                }
                else if (arma2)
                {
                    collisionador.transform.GetComponent<Enemigo1>().Daño(ataqueMartillo);
                }
            }
            if (collisionador.CompareTag("Enemigo2"))
            {
                if (arma)
                {
                    collisionador.transform.GetComponent<Enemigo2>().Daño(ataqueEspada);
                }
                else if (arma2)
                {
                    collisionador.transform.GetComponent<Enemigo2>().Daño(ataqueMartillo);
                }
            }
            if (collisionador.CompareTag("Enemigo3"))
            {
                if (arma)
                {
                    collisionador.transform.GetComponent<Enemigo3>().Daño(ataqueEspada);
                }
                else if (arma2)
                {
                    collisionador.transform.GetComponent<Enemigo3>().Daño(ataqueMartillo);
                }
            }
            if (collisionador.CompareTag("Enemigo4"))
            {
                if (arma)
                {
                    collisionador.transform.GetComponent<Jefefinal>().Daño(ataqueEspada);
                }
                else if (arma2)
                {
                    collisionador.transform.GetComponent<Jefefinal>().Daño(ataqueMartillo);
                }
            }
        }
    }

    public void Escudo()
    {
        if(tieneEscudo)
        {
            activarEscudo.SetActive(true);
        }
        else if (!tieneEscudo)
        {
            activarEscudo.SetActive(false); 
        }
        GameManager.Instance.escudo = tieneEscudo;
    }

    public void Vida(int Daño)
    {
        if (!escudo.activeInHierarchy)
        {
            salud -= Daño;
            invencible = false;

            if (salud == 2)
            {
                Inmovil();
                animator.SetTrigger("Hit");
                animatorHud.SetTrigger("V2");
                SoundManager.Instance.HitPlayer();
                Invoke("Restablecer", 0.8f);
            }
            else if (salud == 1)
            {
                Inmovil();
                animator.SetTrigger("Hit");
                animatorHud.SetTrigger("V1");
                SoundManager.Instance.HitPlayer();
                Invoke("Restablecer", 0.8f);
            }
            else if (salud == 0)
            {
                GameManager.Instance.murio = true;
                SoundManager.Instance.MuertePlayer();
                Muerte();
                animatorHud.SetTrigger("V0");
            }
        }
        else
        {
            escudo.SetActive(false);
            SoundManager.Instance.EscudoRomper();
        }

        GameManager.Instance.vida = salud;
    }

    public void VidaActual()
    {
        if (salud == 3)
        {
            animatorHud.SetTrigger("V3");
        }
        if (salud == 2)
        {
            animatorHud.SetTrigger("V2");
        }
        else if (salud == 1)
        {
            animatorHud.SetTrigger("V1");
        }
        GameManager.Instance.vida = salud;
    }

    private void Muerte()
    {
        Inmovil();
        animatorHud.SetTrigger("V0");
        animator.SetTrigger("Muerte");
        GameManager.Instance.puntaje = 0;
        GameManager.Instance.vida = 3;
        Invoke("Resetear", 3f);
    }

    public void Quieto()
    {
        rb.velocity = new Vector2 (0, 0);
        canMove = false;
        animator.SetTrigger("Idle");
    }

    public void Normalidad()
    {

        canMove = true;
    }

    private void Inmovil()
    {
        espada.SetActive(false);
        martillo.SetActive(false);
        mano.SetActive(false);
        mover = false;
        canDown = false;
        canJump = false;
        velocidad = 0;
    }

    public void Restablecer()
    {
        mano.SetActive(true);
        mover = true;
        canDown = true;
        canJump = true;
        velocidad = velocidadF;

        if (arma)
        {
            espada.SetActive(true);
        }
        else if (arma2)
        {
            martillo.SetActive(true);
        }
    }

    private void Resetear()
    {
        SceneManager.LoadScene(escena);
    }

    public void Puntos()
    {
        texto.text = ": " + fragmentos.ToString();
        GameManager.Instance.puntaje = fragmentos;
    }

    public void Arma1()
    {
        arma = true;
        arma2 = false;
        martillo.SetActive(false);
        mano.SetActive(true);
        espada.SetActive(true);
        mira.SetActive(true);
    }

    public void Arma2()
    {
        arma2 = true;
        arma = false;
        espada.SetActive(false);
        mano.SetActive(true);
        martillo.SetActive(true);
        mira.SetActive(true);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.green;
        Gizmos.DrawWireSphere(controladorGolpe1.position, radioGolpe);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Suelo" || collision.collider.tag == "Tuberia")
        {
            canDown = true;
            canJump = true;
            animator.SetBool("Suelo", true);
        }

        if (collision.collider.tag == "Laser")
        {
            LogrosManager.Instance.TemperaturasAltas();
            SoundManager.Instance.Laser();
            Muerte();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo" || collision.collider.tag == "Tuberia")
        {
            animator.SetBool("Suelo", false);
            canDown = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            GameManager.Instance.arma = true;
            GameManager.Instance.arma2 = false;
            LogrosManager.Instance.PrimerFierro();
            Destroy(collision.gameObject);
            Arma1();
        }

        if (collision.CompareTag("Arma2"))
        {
            GameManager.Instance.arma2 = true;
            GameManager.Instance.arma = false;
            LogrosManager.Instance.ExploradorSecretos();
            Destroy(collision.gameObject);
            Arma2();
        }


        if (collision.CompareTag("Fragmento"))
        {
            fragmentos += 10;
            LogrosManager.Instance.fragmentosRecogidos += 1;
            GameManager.Instance.puntaje = fragmentos;
            Destroy(collision.gameObject);
            SoundManager.Instance.Fragmentos();
            Puntos();
        }

        if (collision.CompareTag("PowerUp"))
        {
            Destroy(collision.gameObject);
            escudo.SetActive(true);
            SoundManager.Instance.Escudo();
        }

        if (collision.CompareTag("Acha"))
        {
            Vida(1);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {

            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("Subir", true);
                escala = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Escalera"))
        {
            animator.SetBool("Subir", false);
            escala = false;
        }
    }
}
