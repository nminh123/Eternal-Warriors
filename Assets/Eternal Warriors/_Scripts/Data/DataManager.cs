using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Eternal_Warriors._Scripts.Data
{
    public class DataManager : MonoBehaviour
    {
        [SerializeField] private GameManager manager;
        [SerializeField] private SerializationData data;
        private string path = Application.dataPath + "/savedata.json";

        private void Start()
        {
            Load();
        }

        private void OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            data.coin = manager.Coin;
            data.Time = manager.DateTime;
    
            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
            Debug.Log("Saved Data: " + json);
        }

        public void Load()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                Debug.Log("Loaded Data: " + json);
            
                data = JsonConvert.DeserializeObject<SerializationData>(json);

                manager.Coin = data.coin;
                manager.DateTime = data.Time;
            }
            else
                Debug.LogWarning("Save file not found. Initializing with default values.");
        }
    }
}