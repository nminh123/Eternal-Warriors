using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_3.Quizz
{
    [CreateAssetMenu(fileName = "GameEvents", menuName = "Quiz/ new GameEvents")]
    public class GameEvents : ScriptableObject
    {
        public delegate void UpdateQuestionUICallBack(Question question);
        public UpdateQuestionUICallBack UpdateQuestionUI;

        public delegate void UpdateQuestionAnswerCallBack(AnswerData pickedAnswer);
        public UpdateQuestionAnswerCallBack UpdateQuestionAnswer;

        public delegate void DisplayResolutionScreenCallBack(UIManager.ResolitionScreenType type, int score);
        public DisplayResolutionScreenCallBack DisplayResolutionScreen;

        public delegate void ScoreUpdatedCallBack();
        public ScoreUpdatedCallBack ScoreUpdated;
        
        public int CurrentFinalScore;
    }
}