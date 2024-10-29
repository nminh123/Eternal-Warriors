using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;

    public GameObject canvasEndGame;

    public GameObject[] starImage;

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

    public void ShowEndGameCanvas()
    {
        canvasEndGame.SetActive(true);
    }
}
