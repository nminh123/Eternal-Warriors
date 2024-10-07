using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10; 
    public List<GameObject> poolObjects;
    public GameObject Bag;

    private void Awake()
    {
        poolObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false); 
            poolObjects.Add(obj);
            obj.transform.parent = Bag.transform;
        }
    }

    public GameObject GetObject()
    {
        foreach (var obj in poolObjects)
        {
            if (!obj.activeInHierarchy) 
            {
                obj.SetActive(true);
                return obj;
            }
        }


        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(true);
        poolObjects.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
