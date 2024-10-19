using TMPro;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class TextListener : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI score;
        [SerializeField] private GameManager manager;

        private void Update()
        {
            score.text = manager.score.ToString();
        }
    }
}