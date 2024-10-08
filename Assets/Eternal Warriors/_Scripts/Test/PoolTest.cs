using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefabs;  // Updated name for clarity
    [SerializeField] private int poolSize = 10;
    public List<GameObject> poolObjects;
    public GameObject Bag;

    private void Awake()
    {
        poolObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            // Loop through all prefabs to initialize the pool correctly
            for (int j = 0; j < objectPrefabs.Length; j++)
            {
                GameObject obj = Instantiate(objectPrefabs[j]);
                obj.SetActive(false);
                poolObjects.Add(obj);
                obj.transform.parent = Bag.transform;
            }
        }
    }

    public GameObject GetObject(int index)  // Added index to choose prefab type
    {
        foreach (var obj in poolObjects)
        {
            if (!obj.activeInHierarchy && obj.name.Contains(objectPrefabs[index].name))
            {
                obj.SetActive(true);
                Debug.Log("Retrieved from pool: " + obj.name);
                return obj;
            }
        }

        // If no inactive objects, instantiate a new one based on the requested type
        GameObject newObj = Instantiate(objectPrefabs[index]);
        newObj.gameObject.name = objectPrefabs[index].gameObject.name;
        newObj.SetActive(true);
        poolObjects.Add(newObj);
        newObj.transform.parent = Bag.transform;
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        Debug.Log("Returned to pool: " + obj.name);
    }
}
