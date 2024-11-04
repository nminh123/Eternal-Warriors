using UnityEngine;

public class HideAllPanels : MonoBehaviour
{
    public GameObject[] panels;
    public void OnButtonPress()
    {
        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }
    }
}
