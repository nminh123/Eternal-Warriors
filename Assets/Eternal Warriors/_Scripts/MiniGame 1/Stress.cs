using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private bool isRunning = false;

    private TimeEnd timeEnd;

    // Update is called once per frame
    private void Start()
    {
        timeEnd = FindAnyObjectByType<TimeEnd>();
    }
    void Update()
    {   
        if(timeEnd._time <= 0)
        {
            isRunning = false;
        }
        else
        {
            if (isRunning)
            {
                stressMove();
            }
        }
        
    }
    public void stressMove()
    {
        var direction = Vector3.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
    public void StartStress()
    {
        isRunning = true;
    }
}
