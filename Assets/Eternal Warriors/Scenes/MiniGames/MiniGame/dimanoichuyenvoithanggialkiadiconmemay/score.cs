using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Slider scoreSlider;
    public int maxScore = 10;
    private int score = 0;

    public void IncreaseScore()
    {
        score = Mathf.Min(maxScore, score + 1);
        UpdateScoreDisplay();
    }

    public void DecreaseScore()
    {
        score = Mathf.Max(0, score - 1);
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreSlider.value = score;
    }
}
