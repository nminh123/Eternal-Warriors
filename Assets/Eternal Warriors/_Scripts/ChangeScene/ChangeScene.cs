using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using static CyclesProvider;
using UnityEngine.SocialPlatforms.Impl;

public class ChangeScene : MonoBehaviour
{
    private void Start()
    {
    }
    public void LoadGame()
    {
        StartCoroutine(timeLoadScene());
        SceneManager.LoadScene("CutScene 2");
    }

    public void LoadExit()
    {
        Application.Quit();
    }
    public void LoadMenu()
    {
        StartCoroutine(timeLoadScene());
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator timeLoadScene()
    {
        yield return new WaitForSeconds(0.18f);

    }

}