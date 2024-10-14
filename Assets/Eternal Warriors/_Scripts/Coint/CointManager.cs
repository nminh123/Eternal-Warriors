using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CointManager : MonoBehaviour
{
    public static CointManager instance;

    public int coint;

    private void Awake()
    {
        instance = this;
    }

    public void AddCoint(int _coint)
    {
        coint += _coint;
    }
    public void RemoveCount(int _coint)
    {
        if(coint <= 0) return;

        coint -= _coint;
    }
}
