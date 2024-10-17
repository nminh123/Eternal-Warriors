namespace Test.scripts.data.core
{
    [System.Serializable]
    public class JsonData
    {
        private static int _score;
        public static int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }
    }
}