using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using UnityEngine;

public class Coint : MonoBehaviour
{
    [SerializeField] int minCoint;
    [SerializeField] int maxCoint;
    [SerializeField] int timerCoint;

    private int cointRandom;
    private Coroutine timerCoroutine;

    private void OnEnable()
    {
        cointRandom = Random.Range(minCoint, maxCoint);
        timerCoroutine = StartCoroutine(AddPointEndTime());
    }

    private void OnDisable()
    {
        
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    private void OnMouseDown()
    {
        CointManager.instance.AddCoint(cointRandom);
        ReturnPool(this.gameObject);
    }

    IEnumerator AddPointEndTime()
    {
        yield return new WaitForSeconds(timerCoint);
        CointManager.instance.AddCoint(cointRandom);
        ReturnPool(this.gameObject);
    }

    public void ReturnPool(GameObject obj)
    {
        
        ObjectPoolManager.DespawnGameObject(obj);
    }
}
