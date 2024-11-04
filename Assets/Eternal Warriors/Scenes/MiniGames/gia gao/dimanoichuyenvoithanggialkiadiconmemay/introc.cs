using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    private bool isIntroActive = true;
    private int currentLine = 0;

    public string[] introLines;
    public TextMeshProUGUI introText; 
    public string nextSceneName; 

    void Start()
    {
        DisplayCurrentLine();
    }

    void Update()
    {
        if (isIntroActive)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                AdvanceIntro();
            }
        }
    }

    void DisplayCurrentLine()
    {
        if (introLines != null && currentLine < introLines.Length)
        {
            introText.text = introLines[currentLine];
        }
        else
        {
            EndIntro();
        }
    }

    void AdvanceIntro()
    {
        currentLine++;

        if (currentLine < introLines.Length)
        {
            DisplayCurrentLine();
        }
        else
        {
            EndIntro();
        }
    }

    void EndIntro()
    {
        isIntroActive = false;

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
