using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Eternal_Warriors._Scripts.MiniGame_3.Quizz
{
    public class AnswerData
    {
        [Header("UI Elements")] 
        [SerializeField] private TextMeshProUGUI infoTextObject;
        [SerializeField] private Image toggle;

        [Header("Textures")] 
        [SerializeField] private Sprite uncheckedToggle;
        [SerializeField] private Sprite checkToggle;

        private int answerIndex = -1;
        public int AnswerIndex
        {
            get { return answerIndex; }
        }
    }
}