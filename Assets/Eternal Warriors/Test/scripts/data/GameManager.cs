using System;
using System.IO;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class GameManager : MonoBehaviour
    {
        public int score;
        public string time;
        
        private void Awake()
        {
            score = 0;
            time = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss");
        }
    }
}