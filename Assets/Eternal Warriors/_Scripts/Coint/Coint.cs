using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coint : MonoBehaviour
{
    [SerializeField] int minCoint;
    [SerializeField] int maxCoint;
    [SerializeField] int timerCoint;

    private int cointRandom;

    private void Start()
    {
        cointRandom = Random.Range(minCoint, maxCoint);
        StartCoroutine(AddPointEndTime());
    }
    private void OnMouseDown()
    {        
        CointManager.instance.AddCoint(cointRandom);
        this.gameObject.SetActive(false);
    }
    IEnumerator AddPointEndTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(timerCoint);
            CointManager.instance.AddCoint(cointRandom);
            this.gameObject.SetActive(false);
        }
    }
}
