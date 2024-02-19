using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
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
    public GameObject mira;

    [Space]
    [Header("Control Ataque: ")]
    public int daño;
    [SerializeField] private float tiempoEntreAtaque;
    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] private Transform controladorGolpe1;
    [SerializeField] private float radioGolpe;
    [SerializeField] private Vector2 size;
    [SerializeField] private float angulo;

    [Space]
    [Header("Control Hud: ")]
    public TextMeshProUGUI texto;

    [Space]
    [Header("Variable globales: ")]
    bool moving;
    bool moving2;
    bool enMovimiento;
    bool canJump;
    bool arma = false;
    bool escala = false;
    bool mover = true;
    int fragmentos = 0;
    public int salud = 3;
    float velocidadF;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animatorHud = GameObject.FindGameObjectWithTag("hudPersonaje").GetComponent<Animator>();
        velocidadF = velocidad;
    }

    void Update()
    {
        Movimiento();
        Ataque();
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

        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector2.up * saltar, ForceMode2D.Impulse);
            canJump = false;
            animator.SetTrigger("Jump");
        }

        animator.ResetTrigger("Parado");

        if (Input.GetKeyDown(KeyCode.S))
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

        /*if (Input.GetKeyDown(KeyCode.S))    
        {
            if(moving || moving2)
            {
                animator.SetTrigger("agachadoR");
            }
            else
            {
                animator.ResetTrigger("agachadoR");
                animator.SetTrigger("agachadoI");
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.ResetTrigger("agachadoI");
            animator.SetTrigger("Parado");
        }*/

    }

    private void Ataque()
    {
        if (tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0) && tiempoSiguienteAtaque <= 0 && arma)
        {
            tiempoSiguienteAtaque = tiempoEntreAtaque;
            Daño();
        }
    }

    private void FixedUpdate()
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

    private void Daño()
    {
        animator.SetTrigger("Golpe");
        Collider2D[] objetos = Physics2D.OverlapBoxAll(controladorGolpe1.position, size, angulo);

        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                collisionador.transform.GetComponent<Enemigo1>().Daño(1);
            }
        }
    }

    public void Vida()
    {
        if(salud == 2)
        {
            Inmovil();
            animator.SetTrigger("Hit");
            animatorHud.SetTrigger("V2");
            Invoke("Restablecer", 0.8f);
        }
        else if(salud == 1)
        {
            Inmovil();
            animator.SetTrigger("Hit");
            animatorHud.SetTrigger("V1");
            Invoke("Restablecer", 0.8f);
        }
        else if(salud == 0)
        {
            Muerte();
            animatorHud.SetTrigger("V0");
        }
    }

    private void Muerte()
    {
        Inmovil();
        animatorHud.SetTrigger("V0");
        animator.SetTrigger("Muerte");
        Invoke("Resetear", 2f);
    }

    private void Inmovil()
    {
        espada.SetActive(false);
        mano.SetActive(false);
        mover = false;
        velocidad = 0;
    }

    public void Restablecer()
    {
        espada.SetActive(true);
        mano.SetActive(true);
        mover = true;
        velocidad = velocidadF;
    }

    private void Resetear()
    {
        SceneManager.LoadScene("Nivel1");
    }

    private void Puntos()
    {
        texto.text = ": " + fragmentos.ToString();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = UnityEngine.Color.green;
        Gizmos.DrawWireSphere(controladorGolpe1.position, radioGolpe);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Suelo")
        {
            canJump = true;
            animator.SetBool("Suelo", true);
        }

        if (collision.collider.tag == "Laser")
        {
            Muerte();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Suelo")
        {
            animator.SetBool("Suelo", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Arma"))
        {
            Destroy(collision.gameObject);
            arma = true;
            mano.SetActive(true);
            espada.SetActive(true);
            mira.SetActive(true);
        }

        if (collision.CompareTag("Fragmento"))
        {
            fragmentos += 10;
            Destroy(collision.gameObject);
            Puntos();
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
