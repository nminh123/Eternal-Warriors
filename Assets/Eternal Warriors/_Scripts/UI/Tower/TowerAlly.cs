using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TowerAlly : Tower
{
    public bool islife = true;

    protected override void Start()
    {
        base.Start();
        islife = true;
    }
    public override void CheckDeah()
    {
        base.CheckDeah();
        if (health <= 0)
            islife = false;
        else
            islife = true;

    }
}
