using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MiniGame2Manager : MonoBehaviour
    {
        public int score;

        public void IncreaseScore(int val)
        {
            score += val;
        }
    }
}