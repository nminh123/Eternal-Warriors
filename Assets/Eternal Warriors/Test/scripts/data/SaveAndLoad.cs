using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

namespace Test.scripts.data.core
{
    public class SaveAndLoad : MonoBehaviour
    {
        private string path;
        
        [FormerlySerializedAs("manager")] [SerializeField] private ManagerTest managerTest;
        private JsonData data;

        public void SaveGame()
        {
            if(!File.Exists(path))
                Debug.LogWarning("File not found!");
            if(data == null)
                Debug.LogWarning("Data is null!!");
            else
            {
                data.score = managerTest.Score;
                data.time = managerTest.Time;
                string json = JsonUtility.ToJson(data, true);
                Debug.Log(json);
                File.WriteAllText(path, json);
                Debug.Log("Data Score: " + data.score + " Manager Score: " + managerTest.Score);
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

                managerTest.Score = data.score;
                managerTest.Time = data.time;
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