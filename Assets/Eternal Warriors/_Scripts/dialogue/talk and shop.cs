using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCShop : MonoBehaviour
{
    public GameObject dialoguePanel; 
    public GameObject otherPanel;   
    public TMP_Text dialogueText;    
    public Button openOtherPanelButton; 
    public Button refusalButton;         
    public string[] firstMeetingDialogue;  
    public string[] dialogues;            
    public string[] refusalDialogue;      
    private int dialogueIndex = 0;
    private bool playerIsClose = false;  
    private bool dialogueActive = false; 
    private bool firstMeeting = true;   
    private bool refusalActive = false;  
    private bool buttonsVisible = false; 

    private void Start()
    {
        dialoguePanel.SetActive(false);     
        otherPanel.SetActive(false);       
        openOtherPanelButton.gameObject.SetActive(false); 
        refusalButton.gameObject.SetActive(false);       

        openOtherPanelButton.onClick.AddListener(OpenOtherPanel); 
        refusalButton.onClick.AddListener(ShowRefusalDialogue);   
    }

    private void Update()
    {
        if (playerIsClose && Input.GetKeyDown(KeyCode.E)) 
        {
            if (otherPanel.activeInHierarchy) 
            {
                return;
            }
            else if (refusalActive) 
            {
                EndDialogue();
            }
            else if (!dialoguePanel.activeInHierarchy) 
            {
                dialoguePanel.SetActive(true);
                dialogueActive = true; 
                if (firstMeeting) 
                {
                    ShowFirstMeetingDialogue();
                }
                else
                {
                    ShowDialogue();
                }
            }
            else if (dialogueActive && !buttonsVisible) 
            {
                if (firstMeeting)
                {
                    ShowFirstMeetingDialogue();
                }
                else
                {
                    ShowDialogue();
                }
            }
        }
    }

    private void ShowFirstMeetingDialogue()
    {
        if (dialogueIndex < firstMeetingDialogue.Length)
        {
            dialogueText.text = firstMeetingDialogue[dialogueIndex]; 
            dialogueIndex++;
        }
        else
        {
            firstMeeting = false; 
            ShowButtons();
        }
    }

    private void ShowDialogue()
    {
        if (dialogueIndex < dialogues.Length)
        {
            dialogueText.text = dialogues[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            ShowButtons(); 
        }
    }

    private void ShowRefusalDialogue()
    {
        dialogueIndex = 0; 
        refusalActive = true; 
        buttonsVisible = false; 
        HideButtons();
        if (dialogueIndex < refusalDialogue.Length)
        {
            dialogueText.text = refusalDialogue[dialogueIndex];
            dialogueIndex++;
        }
        else
        {
            EndDialogue(); 
        }
    }

    public void OpenOtherPanel()
    {
        otherPanel.SetActive(true);   
        dialoguePanel.SetActive(false);
        HideButtons();                
    }

    public void EndDialogue()
    {
        if (dialoguePanel != null) 
        {
            dialoguePanel.SetActive(false); 
        }
        if (otherPanel != null) 
        {
            otherPanel.SetActive(false);    
        }
        if (openOtherPanelButton != null)
        {
            openOtherPanelButton.gameObject.SetActive(false); 
        }
        if (refusalButton != null) 
        {
            refusalButton.gameObject.SetActive(false);        
        }
        dialogueIndex = 0;  
        refusalActive = false; 
    }

    private void ShowButtons()
    {
        openOtherPanelButton.gameObject.SetActive(true); 
        refusalButton.gameObject.SetActive(true);      
        buttonsVisible = true;
    }

    private void HideButtons()
    {
        openOtherPanelButton.gameObject.SetActive(false); 
        refusalButton.gameObject.SetActive(false);   
        buttonsVisible = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false; 
            EndDialogue(); 
        }
    }
}
