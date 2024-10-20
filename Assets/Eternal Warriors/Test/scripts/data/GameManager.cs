using UnityEngine;

namespace Test.scripts.data.core
{
    public class GameManager : MonoBehaviour
    {
        public int Score { get; set; }

        private void Awake()
        {
            Score = 0;
        }
    }
}