using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject canvasEndGame;

    public GameObject[] starImage;

    public TextMeshProUGUI scoreEnd;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        canvasEndGame.SetActive(false);
    }
    public void UpdateStarImage(int health)
    {
        for (int i = 0; i < starImage.Length; i++)
        {
            starImage[i].SetActive(i < health);
        }
    }
    public void GetScore(float score)
    {
        scoreEnd.text = "Score:" + score.ToString();
    }


    public void ShowEndGameCanvas(float score)
    {   
        GetScore(score);
        canvasEndGame.SetActive(true);
    }
}
