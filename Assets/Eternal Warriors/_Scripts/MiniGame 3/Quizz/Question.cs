using System.Collections.Generic;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_3.Quizz
{
    [CreateAssetMenu(fileName = "New Question", menuName = "Quiz/ new Question")]
    public class Question : ScriptableObject
    {
        [SerializeField] private string info = string.Empty;
        public string Info
        {
            get { return info; }
        }

        [SerializeField] private Answer[] answers = null;
        public Answer[] Answers
        {
            get { return answers; }
        }

        [SerializeField] private bool userTimer = false;
        public bool UseTimer
        {
            get { return userTimer; }
        }

        [SerializeField] private int timer = 0;
        public int Timer
        {
            get { return timer; }
        }

        [SerializeField] private AnswerType answerType = AnswerType.Multi;
        public AnswerType GetAnswerType
        {
            get { return answerType; }
        }

        [SerializeField] private int addScore = 10;
        public int AddScore
        {
            get { return addScore; }
        }

        public List<int> GetCorrectAnswers()
        {
            List<int> CorrectAnswers = new List<int>();

            for (int i = 0; i < answers.Length; i++)
            {
                if (answers[i].IsCorrect)
                {
                    CorrectAnswers.Add(i);
                }
            }

            return CorrectAnswers;
        }
    }
}