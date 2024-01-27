using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using com.vintagerockets.untitledtowerdefense.dialogs;

public class DialogManager : MonoBehaviour
{
    private Text dialogText;
    [SerializeField] private Image nextButton;
    [SerializeField] private InputAction dialogClickAction;

    [SerializeField] private float typingSpeed = 0.05f; // Velocidad de escritura, puedes ajustarla seg�n tus preferencias.

    private List<string> dialogLines = new List<string>();
    private int currentLine = 0;
    private bool isTyping = false;

    void Start()
    {
        dialogClickAction.started += ctx => HandleDialogInput();

        nextButton.GetComponent<Button>().onClick.AddListener(HandleDialogInput);

        // Iniciar la primera l�nea de di�logo.
        StartCoroutine(TypeText(dialogLines[currentLine]));
    }

    public void DisplayDialog(Dialog dialog)
    {

    }

    void OnEnable()
    {
        dialogClickAction.Enable();
    }

    void OnDisable()
    {
        dialogClickAction.Disable();
    }

    void HandleDialogInput()
    {
        // Verificar si se est� escribiendo actualmente para evitar interrupciones.
        if (isTyping)
        {
            // Si se est� escribiendo, mostrar todo el texto de inmediato.
            StopAllCoroutines();
            dialogText.text = dialogLines[currentLine];
            isTyping = false;
        }
        else
        {
            // Si no se est� escribiendo, pasar al siguiente texto.
            currentLine++;
            if (currentLine < dialogLines.Count)
            {
                StartCoroutine(TypeText(dialogLines[currentLine]));
            }
            else
            {
                // Todas las l�neas han sido mostradas.
                Debug.Log("Fin del di�logo.");
            }
        }
    }

    IEnumerator TypeText(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }
}
