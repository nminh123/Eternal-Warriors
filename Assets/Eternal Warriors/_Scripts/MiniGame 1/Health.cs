using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    [SerializeField]
    private GameObject[] liveImage;

    [SerializeField]
    private int health = 3;

    private Animator myAnimator;

    private bool isDead = false;

    private bool isSlow = false;
    private float slowTimer = 0.5f; //thoi gian lam cham 
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        UpdateLiveImage();

    }
    private void Update()
    {
        if (isSlow)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0)
            {
                Time.timeScale = 0; // dung game
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VatCan"))
        {
            myAnimator.SetBool("is_Damage", true);
            health -= 1;
            UpdateLiveImage();
            CanvasManager.instance.UpdateStarImage(health);
           
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VatCan"))
        {
            myAnimator.SetBool("is_Damage", false);
        }
    }

    private void UpdateLiveImage()
    {
        for (int i = 0; i < 3; i++)
        {
            liveImage[i].GetComponent<Image>().color = i < health ? new Color(1, 1, 1, 1) : new Color(1, 1, 1, 0.5f);
        }
        if (health <= 0 && !isDead)
        {
            myAnimator.SetBool("is_Die", true);
            CanvasManager.instance.canvasEndGame.SetActive(true);
            isDead = true;
            isSlow = true;
        }
    }
}
