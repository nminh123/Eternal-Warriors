using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI waveText;
    [SerializeField] WaveSpawner waveSpawner;

    private int currentWave = 0;

    private void Start()
    {
        waveText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (waveSpawner.waveNumber != currentWave)
        {
            currentWave = waveSpawner.waveNumber;
            waveText.text = "Wave " + currentWave.ToString();
            StartCoroutine(TimerWave());
        }
    }

    IEnumerator TimerWave()
    {
        waveText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        waveText.gameObject.SetActive(false);
    }
}
