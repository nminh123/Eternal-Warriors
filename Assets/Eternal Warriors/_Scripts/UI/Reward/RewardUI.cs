using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Eternal_Warriors._Scripts;

public class RewardUI : MonoBehaviour
{
    public TowerAlly towerAlly;
    public TowerEnemy towerEnemy;
    public GameObject rewardPanel;
    public TextMeshProUGUI textCoint;
    public float setTimeActive;
    private void Start()
    {
        rewardPanel.SetActive(false);
    }
    private void Update()
    {        
        if (!towerAlly.islife || !towerEnemy.islife)
        {
            setTimeActive -= Time.deltaTime;
            if (setTimeActive > 0) return;
            textCoint.text = GameManager.instance.Coin.ToString();
            rewardPanel.SetActive(true);
        }
        
    }
    public void BtnHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
