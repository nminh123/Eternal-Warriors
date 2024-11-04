using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeEnd : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timeText;
    public float _time = 48f;

    private bool gameStarted = false;
    private Score scoreManager;

    private bool controlsEnabled = false;
    void Start()
    {
        UpdateTimeDisplay();
        scoreManager = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlsEnabled)
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
                    if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        gameStarted = true;
                    }
                }

            }
            else
            {
                _time = 0;
                //SoundManager.instance.PlaySound("Victory");
                //Time.timeScale = 0;
                UpdateTimeDisplay();
                CanvasManager.instance.ShowEndGameCanvas(scoreManager.GetScore());
            }
        }
    }
    void UpdateTimeDisplay()
    {
        //timeText.text = $"Time:{_time:0}s";
        int minutes = Mathf.FloorToInt(_time / 60);
        int seconds = Mathf.FloorToInt(_time % 60);

        timeText.text = $"{minutes}:{seconds:00}";
    }
    private void StatGame()
    {
        _time -= Time.deltaTime;
    }
    public void EnableControl(bool enabled)
    {
        controlsEnabled = enabled;
    }
}
