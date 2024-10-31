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

    [SerializeField]
    private float spawnX;
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
                    Instantiate(gameObjectPrefab[randomIndex], new Vector3(Random.Range(7f, 65f), Random.Range(0.64f, -2.31f), 0), Quaternion.identity);
                    countDown = time;

                }
            }
        }
        
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Camera"))
    //    {
    //        creatObject = false;
    //    }
    //    else
    //    {
    //        creatObject = true;
    //    }
    //}
}
