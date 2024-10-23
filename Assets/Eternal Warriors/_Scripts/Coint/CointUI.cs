using TMPro;
using UnityEngine;

public class CointUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textCoint;
    private int displayedCoint = 0;
    private float increaseSpeed = 20f;

    private void Start()
    {
        displayedCoint = CointManager.instance.coint;
        textCoint.text = displayedCoint.ToString();
    }

    private void Update()
    {
        if (displayedCoint < CointManager.instance.coint)
        {

            displayedCoint += Mathf.CeilToInt(increaseSpeed * Time.deltaTime);

            if (displayedCoint > CointManager.instance.coint)
                displayedCoint = CointManager.instance.coint;


            textCoint.text = displayedCoint.ToString();
        }
    }
}
