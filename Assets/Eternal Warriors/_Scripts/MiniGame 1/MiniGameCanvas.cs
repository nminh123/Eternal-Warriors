using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject canvasEndGame;

    [SerializeField]
    private GameObject[] starGame;

    [SerializeField]
    private int health = 3;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasEndGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VatCan"))
        {
            health -= 1;
            UpdateLiveImage();
        }
    }

    private void UpdateLiveImage()
    {
        for (int i = 0; i < 3; i++)
        {
            starGame[i].GetComponent<Image>().color = i < health ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.5f);
        }
        if (health <= 0 && !isDead)
        {
            canvasEndGame.SetActive(true);
            isDead = true;
        }
    }
}
