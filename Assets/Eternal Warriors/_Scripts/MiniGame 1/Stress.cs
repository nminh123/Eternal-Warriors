using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    private bool isRunning = false;

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            stressMove();
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
