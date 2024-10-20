using UnityEngine;
using System.IO;

namespace Test.scripts.data.core
{
    public class SaveAndLoad : MonoBehaviour
    {
        private string time;
        private int score;

        [SerializeField] private GameManager manager;

        public void SaveGame()
        {
            JsonData data = new JsonData();
            data.SetValue(time, score);

            string json = JsonUtility.ToJson(data);
            string path = Application.persistentDataPath + "/data.json";
            File.WriteAllText(path, json);
            Debug.Log("Score: " + data.score);
        }

        public void LoadGame()
        {
            string path = Application.persistentDataPath + "/data.json";
            
            if(!File.Exists(path))
                Debug.LogWarning("File not found!");
            else
            {
                string json = File.ReadAllText(path);
                JsonData data = JsonUtility.FromJson<JsonData>(json);

                manager.score = data.score;
                manager.time = data.time;
            }
        }

        private void Awake()
        {
            LoadGame();
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}