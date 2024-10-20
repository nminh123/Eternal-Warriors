using UnityEngine;
using System.IO;

namespace Test.scripts.data.core
{
    public class SaveAndLoad : MonoBehaviour
    {
        private string path;
        
        [SerializeField] private GameManager manager;
        private JsonData data;

        public void SaveGame()
        {
            if(!File.Exists(path))
                Debug.LogWarning("File not found!");
            if(data == null)
                Debug.LogWarning("Data is null!!");
            else
            {
                data.score = manager.Score;
                data.time = manager.Time;
                string json = JsonUtility.ToJson(data, true);
                Debug.Log(json);
                File.WriteAllText(path, json);
                Debug.Log("Data Score: " + data.score + " Manager Score: " + manager.Score);
            }
        }

        public void LoadGame()
        {
            if (!File.Exists(path))
            {
                Debug.LogWarning("File not found!");
                SaveGame();
            }
            if(data == null)
                Debug.LogWarning("Data is null!!");
            else
            {
                string json = File.ReadAllText(path);
                data = JsonUtility.FromJson<JsonData>(json);

                manager.Score = data.score;
                manager.Time = data.time;
            }
        }

        private void Awake()
        {
            data = new JsonData();
            path = Application.persistentDataPath + "/data.json";
        }

        private void Start()
        {
            LoadGame();
        }
        
        private void OnApplicationQuit()
        {
            SaveGame();
        }
    }
}