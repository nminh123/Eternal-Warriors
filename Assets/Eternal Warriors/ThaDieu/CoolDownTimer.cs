using UnityEngine;
using TMPro;

public class CoolDownTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] float timer;
    public bool isWined = false;

    private void Update()
    {
        Timer();
    }
    public void Timer()
    {
        timer -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if(timer <=0)
            isWined = true;
    }
}
