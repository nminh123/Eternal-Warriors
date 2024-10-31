using TMPro;
using UnityEngine;

namespace Eternal_Warriors._Scripts.Coint
{
    public class CointUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textCoint;
        [SerializeField] private GameManager manager;
    

        private void Start()
        {
            textCoint.text = manager.Coin.ToString();
        }

        private void Update()
        {
            textCoint.text = manager.Coin.ToString();
        }
    }
}