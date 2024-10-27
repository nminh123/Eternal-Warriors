using TMPro;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class ScoreText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private MiniGame2Manager manager;

        private void Update()
        {
            scoreText.text = manager.score.ToString();
        }
    }
}