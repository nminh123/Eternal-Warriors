using UnityEngine.Serialization;

namespace Test.scripts.data.core
{
    [System.Serializable]
    public class JsonData
    {
        //Todo: Debug 2 biến này. time với score của lớp này đang null.
        public string time;
        public int score;
        
        public void SetValue(string time, int score)
        {
            this.time = time;
            this.score = score;
        }
    }
}