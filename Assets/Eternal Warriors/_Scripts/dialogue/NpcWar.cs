using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcUpgrade : NPCShop
{
    [SerializeField] private string loadScene;

    protected override void OpenOtherPanel()
    {
        SceneManager.LoadScene(loadScene);
    }
        
}
