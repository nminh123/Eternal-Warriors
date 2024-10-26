using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

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
            textCoint.text = CointManager.instance.coint.ToString();
            rewardPanel.SetActive(true);
        }
        
    }
    public void BtnHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
