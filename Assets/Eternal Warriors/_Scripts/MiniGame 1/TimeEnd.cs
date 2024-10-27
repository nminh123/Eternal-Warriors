using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeEnd : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    public float _time = 45f;

    private bool gameStarted = false;

    void Start()
    {
        UpdateTimeDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 0)
        {
            
            UpdateTimeDisplay();
            if (gameStarted)
            {
                StatGame();
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameStarted = true;
                }
            }

        }
        else
        {
            _time = 0;
            Time.timeScale = 0;
            UpdateTimeDisplay();
        }
    }
    void UpdateTimeDisplay()
    {
        timeText.text = $"Time:{_time:0}s";
    }
    private void StatGame()
    {
        _time -= Time.deltaTime;
    }
}
