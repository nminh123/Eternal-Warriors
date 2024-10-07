using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUI : MonoBehaviour
{
    public Image PowerImage;
    public TextMeshProUGUI PowerText;
    private Power power;

    private float timer;
    private float progress;
    private void Start()
    {
        power = Power.instance;
    }

    private void Update()
    {
        RefreshUI();
        UpdatePowerBar();
    }

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= power.PowerTimer)
        {
            power.AddPower(1);
            timer = 0;
        }
    }

    private void RefreshUI()
    {
        PowerText.text = power.power.ToString();
    }

    private void UpdatePowerBar()
    {
        progress = timer / power.PowerTimer;
        PowerImage.fillAmount = Mathf.Clamp01(progress);
    }
}
