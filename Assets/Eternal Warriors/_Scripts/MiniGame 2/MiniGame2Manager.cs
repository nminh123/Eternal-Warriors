using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MiniGame2Manager : MonoBehaviour
    {
        [ReadOnly] public int score;

        public void IncreaseScore(int val)
        {
            score += val;
        }
    }
}