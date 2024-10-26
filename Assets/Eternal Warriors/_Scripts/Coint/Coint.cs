using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Coint : MonoBehaviour
{
    [SerializeField] int minCoint;
    [SerializeField] int maxCoint;
    [SerializeField] int timerCoint;

    public int cointRandom;
    private Coroutine timerCoroutine;
    private bool hasAddedCoint = false;
    private TowerAlly towerAlly;
    private TowerEnemy towerEnemy;

    [SerializeField] Transform endCoint;

    private void OnEnable()
    {
        endCoint = GameObject.Find("EndCoint").GetComponent<Transform>();
        towerAlly = FindObjectOfType<TowerAlly>();
        towerEnemy = FindObjectOfType<TowerEnemy>();
        cointRandom = Random.Range(minCoint, maxCoint);
        timerCoroutine = StartCoroutine(AddPointEndTime());
        hasAddedCoint = false;
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
        if (!hasAddedCoint)
            AnimaCoint(endCoint, 1);

    }
    protected void FixedUpdate()
    {
        if(!towerAlly.islife || !towerEnemy.islife)
            AnimaCoint(endCoint, 1);
    }
    IEnumerator AddPointEndTime()
    {
        yield return new WaitForSeconds(timerCoint);
        if (!hasAddedCoint)
            AnimaCoint(endCoint, 1);

    }

    public void ReturnPool(GameObject obj)
    {
        if (!hasAddedCoint)
        {
            CointManager.instance.AddCoint(cointRandom);
            hasAddedCoint = true;
        }
        ObjectPoolManager.DespawnGameObject(obj);
    }

    public void AnimaCoint(Transform targetPosition, float duration)
    {
        LeanTween.move(gameObject, targetPosition, duration).setEaseLinear()
            .setOnComplete(() => ReturnPool(this.gameObject));
    }
}
