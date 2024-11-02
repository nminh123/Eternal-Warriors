using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public TextMeshProUGUI dialogueText; 
    public string[] dialogues; 

    private int currentLine = 0; 
    private bool isDialogueActive = false; 
    [SerializeField] private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) || isPlayerNearby && Input.GetMouseButtonDown(0))
        {
            if (isDialogueActive)
            {
                ShowNextLine(); 
            }
            else
            {
                StartDialogue(); 
            }
        }
    }

    
    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerNearby = false; 
            if (isDialogueActive)
            {
                EndDialogue(); 
            }
        }
    }
    private void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true); 
        currentLine = 0;
        ShowNextLine();
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false); 
        currentLine = 0;
    }

    private void ShowNextLine()
    {
        if (currentLine < dialogues.Length)
        {
            dialogueText.text = dialogues[currentLine]; 
            currentLine++; 
        }
        else
        {
            EndDialogue(); 
        }
    }
}
