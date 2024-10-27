using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KiteUI : MonoBehaviour
{
    public TestKite kite;
    public Image kiteSlider;
    public float maxEnergy = 100;
    public float currentEnergy;
    public bool isLose = false;

    private void Start()
    {
        currentEnergy = maxEnergy;
    }

    private void FixedUpdate()
    {
        if (KiteEnd.instance.isOpenUI) return;
        UpdateKiteUI();
    }

    public void UpdateKiteUI()
    {
        if (kite.isZoned) 
        {
            currentEnergy += 10 * Time.fixedDeltaTime;
        }
        else
        {
            currentEnergy -= 10 * Time.fixedDeltaTime;
        }

        if(currentEnergy <= 0)
            isLose = true;  
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);

        kiteSlider.fillAmount = currentEnergy / maxEnergy;
    }
}
