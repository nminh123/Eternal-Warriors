using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public static Power instance;
    public int power;
    public int powerDu;
    public float PowerTimer;
    private void Awake()
    {
        instance = this;
    }

    public void AddPower(int point)
    {
        power += point;
    }
    public void RomovePower(int point)
    {
        powerDu = power;
        if (power < powerDu) return;
        
        power -= point;
        
        if(power <= 0) 
            power = 0;
    }
}
