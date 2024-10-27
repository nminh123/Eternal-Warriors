using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public TestKite kite; 
    public float windInterval = 3f;
    private float timer;

    private void Update()
    {
        if(KiteEnd.instance.isOpenUI) return;
        timer += Time.deltaTime;
        if(timer == 0)
        {

        }
        if (timer >= windInterval)
        {
            GenerateWind();
            timer = 0f;
        }
    }
    private void GenerateWind()
    {
        float direction = Random.Range(0, 3) == 0 ? -1f : 1f;
        //int maxfore = Random.Range(5, 10);
        //int minfore = Random.Range(-5, -10);
        int addforeWined = Random.Range(2, 5);
        kite.ApplyWindForce(direction, addforeWined);
    }
}
