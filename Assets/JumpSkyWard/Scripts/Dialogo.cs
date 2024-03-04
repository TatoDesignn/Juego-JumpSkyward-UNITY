using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    PlayerController player;

    [Header("Configuracion Dialogo: ")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject dialoguePressE;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4,6)] private string[] dialogueLines;
    [SerializeField] public float tiempoEspera;

    [Header("Variables Locales")]
    private bool jugadorEnRango;
    private bool dialogueStart;
    private int lineIndex;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Personaje").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if(jugadorEnRango)
        {
            player.Quieto();

            if (!dialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex] && Input.GetKey(KeyCode.E)) 
            {
                NextDialogueLine();
            }
        }
    }

    private void StartDialogue()
    {
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private void NextDialogueLine()
    {
        lineIndex++;
        dialoguePressE.SetActive(false);

        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            player.Normalidad();
            Destroy(gameObject);
        }

    }

    IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSeconds(tiempoEspera);
        }
        dialoguePressE.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Personaje"))
        {
            jugadorEnRango = true;
        }
    }
}
