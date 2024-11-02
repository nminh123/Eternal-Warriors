using System;
using UnityEngine;

namespace Eternal_Warriors._Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private int coin;
        public int Coin
        {
            get => coin;
            set
            {
                coin = value;
            }
        }
        private int potential;
        public int Potential
        {
            get => potential;
            set
            {
                potential = value;
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

        private int swordPower;
        public int SwordPower
        {
            get => swordPower;
            set
            {
                swordPower = value;
            }
        }

        private int swordHp;
        public int SwordHp
        {
            get => swordHp;
            set
            {
                swordHp = value;
            }
        }
        
        private int horsePower;
        public int HorsePower
        {
            get => horsePower;
            set
            {
                horsePower = value;
            }
        }
        
        private int horseHp;
        public int HorseHp
        {
            get => horseHp;
            set
            {
                horseHp = value;
            }
        }
        
        private int arrowPower;
        public int ArrowPower
        {
            get => arrowPower;
            set
            {
                arrowPower = value;
            }
        }
        
        private int arrowHp;
        public int ArrowHp
        {
            get => arrowHp;
            set
            {
                arrowHp = value;
            }
        }
        
        private void Awake()
        {
            instance = this;
        }

        public void AddCoin(int coin)
        {
            Coin += coin;
        }
        public void RemoveCount(int coin)
        {
            if(Coin <= 0) return;
            if(Coin < coin) return;

            Coin -= coin;
        }
        
        public void AddPotinal(int potinal)
        {
            Potential += potinal;
        }
        
        public void RemovePotinal(int potinal, int coin)
        {
            if(Potential <= 0) return;
            if(Potential < potinal) return;
            if (Coin < coin) return;
            Coin -= coin;
            Potential -= potinal;
        }

    }
}