using UnityEngine.Serialization;

namespace Test.scripts.data.core
{
    [System.Serializable]
    public class JsonData
    {
        [FormerlySerializedAs("Time")] public string time;
        [FormerlySerializedAs("Score")] public int score;
        
        public void SetValue(string time, int score)
        {
            this.time = time;
            this.score = score;
        }
    }
}