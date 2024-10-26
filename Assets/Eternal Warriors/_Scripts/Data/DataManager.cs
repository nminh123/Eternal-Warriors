using System.IO;
using UnityEngine;

namespace Eternal_Warriors._Scripts.Data
{
    public class DataManager : MonoBehaviour
    {
        private string path;

        [SerializeField] private GameManager manager;
        private DataJson data;
        
        public void SaveGame()
        {
            if(!File.Exists(path))
                Debug.LogWarning("File not found!");
            if(data == null)
                Debug.LogWarning("Data is null!!");
            else
            {
                data.coin = manager.Coin;
                string json = JsonUtility.ToJson(data, true);
                Debug.Log(json);
                File.WriteAllText(path, json);
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
                data = JsonUtility.FromJson<DataJson>(json);

                manager.Coin = data.coin;
            }
        }
        
        private void Awake()
        {
            data = new DataJson();
            path = Application.persistentDataPath + "/data/dat.json";
            Debug.Log(path);
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