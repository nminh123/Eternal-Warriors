using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float moveSpeedMin;

    private TimeEnd timeEnd;

    private Health healthPlayer;
    // Update is called once per frame
    private void Start()
    {
        timeEnd = FindAnyObjectByType<TimeEnd>();
        healthPlayer = FindAnyObjectByType<Health>();
        gameObject.SetActive(true);
    }
    void Update()
    {   
        if(timeEnd._time > 0)
        {
            var direction = Vector3.left;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            var direction = Vector3.left;
            transform.Translate(direction * moveSpeedMin * Time.deltaTime);
            gameObject.SetActive(false);
        }
        if(healthPlayer.health == 0)
        {
            var direction = Vector3.left;
            transform.Translate(direction * moveSpeedMin * Time.deltaTime);
            gameObject.SetActive(false);
        }
    }
}
