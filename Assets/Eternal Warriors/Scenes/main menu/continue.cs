using UnityEngine;
using TMPro;
using System.Collections;

public class BlinkingText : MonoBehaviour
{
    public TextMeshProUGUI clickText;
    private bool isBlinking = true;
    public float blinkInterval = 0.5f;

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (isBlinking)
        {
            clickText.text = "Click to Continue";
            yield return new WaitForSeconds(blinkInterval);
            clickText.text = "";
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            isBlinking = false;
            
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("NextScene"); 
    }
}
