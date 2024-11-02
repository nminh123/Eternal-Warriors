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
            
            if (manager.SwordPower <= 0)
                manager.SwordPower = 3;
            if (manager.SwordHp <= 0)
                manager.SwordHp = 20;

            if (manager.HorsePower <= 0)
                manager.HorsePower = 7;
            if (manager.HorseHp <= 0)
                manager.HorseHp = 40;

            if (manager.ArrowPower <= 0)
                manager.ArrowPower = 2;
            if (manager.ArrowHp <= 0)
                manager.ArrowHp = 10;
        }
        
        private void OnApplicationQuit()
        {
            Save();
        }

        public void Save()
        {
            data.coin = manager.Coin;
            data.sp = manager.SwordPower;
            data.sh = manager.SwordHp;
            data.ap = manager.ArrowPower;
            data.ah = manager.ArrowHp;
            data.hop = manager.HorsePower;
            data.hoh = manager.HorseHp;
            data.potential = manager.Potential;
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
                Debug.Log("Location path: " + path);
                Debug.Log("Loaded Data: " + json);
            
                data = JsonConvert.DeserializeObject<SerializationData>(json);

                manager.Coin = data.coin;
                manager.SwordPower = data.sp;
                manager.SwordHp = data.sh;
                manager.ArrowPower = data.ap;
                manager.ArrowHp = data.ah;
                manager.HorsePower = data.hop;
                manager.HorseHp = data.hoh;
                manager.Potential = data.potential;
                manager.DateTime = data.Time;
            }
            else
                Debug.LogWarning("Save file not found. Initializing with default values.");
        }
    }
}