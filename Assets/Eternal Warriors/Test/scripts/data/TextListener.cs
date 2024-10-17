using System;
using TMPro;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class TextListener : MonoBehaviour
    {
        [SerializeField]private TextMeshProUGUI score;

        private void Update()
        {
            score.text = JsonData.score.ToString();
        }
    }
}