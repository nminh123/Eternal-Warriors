using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] gameObjectPrefab;
    private float countDown;
    public bool creatObject;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        countDown = 1f;
        creatObject = true;
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
                Instantiate(gameObjectPrefab[randomIndex], new Vector3(-12.54f, Random.Range(5.7f, 0.85f), 0), Quaternion.identity);
                countDown = time;

            }
        }
    }
}
