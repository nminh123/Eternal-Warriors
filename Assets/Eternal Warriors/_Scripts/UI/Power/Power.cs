using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public static Power instance;
    public int power;
    public float PowerTimer;
    private void Awake()
    {
        instance = this;
    }

    public void AddPower(int point)
    {
        power += point;
    }
}
