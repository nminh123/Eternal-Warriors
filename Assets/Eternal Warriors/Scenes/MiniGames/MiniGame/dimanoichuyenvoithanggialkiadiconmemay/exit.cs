using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    public Button button;  
    public string sceneName;  

    void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(SwitchScene);
        }
    }

    void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
