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
    protected int dialogueIndex = 0;
    protected bool playerIsClose = false;
    protected bool dialogueActive = false;
    protected bool firstMeeting = true;
    protected bool refusalActive = false;
    protected bool buttonsVisible = false;

    protected void Start()
    {
        dialoguePanel.SetActive(false);
        otherPanel.SetActive(false);
        openOtherPanelButton.gameObject.SetActive(false);
        refusalButton.gameObject.SetActive(false);

        openOtherPanelButton.onClick.AddListener(OpenOtherPanel);
        refusalButton.onClick.AddListener(ShowRefusalDialogue);
    }

    protected void Update()
    {
        if (playerIsClose && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
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
                dialogueIndex = 0;
                dialogueText.text = "";

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

    protected void ShowFirstMeetingDialogue()
    {
        while (dialogueIndex < firstMeetingDialogue.Length && string.IsNullOrWhiteSpace(firstMeetingDialogue[dialogueIndex]))
        {
            dialogueIndex++;
        }

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


    protected void ShowRefusalDialogue()
    {
        dialogueIndex = 0;
        refusalActive = true;
        buttonsVisible = false;
        HideButtons();

        dialogueText.text = "";

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

    protected virtual void OpenOtherPanel()
    {
        otherPanel.SetActive(true);
        dialoguePanel.SetActive(false);
        HideButtons();
    }

    protected void EndDialogue()
    {
        if (dialoguePanel != null && dialoguePanel.activeInHierarchy)
        {
            dialoguePanel.SetActive(false);
        }

        if (otherPanel != null && otherPanel.activeInHierarchy)
        {
            otherPanel.SetActive(false);
        }

        if (openOtherPanelButton != null && openOtherPanelButton.gameObject.activeInHierarchy)
        {
            openOtherPanelButton.gameObject.SetActive(false);
        }

        if (refusalButton != null && refusalButton.gameObject.activeInHierarchy)
        {
            refusalButton.gameObject.SetActive(false);
        }

        dialogueIndex = 0;
        refusalActive = false;
        buttonsVisible = false;
    }


    protected void ShowDialogue()
    {
        while (dialogueIndex < dialogues.Length && string.IsNullOrWhiteSpace(dialogues[dialogueIndex]))
        {
            dialogueIndex++; 
        }

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


    protected virtual void ShowButtons()
    {
        openOtherPanelButton.gameObject.SetActive(true);
        refusalButton.gameObject.SetActive(true);
        buttonsVisible = true;
    }

    protected void HideButtons()
    {
        openOtherPanelButton.gameObject.SetActive(false);
        refusalButton.gameObject.SetActive(false);
        buttonsVisible = false;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            EndDialogue();
        }
    }
}
