using System.Collections;
using UnityEngine;
using TMPro;

public class NPCDialogueS : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogues;

    private Animator anim;
    
    private int currentLine = 0;
    private bool isDialogueActive = false;
    private bool playerIsClose = false;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float leftBound;
    [SerializeField] private float rightBound;
    private bool isMovingLeft = true;
    private bool isMoving = true;
    private bool isAnimRun = true;

    void Start()
    {
        // Thiết lập hướng ban đầu cho NPC dựa trên vị trí hiện tại và các giới hạn
        isMovingLeft = (transform.position.x > (leftBound + rightBound) / 2);
        FlipFacingDirection();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving && !isDialogueActive)
        {
            Patrol();
            isAnimRun = true;
        }

        if (playerIsClose && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            if (isDialogueActive)
            {
                ShowNextLine();
                isAnimRun = false;
            }
            else
            {
                StartDialogue();
                isAnimRun = false;
            }
        }

        this.Animation();
    }
    
    public void Animation()
    {
        anim.SetBool("IsMove", isAnimRun);
    }

    private void Patrol()
    {
        // Lấy vị trí hiện tại của NPC
        Vector3 curPosition = transform.position;

        // Xác định điểm đích mà NPC sẽ di chuyển tới
        float targetPositionX = isMovingLeft ? leftBound : rightBound;
        Vector3 targetPosition = new Vector3(targetPositionX, curPosition.y, curPosition.z);

        // Di chuyển NPC về phía vị trí đích một cách mượt mà
        transform.position = Vector3.MoveTowards(curPosition, targetPosition, moveSpeed * Time.deltaTime);

        // Khi NPC đạt tới vị trí biên, đổi hướng di chuyển và xoay mặt
        if (curPosition.x <= leftBound)
        {
            isMovingLeft = false;
            FlipFacingDirection(); // Xoay mặt về bên phải
        }
        else if (curPosition.x >= rightBound)
        {
            isMovingLeft = true;
            FlipFacingDirection(); // Xoay mặt về bên trái
        }
    }

    private void FlipFacingDirection()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = isMovingLeft ? -Mathf.Abs(localScale.x) : Mathf.Abs(localScale.x);
        transform.localScale = localScale;
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
            if (isDialogueActive)
            {
                EndDialogue();
            }
            isMoving = true;  // Tiếp tục di chuyển lại khi người chơi rời xa
        }
    }

    private void StartDialogue()
    {
        isDialogueActive = true;
        dialoguePanel.SetActive(true);
        currentLine = 0;
        ShowNextLine();
        isMoving = false;  
    }

    private void EndDialogue()
    {
        isDialogueActive = false;
        dialoguePanel.SetActive(false);
        currentLine = 0;
        isMoving = true; 
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
