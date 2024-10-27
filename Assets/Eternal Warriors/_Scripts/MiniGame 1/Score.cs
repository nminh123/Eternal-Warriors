using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;
    public float _score = 0;

    private Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        scoreText.text = "Score:"+_score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Point"))
        {   
            SoundManager.instance.PlaySound("Bonus");
            myAnimator.SetBool("is_Reward", true);
            Destroy(collision.gameObject, 0.2f);
            //tang diem
            _score += 20;
            scoreText.text = "Score:"+_score.ToString();

        }
        else if (collision.gameObject.CompareTag("PointBig"))
        {
            SoundManager.instance.PlaySound("Bonus");
            myAnimator.SetBool("is_Reward", true);
            Destroy(collision.gameObject, 0.2f);
            //tang diem
            _score += 40;
            scoreText.text = "Score:"+_score.ToString();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PointBig") || collision.gameObject.CompareTag("Point"))
        {
            myAnimator.SetBool("is_Reward", false);
        }
    }
}
