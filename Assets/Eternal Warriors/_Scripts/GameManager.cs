using UnityEngine;

namespace Eternal_Warriors._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public int Coin { get; set; }

        private void Awake()
        {
            instance = this;
        }

        public void AddCoin(int _coin)
        {
            Coin += _coin;
        }
        public void RemoveCount(int _coin)
        {
            if(Coin <= 0) return;
            if(Coin < _coin) return;

            Coin -= _coin;
        }
    }   
}