using MidniteOilSoftware.ObjectPoolManager;
using System.Collections;
using UnityEngine;
using Eternal_Warriors._Scripts;

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
            ReturnPool(this.gameObject);

    }
    protected void FixedUpdate()
    {
        if(!towerAlly.islife || !towerEnemy.islife)
            ReturnPool(this.gameObject);
    }
    IEnumerator AddPointEndTime()
    {
        yield return new WaitForSeconds(timerCoint);
        if (!hasAddedCoint)
            ReturnPool(this.gameObject);
    }

    public void ReturnPool(GameObject obj)
    {
        if (!hasAddedCoint)
        {
            GameManager.instance.AddCoin(cointRandom);
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
