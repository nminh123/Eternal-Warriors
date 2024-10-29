using System.Collections.Generic;
using Eternal_Warriors._Scripts.MiniGame_2.Quizz;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MiniGame2Manager : MonoBehaviour
    {
        private Question[] questions = null;
        public Question[] Questions
        {
            get { return questions; }
        }

        private List<int> FinishQuestions = new List<int>();
        private int currentQuestion = 0;
        public int score;

        public void IncreaseScore(int val)
        {
            score += val;
        }

        void Display()
        {
            
        }
    }
}