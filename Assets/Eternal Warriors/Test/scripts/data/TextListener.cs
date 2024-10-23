using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Test.scripts.data.core
{
    public class TextListener : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;
        [FormerlySerializedAs("manager")] [SerializeField] private ManagerTest managerTest;

        private void Update()
        {
            score.text = managerTest.Score.ToString();
        }
    }
}