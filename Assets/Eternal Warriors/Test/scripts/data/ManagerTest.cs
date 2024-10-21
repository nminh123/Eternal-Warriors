using System;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class ManagerTest : MonoBehaviour
    {
        public int Score { get; set; }
        public string Time { get; set; }

        private void Awake()
        {
            Score = 0;
            Time = DateTime.Now.ToString("MM/dd/yyyy");
        }
    }
}