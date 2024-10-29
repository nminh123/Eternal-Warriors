using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2.Quizz
{
    [System.Serializable]
    public struct Answer
    {
        [SerializeField] private string info;
        public string Info
        {
            get { return info; }
        }

        [SerializeField] private bool isCorrect;
        public bool IsCorrect
        {
            get { return isCorrect; }
        }
    }
}