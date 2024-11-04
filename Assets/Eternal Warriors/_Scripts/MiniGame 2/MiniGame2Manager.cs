using UnityEngine;

namespace Eternal_Warriors._Scripts.MiniGame_2
{
    public class MiniGame2Manager : MonoBehaviour
    {
        [SerializeField] private BoatCtrl boatCtrl;
        public int score;
        public GameObject canvasEndGame;
        public void IncreaseScore(int val)
        {
            score += val;
        }

        private void Update()   
        {
            if (score == 7) 
            {   
                canvasEndGame.SetActive(true);
                FollowedCamera.speed = 0;
                boatCtrl.speed = 0;
            }

            
        }
    }
}