using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressManager : MonoBehaviour
{
    public GameObject stressObjectPrefab;

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
                
                Instantiate(stressObjectPrefab, new Vector3(0f, -3.31f, 0), Quaternion.identity);
                countDown = time;

            }
        }
    }
}
