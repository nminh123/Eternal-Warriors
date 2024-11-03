using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Eternal_Warriors._Scripts;

public class RewardUI : MonoBehaviour
{
    public TowerAlly towerAlly;
    public TowerEnemy towerEnemy;
    public GameObject PanelHome;
    public GameObject PanelNext;
    public TextMeshProUGUI textCoint;
    public float setTimeActive;
    private void Start()
    {
        PanelHome.SetActive(false);
        PanelNext.SetActive(false);
    }
    private void Update()
    {
        if (!towerAlly.islife)
        {
            setTimeActive -= Time.deltaTime;
            if (setTimeActive > 0) return;
            textCoint.text = GameManager.instance.Coin.ToString();
            PanelHome.SetActive(true);
        }
        else if (!towerEnemy.islife)
        {
            setTimeActive -= Time.deltaTime;
            if (setTimeActive > 0) return;
            textCoint.text = GameManager.instance.Coin.ToString();
            PanelNext.SetActive(true);
        }

    }
    public void BtnHome(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}