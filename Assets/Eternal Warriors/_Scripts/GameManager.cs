using System;
using UnityEngine;

namespace Eternal_Warriors._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private int _coin;
        public int Coin
        {
            get => _coin;
            set
            {
                _coin = value;
            }
        }

        private DateTime dateTime = DateTime.UtcNow;
        public DateTime DateTime
        {
            get => dateTime;
            set
            {
                dateTime = value;
            }
        }

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