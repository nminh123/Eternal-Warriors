using System;
using UnityEngine;

namespace Test.scripts.data.core
{
    public class GameManager : MonoBehaviour
    {
        private SaveAndLoad manageData;

        private void Awake()
        {
            manageData = new SaveAndLoad();
        }

        private void Start()
        {
            manageData.Load();
        }

        private void OnApplicationQuit()
        {
            manageData.Save();
        }
    }
}