using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] gameObjectPrefab;

    private float countDown;

    public float time;

    public bool creatObject;

    private TimeEnd timeEnd;
    private void Awake()
    {
        countDown = 1f;
        creatObject = false;
    }
    private void Start()
    {
        timeEnd = FindAnyObjectByType<TimeEnd>();
    }
    // Update is called once per frame
    void Update()
    {   if(timeEnd._time <= 0)
        {
            creatObject = false;
        }
        else
        {
            if (creatObject == true)
            {
                countDown -= Time.deltaTime; //moi frame coundown -= 1/fps
                if (countDown <= 0)
                {
                    int randomIndex = Random.Range(0, gameObjectPrefab.Length);
                    Instantiate(gameObjectPrefab[randomIndex], new Vector3(9.45f, Random.Range(-1.3f, -3.2f), 0), Quaternion.identity);
                    countDown = time;

                }
            }
        }
        
    }
}
