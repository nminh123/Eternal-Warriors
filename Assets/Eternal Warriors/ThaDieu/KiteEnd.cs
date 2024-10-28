using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class KiteEnd : MonoBehaviour
{
    public static KiteEnd instance;
    [SerializeField] private CoolDownTimer coolDownTimer;
    [SerializeField] private KiteUI kiteUI;
    [SerializeField] private CoolDownTimer timer;
    
    [SerializeField] private GameObject panel;
    public bool isOpenUI;
    public float timeIsOpen;

    private void Awake()
    {
        instance = this;
        isOpenUI = false;
        panel.SetActive(false);
    }
    private void Update()
    {
        OpenUI();
        if (isOpenUI)
        {
            timer.gameObject.SetActive(false);
            timeIsOpen -= Time.deltaTime;
            if (timeIsOpen < 0)  
                panel.SetActive(true);

        }
        
    }

    public void OpenUI()
    {
        if (coolDownTimer.isWined)
            isOpenUI = true;
        else if (kiteUI.isLose)
            isOpenUI = true;
    }
}
