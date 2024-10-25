using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewardUI : MonoBehaviour
{
    public Tower tower;
    public GameObject rewardPanel;
    public float setTimeActive;
    private void Start()
    {
        rewardPanel.SetActive(false);
    }
    private void Update()
    {        
        if (!tower.isLive)
        {
            setTimeActive -= Time.deltaTime;
            if (setTimeActive > 0) return;
            rewardPanel.SetActive(true);
        }
            
    }
    public void BtnHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
