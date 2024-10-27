using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObjectPrefab;

    private float countDown;

    public float time;

    public bool creatObject;

    private void Awake()
    {
        countDown = 1f;
        creatObject = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (creatObject == true)
        {
            countDown -= Time.deltaTime; //moi frame coundown -= 1/fps
            if (countDown <= 0)
            {
                int randomIndex = Random.Range(0, gameObjectPrefab.Length);
                Instantiate(gameObjectPrefab[randomIndex], new Vector3(9.45f, Random.Range(-1.1f, -3.2f), 0), Quaternion.identity);
                countDown = time;
                
            }
        }
    }
}
