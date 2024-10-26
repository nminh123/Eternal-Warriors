using TMPro;
using UnityEngine;
using Eternal_Warriors._Scripts;

public class CointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoint;
    private int displayedCoint = 0;
    private float increaseSpeed = 20f;

    private void Start()
    {
        displayedCoint = GameManager.instance.Coin;
        textCoint.text = displayedCoint.ToString();
    }

    private void Update()
    {
        if (displayedCoint < GameManager.instance.Coin)
        {

            displayedCoint += Mathf.CeilToInt(increaseSpeed * Time.deltaTime);

            if (displayedCoint > GameManager.instance.Coin)
                displayedCoint = GameManager.instance.Coin;


            textCoint.text = displayedCoint.ToString();
        }
    }
}
