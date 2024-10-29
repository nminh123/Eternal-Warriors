using System.Collections.Generic;
using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_3.Quizz
{
    public class MiniGame3Manager : MonoBehaviour
    {
        private Question[] questions = null;
        public Question[] Questions
        {
            get { return questions; }
        }

        [SerializeField] private GameEvents events = null;
        
        private List<AnswerData> PickedAnswers = new List<AnswerData>();
        private List<int> FinishQuestions = new List<int>();
        private int currentQuestion = 0;
        // public int score;

        private void Start()
        {
            LoadQuestions();
            foreach (var ques in questions)
            {
                Debug.Log(ques.Info);
            }
            Display();
        }

        public void EraseAnswers()
        {
            PickedAnswers = new List<AnswerData>();
        }

        void Display()
        {
            EraseAnswers();
            var question = GetRandomQuestion();

            if (events.UpdateQuestionUI != null)
            {
                events.UpdateQuestionUI(question);
            }
            else
            {
                Debug.LogWarning("Hỏng rồi! Có cái gì đó sai sai khi xuất 'new Question UI Data'. GameEvents.UpdateQuestionUI đang null. Vấn đề xảy ra ở hàm MiniGame2Manageer.Display()");
            }
        }

        Question GetRandomQuestion()
        {
            var randomIndex = GetRandomQuestionIndex();
            currentQuestion = randomIndex;

            return Questions[currentQuestion];
        }

        int GetRandomQuestionIndex()
        {
            var random = 0;
            if (FinishQuestions.Count < Questions.Length)
            {
                do
                {
                    random = Random.Range(0, Questions.Length);
                } while (FinishQuestions.Contains(random) || random == currentQuestion);
            }

            return random;
        }
        
        void LoadQuestions()
        {
            Object[] objs = Resources.LoadAll("Questions", typeof(Question));
            questions = new Question[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                questions[i] = (Question)objs[i];
            }
        }
    }
    
}