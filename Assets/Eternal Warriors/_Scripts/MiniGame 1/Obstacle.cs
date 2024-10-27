using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        var direction = Vector3.left;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        //gameObject.SetActive(true);

    }
}
