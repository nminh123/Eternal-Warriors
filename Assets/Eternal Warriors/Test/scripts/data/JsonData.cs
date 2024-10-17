namespace Test.scripts.data.core
{
    [System.Serializable]
    public struct JsonData
    {
        static int _score;

        public static int score
        {
            get
            {
                return score;
            }
            set
            {
                _score = value;
            }
        }
    }
}