using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public TextMeshProUGUI startGame;
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
            startGame.text = "-> Press Space to Start <-";
            yield return new WaitForSeconds(blinkInterval);
            startGame.text = "";
            yield return new WaitForSeconds(blinkInterval);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isBlinking = false;
            startGame.text = "";
        }
    }
}
