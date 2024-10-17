using UnityEngine;
using System.IO;

namespace Test.scripts.data.core
{
    public class SaveAndLoad
    {
        private static readonly string Path = Application.persistentDataPath + "/dat.json";
        JsonData data = new JsonData();

        public void Save()
        {
            if (data == null)
            {
                Debug.LogWarning("Không tìm thấy dữ liệu để lưu");
                return;
            }
            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(Path, json);
            Debug.Log("Saved Data!!");
        }

        public void Load()
        {
            if (data == null)
            {
                Debug.LogWarning("Không tìm thấy dữ liệu để tải về!!");
                return;
            }
            string json = File.ReadAllText(Path);
            data = JsonUtility.FromJson<JsonData>(json);
            Debug.Log("Loaded Data!!");
        }
    }
}